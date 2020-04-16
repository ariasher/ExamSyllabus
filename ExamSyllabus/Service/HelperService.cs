using System.Windows.Forms;

namespace ExamSyllabus.Service
{
    /// <summary>
    /// This is a class for providing common methods for use throughout the application.
    /// </summary>
    public class HelperService
    {
        /// <summary>
        /// This method is used to remove a string at the end of a string.
        /// </summary>
        /// <param name="dataString">Main string.</param>
        /// <param name="removalString">String to be removed.</param>
        /// <returns>Returns a new string which does not have removalString.</returns>
        public string EndsWith(string dataString, string removalString)
        {
            if (dataString.EndsWith(removalString))
            {
                dataString = dataString.Substring(0, dataString.Length - removalString.Length);
            }

            return dataString;
        }

        /// <summary>
        /// This method is used to show a dialog box with a title and a message.
        /// </summary>
        /// <param name="message">Message to be displayed.</param>
        /// <param name="title">Title to be displayed.</param>
        public void ShowMessage(string message, DialogTitles title)
        {
            string titleMessage = DislogTitleFetcher.GetTitle(title);
            MessageBox.Show(message, titleMessage);
        }
    }
}
