using ExamSyllabus.ViewModel;
using System.Data;
using ExamSyllabus.Model;

namespace ExamSyllabus.Service
{
    /// <summary>
    /// This class provides data service for the view models.
    /// </summary>
    /// <typeparam name="T">A view model that derives from BaseViewModel.</typeparam>
    public class VMDataService<T> : IVMDataService<T> where T : BaseViewModel
    {
        /// <summary>
        /// This method is used to fetch data from the database with joins.
        /// </summary>
        /// <param name="conditions">An object that contains logical operator and conditions.</param>
        /// <returns>Returns fetched data.</returns>
        public DataTable GetRecords(DatabaseTable mainTable, JoinConditions conditions)
        {
            string mainTableName = DatabaseTableNameFetcher.GetName(mainTable);
            string mainColumn = TableColumns.GetBaseTablePrimaryColumn(mainTable);

            string query = string.Format("SELECT DISTINCT {0}.{1}", mainTableName, TableColumns.COMMON_ID);

            // If mainColumn value is not empty = It is not a relationship table.
            if (!mainColumn.Equals(string.Empty))
            {
                query = string.Format("{0}, {1}.{2}", query, mainTableName, mainColumn);
            }

            string from = string.Format("FROM {0}", mainTableName);
            string where = string.Format("WHERE {0}.{1} = 0", mainTableName, TableColumns.COMMON_DELETED);

            // If search conditions are provided.
            // All conditions are calculated with AND operator.
            if (conditions.Search != null)
            {
                foreach (var condition in conditions.Search)
                {
                    string baseTable = DatabaseTableNameFetcher.GetName(condition.BaseTable);
                    where = string.Format("{0} AND {1}.{2} = {3}", where, baseTable, condition.Column, condition.Value);
                }
            }

            // Create Join Conditions
            foreach (var condition in conditions.Conditions)
            {
                string baseTable = DatabaseTableNameFetcher.GetName(condition.BaseTable);
                string joinTable = DatabaseTableNameFetcher.GetName(condition.JoinTable);
                string baseColumn = TableColumns.GetBaseTablePrimaryColumn(condition.BaseTable);

                query = string.Format("{0}, {1}.{2}", query, baseTable, baseColumn);
                where = string.Format("{0} {5} {1}.{2} = {3}.{4}",
                    where,
                    baseTable,
                    TableColumns.COMMON_ID,
                    joinTable,
                    condition.JoinTableColumnName,
                    conditions.LogicalOperator);

                if (!from.Contains(baseTable))
                {
                    from = string.Format("{0}, {1}", from, baseTable);
                }
            }

            where = ApplicationSettingData.Setting.Helper.EndsWith(where, "WHERE");
            where = ApplicationSettingData.Setting.Helper.EndsWith(where, conditions.LogicalOperator);
            query = string.Format("{0} {1} {2}", query, from, where);

            return ApplicationSettingData.Setting.DataCommunicator.Read(query);
        }
    }
}
