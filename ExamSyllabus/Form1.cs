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
using ExamSyllabus.ViewModel;

namespace ExamSyllabus
{
    public partial class Form1 : Form
    {
        private IVMDataService<ExamRelationViewModel> viewModelDataService;
        private bool DefaultLoad { get
            {
                return !(cbSubjectList.SelectedIndex > 0 || cbExamList.SelectedIndex > 0);
            }
        }
        private int RowIndex { get; set; }


        public Form1()
        {
            InitializeComponent();
            ParentForm = this;
            RowIndex = 0;
            viewModelDataService = new VMDataService<ExamRelationViewModel>();
            RefreshData();
        }

        /// <summary>
        /// This method is used to load data from the database.
        /// <param name="defaultLoad">This specifies whether to use this function for loading default data or custom data.</param>
        /// </summary>
        private void LoadData(bool defaultLoad = true)
        {
            var conditions = CreateCondition(defaultLoad);
            var data = viewModelDataService.GetRecords(DatabaseTable.Relationship, conditions);

            // Convert datatable data to a list, sort it by name.
            List<ExamRelationViewModel> modelData = (from DataRow row in data.Rows
                                                     select new ExamRelationViewModel
                                                     {
                                                         Id = Convert.ToInt32(row[TableColumns.COMMON_ID]),
                                                         SubjectName = row[TableColumns.SUBJECT_SUBJECT_NAME].ToString(),
                                                         TopicName = row[TableColumns.TOPIC_TOPIC_NAME].ToString(),
                                                         ExamName = row[TableColumns.EXAM_EXAM_NAME].ToString()
                                                     })
                                                    .ToList();

            modelData = modelData
                .OrderBy(x => x.SubjectName)
                .ThenBy(x => x.TopicName)
                .ThenBy(x => x.ExamName)
                .ToList();

            dgvSyllabusDetails.AutoGenerateColumns = false;
            dgvSyllabusDetails.DataSource = modelData;
        }

        /// <summary>
        /// This method is used to create condition object for joining.
        /// </summary>
        /// <param name="defaultLoad">Grid loading state.</param>
        /// <returns>Returns Join Condition object.</returns>
        private JoinConditions CreateCondition(bool defaultLoad)
        {
            var conditions = new JoinConditions
            {
                LogicalOperator = LogicalOperators.AND,
                Conditions = new List<Condition>
                {
                    new Condition
                    {
                        BaseTable = DatabaseTable.Exam,
                        JoinTable = DatabaseTable.Relationship,
                        JoinTableColumnName = TableColumns.EXAM_RELATION_EXAM_ID
                    },
                    new Condition
                    {
                        BaseTable = DatabaseTable.Topic,
                        JoinTable = DatabaseTable.Relationship,
                        JoinTableColumnName = TableColumns.EXAM_RELATION_TOPIC_ID
                    },
                    new Condition
                    {
                        BaseTable = DatabaseTable.Subject,
                        JoinTable = DatabaseTable.Topic,
                        JoinTableColumnName = TableColumns.TOPIC_PARENT_SUBJECT
                    }
                }
            };

            // Check if a search condition is specified.
            if (!defaultLoad)
            {
                conditions.Search = new List<SearchCondition>();

                if (cbExamList.SelectedIndex > 0)
                {
                    conditions.Search.Add(new SearchCondition
                    {
                        BaseTable = DatabaseTable.Exam,
                        Column = TableColumns.COMMON_ID,
                        Value = Convert.ToInt32(cbExamList.SelectedValue)
                    });
                }

                if (cbSubjectList.SelectedIndex > 0)
                {
                    conditions.Search.Add(new SearchCondition
                    {
                        BaseTable = DatabaseTable.Subject,
                        Column = TableColumns.COMMON_ID,
                        Value = Convert.ToInt32(cbSubjectList.SelectedValue)
                    });
                }
            }

            return conditions;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetData();
        }

        /// <summary>
        /// This method is used to reset the data for search.
        /// </summary>
        private void ResetData()
        {
            cbSubjectList.SelectedIndex = 0;
            cbExamList.SelectedIndex = 0;
            LoadData(DefaultLoad);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData(DefaultLoad);
        }

        private void dgvSyllabusDetails_KeyPress(object sender, KeyPressEventArgs e)
        {
            char key = e.KeyChar;

            // If "Ctrl + D" is pressed and a row is selected.
            if (Convert.ToInt32(key) == 4 && dgvSyllabusDetails.SelectedRows.Count > 0)
            {
                var result = MessageBox.Show("Are you sure you want to delete this record?", "DELETE?", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    IDataService<ExamRelationModel> relationshipDataService = new DataService<ExamRelationModel>();
                    int selectedRow = dgvSyllabusDetails.SelectedRows[0].Index;
                    int recordId = Convert.ToInt32(dgvSyllabusDetails.Rows[selectedRow].Cells[0].Value);
                    bool delResult = relationshipDataService.DeleteRecord(recordId, DatabaseTable.Relationship);
                    RowIndex = GetRowIndex(selectedRow);
                    LoadData(DefaultLoad);

                    if (!delResult)
                    {
                        ApplicationSettingData.Setting.Helper.ShowMessage("There was a problem in deleting the record. Please check log file.", DialogTitles.Fail);
                    }
                }
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new SettingController().Show();
        }

        /// <summary>
        /// This method is used to refresh data of the form.
        /// </summary>
        public void RefreshData()
        {
            // Bind data
            new ExamModel().Binder(cbExamList);
            new SubjectModel().Binder(cbSubjectList);
            LoadData(DefaultLoad);
        }

        /// <summary>
        /// This method is used to get updated focused row index.
        /// </summary>
        /// <param name="index">Current index.</param>
        /// <returns>Returns new index.</returns>
        private int GetRowIndex(int index)
        {
            if (index >= 1)
                return --index;
            return 0;
        }

        private void dgvSyllabusDetails_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvSyllabusDetails.FirstDisplayedScrollingRowIndex = RowIndex;
            //RowIndex = 0;
        }
    }
}
