using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using ExamSyllabus.Service;
using ExamSyllabus.Model;
using ExamSyllabus.ViewModel;

namespace ExamSyllabus
{
    public partial class TopicController : Form
    {
        private IDataService<TopicModel> topicDataService;
        private IVMDataService<TopicSubjectViewModel> viewModelDataService;
        private int selectedRecord = -1;

        public TopicController()
        {
            InitializeComponent();
            topicDataService = new DataService<TopicModel>();
            viewModelDataService = new VMDataService<TopicSubjectViewModel>();
            LoadData();

            // Bind data
            new SubjectModel().Binder(cbSubjectList);
            new ExamModel().Binder(lbExamList);
        }

        /// <summary>
        /// This method is used to load the exam data in the table.
        /// </summary>
        private void LoadData()
        {
            var conditions = new JoinConditions
            {
                LogicalOperator = LogicalOperators.AND,
                Conditions = new List<Condition>
                {
                    new Condition
                    {
                        BaseTable = DatabaseTable.Subject,
                        JoinTable = DatabaseTable.Topic,
                        JoinTableColumnName = TableColumns.TOPIC_PARENT_SUBJECT
                    }
                }
            };

            var data = viewModelDataService.GetRecords(DatabaseTable.Topic, conditions);

            // Convert datatable data to a list, sort it by name.
            List<TopicSubjectViewModel> modelData = (from DataRow row in data.Rows
                                                     select new TopicSubjectViewModel
                                                     {
                                                         Id = Convert.ToInt32(row[TableColumns.COMMON_ID]),
                                                         SubjectName = row[TableColumns.SUBJECT_SUBJECT_NAME].ToString(),
                                                         TopicName = row[TableColumns.TOPIC_TOPIC_NAME].ToString()
                                                     })
                                                    .ToList();

            modelData = modelData.OrderBy(x => x.SubjectName).ThenBy(x => x.TopicName).ToList();

            dgvTopicDetails.AutoGenerateColumns = false;
            dgvTopicDetails.DataSource = modelData;
        }

        private void TopicController_Shown(object sender, EventArgs e)
        {
            Form1.ParentForm.Hide();
        }

        private void TopicController_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1.ParentForm.RefreshData();
            Form1.ParentForm.Show();
        }

        private void btnAddTopic_Click(object sender, EventArgs e)
        {
            if (ValidateExamData())
            {
                var topicName = tbTopicName.Text;
                Dictionary<string, object> data = new Dictionary<string, object>();
                data[TableColumns.TOPIC_TOPIC_NAME] = topicName;
                data[TableColumns.TOPIC_PARENT_SUBJECT] = cbSubjectList.SelectedValue;

                bool result = topicDataService.SaveRecord(data, DatabaseTable.Topic);

                if (result)
                {
                    ApplicationSettingData.Setting.Helper.ShowMessage("Topic data saved successfully.", DialogTitles.Success);
                    LoadData();

                    if (lbExamList.SelectedItems.Count > 0)
                    {
                        List<int> exams = new ExamModel().GetSelectedIds(lbExamList);
                        if (exams.Count > 0)
                        {
                            var insertedTopic = topicDataService.GetRecord(DatabaseTable.Topic, data);
                            new ExamRelationModel().Save(insertedTopic.Id, exams);
                        }
                    }

                    ClearData();
                }
                else
                {
                    ApplicationSettingData.Setting.Helper.ShowMessage("An error occured while saving record. Please check the log.", DialogTitles.Fail);
                }

            }
            else
            {
                ApplicationSettingData.Setting.Helper.ShowMessage("Please check topic name and/or selected subject.", DialogTitles.Error);
            }
        }

