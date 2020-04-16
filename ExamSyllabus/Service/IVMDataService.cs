using ExamSyllabus.ViewModel;

namespace ExamSyllabus.Service
{
    /// <summary>
    /// This interface specifies necessary methods that are needed to coomunicate with the underlying DataCommunicator service.
    /// </summary>
    /// <typeparam name="T">Model of type BaseViewModel.</typeparam>
    public interface IVMDataService<T> where T:BaseViewModel
    {
        System.Data.DataTable GetRecords(DatabaseTable mainTable, JoinConditions conditions);
    }
}
