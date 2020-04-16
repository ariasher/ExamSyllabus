namespace ExamSyllabus.Data
{
    /// <summary>
    /// This interface specifies necessary methods that are required to communicate with the database.
    /// </summary>
    public interface IDataCommunicator
    {
        bool Commit(string query, System.Data.SqlClient.SqlParameter[] parameters = null);
        System.Data.DataTable Read(string query, System.Data.SqlClient.SqlParameter[] parameters = null);
    }
}
