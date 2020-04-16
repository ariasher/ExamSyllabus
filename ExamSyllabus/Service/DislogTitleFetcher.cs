namespace ExamSyllabus.Service
{
    /// <summary>
    /// This class is used to retrieve string representation of dialog titles.
    /// </summary>
    public class DislogTitleFetcher
    {
        /// <summary>
        /// This method is used to sort out the dialog titles.
        /// </summary>
        /// <param name="title">Title of the dialog box.</param>
        /// <returns>Returns a string representation of dialog title.</returns>
        public static string GetTitle(DialogTitles title)
        {
            string titleName = string.Empty;

            switch (title)
            {
                case DialogTitles.Error:
                    titleName = "ERROR";
                    break;

                case DialogTitles.Fail:
                    titleName = "FAILED";
                    break;

                case DialogTitles.Info:
                    titleName = "INFO";
                    break;

                case DialogTitles.Success:
                    titleName = "SUCCESS";
                    break;

                case DialogTitles.Warning:
                    titleName = "WARNING";
                    break;
            }

            return titleName;
        }
    }
}
