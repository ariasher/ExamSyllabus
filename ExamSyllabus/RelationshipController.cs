using ExamSyllabus.Model;
using ExamSyllabus.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamSyllabus
{
    public partial class RelationshipController : Form
    {
        private IDataService<TopicModel> topicDataService;

        public RelationshipController()
        {
            InitializeComponent();
            topicDataService = new DataService<TopicModel>();

            // Bind Data
            new ExamModel().Binder(lbExamList);
            new SubjectModel().Binder(cbSubjectList);
            BindTopics(true);

        }

        private void RelationshipController_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1.ParentForm.Show();
        }

        private void RelationshipController_Shown(object sender, EventArgs e)
        {
            Form1.ParentForm.Hide();
        }

        private void cbSubjectList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSubjectList.SelectedIndex == 0)
            {
                BindTopics(true);
            }
            else
            {
                BindTopics();
            }
        }

        /// <summary>
        /// This method is used to bind topics to the topics combo box depending on the value selected in subjects combo box.
        /// </summary>
        /// <param name="noSubject">Status to specify if any subject is selected or not.</param>
        private void BindTopics(bool noSubject = false)
        {
            if (noSubject)
            {
                new TopicModel().Binder(cbTopicList, 0, true);
            }
            else
            {
                new TopicModel().Binder(cbTopicList);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetData();
        }

        /// <summary>
        /// This method is used to reset the data of the form.
        /// </summary>
        private void ResetData()
        {
            cbSubjectList.SelectedIndex = 0;
            BindTopics(true);
            lbExamList.ClearSelected();
            lbExamList.SelectedIndex = 0;
        }

        private void btnAddRelationship_Click(object sender, EventArgs e)
        {
            var examsList = GetSelectedExamIdsList();
            if (ValidateData(examsList.Count))
            {
                var topicId = Convert.ToInt32(cbTopicList.SelectedValue);
                new ExamRelationModel().Save(topicId, examsList);
                ApplicationSettingData.Setting.Helper.ShowMessage("Done.", DialogTitles.Info);
                ResetData();
            }
            else
            {
                ApplicationSettingData.Setting.Helper.ShowMessage("Please select Subject/ Topic/ Exam(s).", DialogTitles.Error);
            }
        }

        /// <summary>
        /// This method is used to get a list of all selected exams.
        /// </summary>
        /// <returns></returns>
        private List<int> GetSelectedExamIdsList()
        {
            List<int> indices = lbExamList.SelectedIndices.Cast<int>().ToList();
            var items = lbExamList.Items.Cast<ExamModel>().ToArray();
            List<int> exams = new List<int>();

            foreach (var index in indices)
            {
                if (index != 0)
                {
                    int value = items[index].Id;
                    exams.Add(value);
                }
            }

            return exams;
        }

        /// <summary>
        /// This method is used to get validation result of the form.
        /// </summary>
        /// <param name="examsCount">Count of exams selected.</param>
        private bool ValidateData(int examsCount)
        {
            // Topic can only be selected when a subject is selected.
            return cbTopicList.SelectedIndex != 0 && examsCount > 0;
        }
    }
}
