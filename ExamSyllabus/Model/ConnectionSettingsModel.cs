using System;
using Newtonsoft.Json;
using System.IO;
using System.Windows.Forms;

namespace ExamSyllabus.Model
{
    /// <summary>
    /// This model is used for reading and writing settings data.
    /// </summary>
    public class ConnectionSettingsModel
    {
        private const string FILE_NAME = "settings.config";

        public string Server { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConnectionString { get; set; }

        /// <summary>
        /// This method is used to generate a connection string to connect to the database.
        /// </summary>
        /// <returns>Returns a newly generated connection string.</returns>
        private string GenerateConnectionString()
        {
            string server = Server;
            if (Port != 0)
            {
                server = string.Format("{0}:{1}", Server, Port);
            }

            string connectionString = string.Format("Data Source={0};Initial Catalog=Syllabus;Persist Security Info=True;", server);

            if (!Username.Equals(string.Empty))
            {
                connectionString = string.Format("{0}User ID={1};Password={2}", connectionString, Username, Password);
            }
            else
            {
                connectionString = string.Format("{0}Integrated Security=True;", connectionString);
            }

            return connectionString;
        }

        /// <summary>
        /// This method is used to Get Settings from the settings file.
        /// </summary>
        /// <returns>Returns settings if it exists or null.</returns>
        public ConnectionSettingsModel GetSettings()
        {
            ConnectionSettingsModel settings = null;
            string fileLocation = GetFileLocation();

            if (File.Exists(fileLocation))
            {
                try
                {
                    using (StreamReader reader = new StreamReader(new FileStream(fileLocation, FileMode.Open, FileAccess.Read)))
                    {
                        string data = reader.ReadToEnd();
                        settings = JsonConvert.DeserializeObject<ConnectionSettingsModel>(data);
                    }
                }
                catch (Exception e)
                {
                    ApplicationSettingData.Setting.Logger.Log(e.ToString(), Logger.LogType.Error);
                }
            }

            return settings;
        }

        /// <summary>
        /// This method is used to save settings to the settings file.
        /// </summary>
        public void SaveSettings()
        {
            ConnectionString = GenerateConnectionString();
            string fileLocation = GetFileLocation();
            string data = JsonConvert.SerializeObject(this);

            try
            {
                using (StreamWriter writer = new StreamWriter(new FileStream(fileLocation, FileMode.Create, FileAccess.Write)))
                {
                    writer.Write(data);
                    ApplicationSettingData.Setting.Logger.Log("Configuration settings changed.", Logger.LogType.Info);
                }
            }
            catch (Exception e)
            {
                ApplicationSettingData.Setting.Logger.Log(e.ToString(), Logger.LogType.Error);
            }
        }

        /// <summary>
        /// This method is used to get file location with full path of the settings file.
        /// </summary>
        /// <returns>Returns location of the file.</returns>
        private string GetFileLocation()
        {
            string folder = Path.GetFullPath(Application.CommonAppDataPath); 
            string fileLocation = string.Format("{0}\\{1}", folder, FILE_NAME);
            return fileLocation;
        }
    }
}
