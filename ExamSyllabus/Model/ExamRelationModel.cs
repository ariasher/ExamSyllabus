using ExamSyllabus.Service;
using System.Collections.Generic;

namespace ExamSyllabus.Model
{
    /// <summary>
    /// This class is the model for ExamRelationship table.
    /// </summary>
    public class ExamRelationModel : BaseModel
    {
        public int ExamId { get; set; }
        public int TopicId { get; set; }

        /// <summary>
        /// This method is used to add a topic to a list of exams.
        /// </summary>
        /// <param name="topic">Topic Id.</param>
        /// <param name="exams">List of Exam Ids.</param>
        public void Save(int topic, List<int> exams)
        {
            IDataService<ExamRelationModel> relationService = new DataService<ExamRelationModel>();

            foreach (var exam in exams)
            {
                SaveToDatabase(topic, exam, relationService);
            }
        }

        /// <summary>
        /// This method is used to add topic and exams combination one by one.
        /// </summary>
        /// <param name="topic">Topic id.</param>
        /// <param name="exam">Exam Id.</param>
        /// <param name="relationService">Relationship service object.</param>
        private void SaveToDatabase(int topic, int exam, IDataService<ExamRelationModel> relationService)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data[TableColumns.EXAM_RELATION_EXAM_ID] = exam;
            data[TableColumns.EXAM_RELATION_TOPIC_ID] = topic;

            relationService.SaveRecord(data, DatabaseTable.Relationship);
        }
    }
}
