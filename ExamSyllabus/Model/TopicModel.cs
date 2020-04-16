using ExamSyllabus.Service;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data;
using System;
using System.Linq;

namespace ExamSyllabus.Model
{
    /// <summary>
    /// This class represents the Topic table.
    /// </summary>
    public class TopicModel : BaseModel
    {
        public string TopicName { get; set; }
        public int ParentSubject { get; set; }

        /// <summary>
        /// This method is used to bind topics to the control of type list such as ListBox and ComboBox.
        /// </summary>
        /// <param name="control">Takes a control to bind data to it.</param>
        /// <param name="subjectId">Id of the subject under which topics reside.</param>
        /// <param name="noTopic">Specifies whether to fill with database data or single default record.</param>
        public void Binder(ListControl control, int subjectId = 0, bool noTopic = false)
        {
            List<TopicModel> modelData = new List<TopicModel>();
            var firstTopic = new TopicModel
            {
                Deleted = false,
                Id = -1,
                ParentSubject = -1,
                TopicName = "--SELECT TOPIC--"
            };

            if (!noTopic)
            {
                IDataService<TopicModel> topicDataService = new DataService<TopicModel>();
                DataTable topicData;

                // If a subject id is defined, get topics under that subject.
                if (subjectId != 0)
                {
                    Dictionary<string, object> data = new Dictionary<string, object>();
                    data[TableColumns.TOPIC_PARENT_SUBJECT] = subjectId;

                    topicData = topicDataService.GetRecords(DatabaseTable.Topic, data);
                }
                else
                {
                    topicData = topicDataService.GetRecords(DatabaseTable.Topic);
                }

                // Convert datatable data to a list, sort it by name.
                modelData = (from DataRow row in topicData.Rows
                                              select new TopicModel
                                              {
                                                  Deleted = Convert.ToBoolean(row[TableColumns.COMMON_DELETED]),
                                                  Id = Convert.ToInt32(row[TableColumns.COMMON_ID]),
                                                  TopicName = row[TableColumns.TOPIC_TOPIC_NAME].ToString(),
                                                  ParentSubject = Convert.ToInt32(row[TableColumns.TOPIC_PARENT_SUBJECT])
                                              })
                                             .ToList();

                modelData = modelData.OrderBy(x => x.TopicName).ToList();
            }

            modelData.Insert(0, firstTopic);

            control.DataSource = modelData;
            control.DisplayMember = TableColumns.TOPIC_TOPIC_NAME;
            control.ValueMember = TableColumns.COMMON_ID;
        }
    }
}
