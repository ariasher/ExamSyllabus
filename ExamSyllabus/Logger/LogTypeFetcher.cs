namespace ExamSyllabus.Logger
{
    /// <summary>
    /// This class is used to get the type of Log in a string format.
    /// </summary>
    public class LogTypeFetcher
    {
        /// <summary>
        /// This method is used to provide string representation of LogType
        /// </summary>
        /// <param name="type">Type of log.</param>
        /// <returns>Returns string representation of logtype.</returns>
        public static string GetType(LogType type)
        {
            string typeName = string.Empty;

            switch (type)
            {
                case LogType.Error:
                    typeName = "ERROR";
                    break;

                case LogType.Info:
                    typeName = "INFO";
                    break;

                case LogType.Warning:
                    typeName = "WARNING";
                    break;
            }

            return typeName;
        }
    }
}