        /// <summary>
        /// This method is used to validate the content of the form.
        /// </summary>
        /// <returns>Returns the status of the form validation - true or false.</returns>
        private bool ValidateExamData()
        {
            int subjectIndex = cbSubjectList.SelectedIndex;
            return subjectIndex != 0 && !string.IsNullOrEmpty(tbTopicName.Text);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        /// <summary>
        /// This method is used to clear the data from the form.
        /// </summary>
        private void ClearData()
        {
            tbTopicName.Text = string.Empty;
            cbSubjectList.SelectedIndex = 0;
            lbExamList.ClearSelected();
            lbExamList.SelectedIndex = 0;
        }

        private void btnUpdateTopic_Click(object sender, EventArgs e)
        {
            if (selectedRecord != -1)
            {
                if (ValidateExamData())
                {
                    string topicName = tbTopicName.Text;
                    int parentSubject = Convert.ToInt32(cbSubjectList.SelectedValue);

                    Dictionary<string, object> data = new Dictionary<string, object>();
                    data[TableColumns.TOPIC_TOPIC_NAME] = topicName;
                    data[TableColumns.TOPIC_PARENT_SUBJECT] = parentSubject;

                    var result = topicDataService.EditRecord(selectedRecord, data, DatabaseTable.Topic);

                    if (result)
                    {
                        ApplicationSettingData.Setting.Helper.ShowMessage("Record updated successfully.", DialogTitles.Success);
                        EnableEditMode(false);
                        LoadData();
                        tabber.SelectedIndex = 0;
                    }
                    else
                    {
                        ApplicationSettingData.Setting.Helper.ShowMessage("An error occurred while updating record. Please check log file.", DialogTitles.Fail);
                    }
                }
                else
                {
                    ApplicationSettingData.Setting.Helper.ShowMessage("Please check topic name and/or selected subject.", DialogTitles.Error);
                }
            }
            else
            {
                ApplicationSettingData.Setting.Helper.ShowMessage("No record is selected.", DialogTitles.Error);
            }
        }

        /// <summary>
        /// This method is used to enable or disable the edit mode - hide and show buttons.
        /// </summary>
        private void EnableEditMode(bool state)
        {
            if (state)
            {
                btnAddTopic.Visible = false;
                btnUpdateTopic.Visible = true;
                lbExamList.Enabled = false;
            }
            else
            {
                btnAddTopic.Visible = true;
                btnUpdateTopic.Visible = false;
                lbExamList.Enabled = true;
                ClearData();
                selectedRecord = -1;
            }
        }

        // This event occurs when a key, or a combination of key is pressed.
        private void dgvTopicDetails_KeyPress(object sender, KeyPressEventArgs e)
        {
            char key = e.KeyChar;

            // If "Ctrl + D" is pressed and a row is selected.
            if (Convert.ToInt32(key) == 4 && dgvTopicDetails.SelectedRows.Count > 0)
            {
                var result = MessageBox.Show("Are you sure you want to delete this record?", "DELETE?", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    int selectedRow = dgvTopicDetails.SelectedRows[0].Index;
                    int recordId = Convert.ToInt32(dgvTopicDetails.Rows[selectedRow].Cells[0].Value);
                    bool delResult = topicDataService.DeleteRecord(recordId, DatabaseTable.Topic);
                    LoadData();

                    if (!delResult)
                    {
                        ApplicationSettingData.Setting.Helper.ShowMessage("There was a problem in deleting the record. Please check log file.", DialogTitles.Fail);
                    }
                }
            }
        }

        // This event occurs when a mouse double clicks on a row. This event is used here for editing.
        private void dgvTopicDetails_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Read cell and its metadata.
            var cells = dgvTopicDetails.Rows[e.RowIndex].Cells;
            selectedRecord = Convert.ToInt32(cells[0].Value);
            string topicName = cells[1].Value.ToString();
            string subjectName = cells[2].Value.ToString();

            tbTopicName.Text = topicName;
            cbSubjectList.SelectedIndex = cbSubjectList.FindString(subjectName);

            EnableEditMode(true);
            tabber.SelectedIndex = 1;
        }
    }
}
