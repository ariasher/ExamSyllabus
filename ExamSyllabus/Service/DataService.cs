using ExamSyllabus.Model;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Newtonsoft.Json;

namespace ExamSyllabus.Service
{
    /// <summary>
    /// This class provides a communication mechanism to communicate with the underlying data service 
    /// to manipulate or retrieve database records.
    /// </summary>
    /// <typeparam name="T">Any model that derives from BaseModel class.</typeparam>
    public class DataService<T> : IDataService<T> where T:BaseModel 
    {
        /// <summary>
        /// This method is used to save or insert a new record in the database.
        /// </summary>
        /// <param name="data">A Dictionary containing column names as keys and their values.</param>
        /// <param name="table">Table in which data has to be inserted.</param>
        /// <returns>Returns true if the operation completed successfully, otherwise false.</returns>
        public bool SaveRecord(Dictionary<string, object> data, DatabaseTable table)
        {
            string tableName = DatabaseTableNameFetcher.GetName(table);
            string query = string.Format("INSERT INTO {0}(", tableName);
            string values = "VALUES(";
            List<SqlParameter> parameters = new List<SqlParameter>();
            int count = 0;

            // Generate proper query.
            foreach (var key in data.Keys)
            {
                query += string.Format("{0},", key);
                values += string.Format("@p{0},", count);
                parameters.Add(new SqlParameter("@p" + count, data[key]));
                ++count;
            }

            query = ApplicationSettingData.Setting.Helper.EndsWith(query, ",");
            values = ApplicationSettingData.Setting.Helper.EndsWith(values, ",");
            values += ");";
            query += ") " + values;

            return ApplicationSettingData.Setting.DataCommunicator.Commit(query, parameters.ToArray());
        }

        /// <summary>
        /// This method is used to edit or modify the records of the database.
        /// </summary>
        /// <param name="Id">Id of the record to be modfied.</param>
        /// <param name="data">A Dictionary that contains column names as keys and their values.</param>
        /// <param name="table">Table on which manipulation has to be done.</param>
        /// <returns>Returns true if operation completed successfully, otherwise false.</returns>
        public bool EditRecord(int Id, Dictionary<string, object> data, DatabaseTable table)
        {
            string tableName = DatabaseTableNameFetcher.GetName(table);
            string query = string.Format("UPDATE {0} SET ", tableName);
            List<SqlParameter> parameters = new List<SqlParameter>();
            int count = 0;

            // Generate query.
            foreach (var key in data.Keys)
            {
                query += string.Format("{0} = @p{1},", key, count);
                parameters.Add(new SqlParameter("@p" + count, data[key]));
                ++count;
            }

            query = ApplicationSettingData.Setting.Helper.EndsWith(query, ",");
            query = string.Format("{0} WHERE {1} = {2}", query, TableColumns.COMMON_ID, Id);

            return ApplicationSettingData.Setting.DataCommunicator.Commit(query, parameters.ToArray());
        }

        /// <summary>
        /// This method is used to mark a record as deleted in the database.
        /// </summary>
        /// <param name="Id">Id of the record to be marked as deleted.</param>
        /// <param name="table">Table on which operation has to be performed.</param>
        /// <returns>Returns true if operation completed successfully, otherwise false.</returns>
        public bool DeleteRecord(int Id, DatabaseTable table)
        {
            string tableName = DatabaseTableNameFetcher.GetName(table);
            string query = string.Format("UPDATE {0} SET {1} = 1 WHERE {2} = {3}", 
                tableName, 
                TableColumns.COMMON_DELETED,
                TableColumns.COMMON_ID,
                Id);

            return ApplicationSettingData.Setting.DataCommunicator.Commit(query);
        }

        /// <summary>
        /// This method is used to get a record from the database by using Id of the record as search parameter.
        /// </summary>
        /// <param name="id">Id of the record.</param>
        /// <param name="table">Table on which operation has to be performed.</param>
        /// <returns>Returns the record from the database.</returns>
        public T GetRecord(int id, DatabaseTable table)
        {
            string tableName = DatabaseTableNameFetcher.GetName(table);
            string query = string.Format("SELECT * FROM {0} where {1} = {2}", tableName, TableColumns.COMMON_ID, id);

            var result = ApplicationSettingData.Setting.DataCommunicator.Read(query);
            return result.Rows.Cast<T>().FirstOrDefault();
        }

        /// <summary>
        /// This method is used to get a record from the database by matching multiple search criterias.
        /// </summary>
        /// <param name="table">Table to which the record belongs.</param>
        /// <param name="condition">Different search conditions. Keys are the column names.</param>
        /// <returns>Returns the record from the database.</returns>
        public T GetRecord(DatabaseTable table, Dictionary<string, object> condition)
        {
            string tableName = DatabaseTableNameFetcher.GetName(table);
            string query = string.Format("SELECT * FROM {0} WHERE", tableName);
            List<SqlParameter> parameters = new List<SqlParameter>();
            int count = 0;

            // Generate query.
            foreach (var key in condition.Keys)
            {
                query = string.Format("{0} {1} = @p{2} AND", query, key, count);
                parameters.Add(new SqlParameter("@p" + count, condition[key]));
                ++count;
            }

            query = ApplicationSettingData.Setting.Helper.EndsWith(query, "AND");
            query = ApplicationSettingData.Setting.Helper.EndsWith(query, "WHERE");

            var result = ApplicationSettingData.Setting.DataCommunicator.Read(query, parameters.ToArray());

            return GetConvertedData(result);            
        }

        /// <summary>
        /// This method is used to convert datatable to list of T, and ultimately to single object.
        /// </summary>
        /// <param name="result">Retrieved datatable.</param>
        /// <returns>Returns single object of type T.</returns>
        private T GetConvertedData(DataTable result)
        {
            var dataDictionary = result
                .AsEnumerable()
                .Select(row =>
                    result
                    .Columns
                    .Cast<DataColumn>()
                    .ToDictionary(column => column.ColumnName, column => row[column] as object)
                );

            var serializedData = JsonConvert.SerializeObject(dataDictionary);

            List<T> deserializedObject = JsonConvert.DeserializeObject<List<T>>(serializedData);

            return deserializedObject.FirstOrDefault();
        }

        /// <summary>
        /// This method is used to get multiple records from the database.
        /// </summary>
        /// <param name="table">Table from which records are to be fetched.</param>
        /// <param name="condition">Search conditions. Keys are column names.</param>
        /// <returns>Returns a dataTable object with retrieved records.</returns>
        public DataTable GetRecords(DatabaseTable table, Dictionary<string, object> condition = null)
        {
            string tableName = DatabaseTableNameFetcher.GetName(table);
            string query = string.Format("SELECT * FROM {0} WHERE {1} = 0 AND", tableName, TableColumns.COMMON_DELETED);

            if (condition != null)
            {
                int count = 0;
                List<SqlParameter> parameters = new List<SqlParameter>();

                foreach (var key in condition.Keys)
                {
                    query += string.Format(" {0} = @p{1} AND", key, count);
                    parameters.Add(new SqlParameter("@p" + count, condition[key]));
                    ++count;
                }

                query = ApplicationSettingData.Setting.Helper.EndsWith(query, "AND");
                return ApplicationSettingData.Setting.DataCommunicator.Read(query, parameters.ToArray());
            }

            query = ApplicationSettingData.Setting.Helper.EndsWith(query, "AND");
            return ApplicationSettingData.Setting.DataCommunicator.Read(query);
        }
    }
}
