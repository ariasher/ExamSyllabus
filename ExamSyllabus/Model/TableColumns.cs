using ExamSyllabus.Service;

namespace ExamSyllabus.Model
{
    /// <summary>
    /// This class provides the name of all the columns of their respective tables.
    /// A_BC respresents A is the table name and BC is the column name.
    /// Common prefix is used for column names which are common to all the tables.
    /// </summary>
    public class TableColumns
    {
        public static string COMMON_ID = "Id";
        public static string COMMON_DELETED = "Deleted";
        public static string EXAM_EXAM_NAME = "ExamName";
        public static string EXAM_RELATION_EXAM_ID = "ExamId";
        public static string EXAM_RELATION_TOPIC_ID = "TopicId";
        public static string SUBJECT_SUBJECT_NAME = "SubjectName";
        public static string TOPIC_TOPIC_NAME = "TopicName";
        public static string TOPIC_PARENT_SUBJECT = "ParentSubject";

        /// <summary>
        /// This method is used to get the primary column name, not the primary key column name of the table.
        /// </summary>
        /// <param name="table">Name of the table.</param>
        /// <returns>Returns string name of primary column.</returns>
        public static string GetBaseTablePrimaryColumn(DatabaseTable table)
        {
            string column = string.Empty;
            switch (table)
            {
                case DatabaseTable.Exam:
                    column = EXAM_EXAM_NAME;
                    break;

                case DatabaseTable.Subject:
                    column = SUBJECT_SUBJECT_NAME;
                    break;

                case DatabaseTable.Topic:
                    column = TOPIC_TOPIC_NAME;
                    break;

                case DatabaseTable.Relationship:
                    break;
            }

            return column;
        }
    }
}
