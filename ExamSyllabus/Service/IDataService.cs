using ExamSyllabus.Model;
using System.Collections.Generic;

namespace ExamSyllabus.Service
{
    /// <summary>
    /// This interface provides necessary methods to communicate with the underlying DataCommunicator service.
    /// </summary>
    /// <typeparam name="T">Model of type BaseModel</typeparam>
    public interface IDataService<T> where T:BaseModel
    {
        bool SaveRecord(Dictionary<string, object> data, DatabaseTable table);

        bool EditRecord(int Id, Dictionary<string, object> data, DatabaseTable table);

        bool DeleteRecord(int Id, DatabaseTable table);

        T GetRecord(int id, DatabaseTable table);

        T GetRecord(DatabaseTable table, Dictionary<string, object> condition);

        System.Data.DataTable GetRecords(DatabaseTable table, Dictionary<string, object> condition = null);
    }
}
