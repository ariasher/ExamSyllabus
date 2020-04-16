using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSyllabus.Service
{
    /// <summary>
    /// This class is used to fetch string representations of database table names.
    /// </summary>
    internal class DatabaseTableNameFetcher
    {
        /// <summary>
        /// Get name of the database table.
        /// </summary>
        /// <param name="table">Table Enum Value</param>
        /// <returns>Returns name of the table in the database.</returns>
        internal static string GetName(DatabaseTable table)
        {
            string name = string.Empty;

            switch (table)
            {
                case DatabaseTable.Exam:
                    name = "[Exam]";
                    break;

                case DatabaseTable.Relationship:
                    name = "[ExamRelation]";
                    break;

                case DatabaseTable.Subject:
                    name = "[Subject]";
                    break;

                case DatabaseTable.Topic:
                    name = "[Topic]";
                    break;
            }

            return name;
        }
    }
}
