using ExamSyllabus.Logger;
using System.Windows.Forms;
using ExamSyllabus.Model;

namespace ExamSyllabus
{
    /// <summary>
    /// This class provides some global objects that span throughout the application.
    /// </summary>
    public class ApplicationSettingData
    {
        public ILogger Logger { get; set; }
        public Data.IDataCommunicator DataCommunicator { get; set; }
        public Service.HelperService Helper { get; set; }

        // Singleton object
        public static ApplicationSettingData Setting = new ApplicationSettingData();

        private ApplicationSettingData()
        {
            string logLocation = GetLogLocation();
            Logger = new DefaultLogger(logLocation);

            string connectionString = GetConnectionString();
            DataCommunicator = new Data.DataCommunicator(connectionString);

            Helper = new Service.HelperService();
        }

        /// <summary>
        /// This method is used to get the connection string fronm the configuration file.
        /// </summary>
        /// <returns>Returns connection string.</returns>
        private string GetConnectionString()
        {
            var model = new ConnectionSettingsModel();
            var settings = model.GetSettings();
            string connection = string.Empty;

            if (settings != null)
            {
                connection = settings.ConnectionString;
            }
            
            return connection;
        }

        /// <summary>
        /// This method is used to get the log location for keeping and maintaining log file.
        /// </summary>
        /// <returns>Returns the location where log file will be kept.</returns>
        private string GetLogLocation()
        {
            string location = location = string.Format("{0}\\logfile.log", System.IO.Path.GetFullPath(Application.CommonAppDataPath));
            return location;
        }
    }
}
