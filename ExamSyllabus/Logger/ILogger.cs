namespace ExamSyllabus.Logger
{
    /// <summary>
    /// This interface specifies essential methods that are required to access the log files.
    /// </summary>
    public interface ILogger
    {
        void Log(string logMessage, LogType type);
    }
}
