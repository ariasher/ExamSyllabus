namespace ExamSyllabus.ViewModel
{
    /// <summary>
    /// This model repreents relationship between Exam, Relationship, Subject, topic tables.
    /// </summary>
    public class ExamRelationViewModel : BaseViewModel
    {
        public string ExamName { get; set; }
        public string SubjectName { get; set; }
        public string TopicName { get; set; }
    }
}
