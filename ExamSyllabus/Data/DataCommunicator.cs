using System;
using System.Data.SqlClient;
using System.Data;

namespace ExamSyllabus.Data
{
    /// <summary>
    /// This class provides a communication mechanism to communicate with the Database.
    /// </summary>
    public class DataCommunicator : IDataCommunicator
    {
        private SqlConnection Connection { get; set; }
        private SqlCommand Command { get; set; }

        public DataCommunicator(string connectionString)
        {
            Connection = new SqlConnection(connectionString);
            Command = Connection.CreateCommand();
            Command.Connection = Connection;
        }

        /// <summary>
        /// This method is used to Add/Update or Delete records in the database.
        /// </summary>
        /// <param name="query">Query to be executed.</param>
        /// <param name="parameters">Optional parameters.</param>
        /// <returns></returns>
        public bool Commit(string query, SqlParameter[] parameters = null)
        {
            bool response = true;
            try
            {
                ModifyCommand(query, parameters);
                Connection.Open();
                Command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                ApplicationSettingData.Setting.Logger.Log(e.ToString(), Logger.LogType.Error);
                response = false;
            }
            finally
            {
                ResetSettings();
            }

            return response;
        }

        /// <summary>
        /// This method provides a way to read data from the database.
        /// </summary>
        /// <param name="query">Query to be executed.</param>
        /// <param name="parameters">Optional parameters.</param>
        /// <returns></returns>
        public DataTable Read(string query, SqlParameter[] parameters = null)
        {
            DataTable data = new DataTable();
            try
            {
                ModifyCommand(query, parameters);
                Connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(Command))
                {
                    adapter.Fill(data);
                }
            }
            catch (Exception e)
            {
                ApplicationSettingData.Setting.Logger.Log(e.ToString(), Logger.LogType.Error);
            }
            finally
            {
                ResetSettings();
            }

            return data;
        }

        /// <summary>
        /// This method is used to modify the query if parameters are provided.
        /// </summary>
        /// <param name="query">Query to be modified.</param>
        /// <param name="parameters">Parameters to add to the query.</param>
        private void ModifyCommand(string query, SqlParameter[] parameters = null)
        {
            Command.CommandText = query;

            if (parameters != null)
            {
                foreach (var item in parameters)
                {
                    Command.Parameters.Add(item);
                }
            }
        }

        /// <summary>
        /// This method is used to reset the connection and command settings.
        /// </summary>
        private void ResetSettings()
        {
            Connection.Close();
            Command.CommandText = string.Empty;
            Command.CommandType = CommandType.Text;
            Command.Parameters.Clear();
        }
    }
}
