using System;
using System.IO;

namespace ExamSyllabus.Logger
{
    /// <summary>
    /// This class provides a default logger.
    /// </summary>
    public class DefaultLogger : ILogger
    {
        /// <summary>
        /// Location of the log file.
        /// </summary>
        public string LogLocation { get; set; }

        public DefaultLogger(string location)
        {
            LogLocation = location;
        }

        /// <summary>
        /// This method is used to write message to the log file.
        /// </summary>
        /// <param name="logMessage">Message to be written.</param>
        /// <param name="type">Type of log.</param>
        public void Log(string logMessage, LogType type)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(new FileStream(LogLocation, FileMode.Append, FileAccess.Write)))
                {
                    string logType = LogTypeFetcher.GetType(type);
                    DateTime time = DateTime.Now;

                    writer.WriteLine("Log Date: " + time.ToString());
                    writer.WriteLine("{0}: {1}", logType, logMessage);
                    writer.WriteLine();
                }
                    
            }
            catch (Exception e)
            {
                ApplicationSettingData.Setting.Helper.ShowMessage("An error occurred while writing logs.", Service.DialogTitles.Fail);
            }
        }
    }
}
