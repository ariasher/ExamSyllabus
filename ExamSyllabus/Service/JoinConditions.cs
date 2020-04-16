using System.Collections.Generic;

namespace ExamSyllabus.Service
{
    /// <summary>
    /// All operations will be done on ID
    /// </summary>
    public class JoinConditions
    {
        /// <summary>
        /// Logical operator to be used. Use class LogicalOperators to fill it.
        /// </summary>
        public string LogicalOperator { get; set; }
        public List<Condition> Conditions { get; set; }
        public List<SearchCondition> Search { get; set; }
    }

    /// <summary>
    /// A class for conditions for joining tables.
    /// </summary>
    public class Condition
    {
        /// <summary>
        /// Parent Table
        /// </summary>
        public DatabaseTable BaseTable { get; set; }
        
        /// <summary>
        /// Dependent Table
        /// </summary>
        public DatabaseTable JoinTable { get; set; }

        /// <summary>
        /// Dependent table column name that contains foreign key. Use TableColumns class to fill it.
        /// </summary>
        public string JoinTableColumnName { get; set; }
    }

    /// <summary>
    /// This class is used to provide where clause search conditions for view model data.
    /// </summary>
    public class SearchCondition
    {
        public DatabaseTable BaseTable { get; set; }
        public string Column { get; set; }
        public object Value { get; set; }
    }
}
