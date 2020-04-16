using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExamSyllabus.Model;
using ExamSyllabus.Service;

namespace ExamSyllabus
{
    public partial class ExamController : Form
    {
        IDataService<ExamModel> examDataService;
        int selectedRecord = -1;

        public ExamController()
        {
            InitializeComponent();
            examDataService = new DataService<ExamModel>();
            LoadData();
        }

        /// <summary>
        /// This method is used to load the exam data in the table.
        /// </summary>
        private void LoadData()
        {
            DataTable data = examDataService.GetRecords(DatabaseTable.Exam);

            // Convert datatable data to a list, sort it by name.
            List<ExamModel> modelData = (from DataRow row in data.Rows
                                         select new ExamModel
                                         {
                                             Deleted = Convert.ToBoolean(row[TableColumns.COMMON_DELETED]),
                                             Id = Convert.ToInt32(row[TableColumns.COMMON_ID]),
                                             ExamName = row[TableColumns.EXAM_EXAM_NAME].ToString()
                                         })
                                         .ToList();

            modelData = modelData.OrderBy(x => x.ExamName).ToList();

            dgvExamDetails.AutoGenerateColumns = false;
            dgvExamDetails.DataSource = modelData;
        }


        private void btnSaveExam_Click(object sender, EventArgs e)
        {
            if (ValidateExamData())
            {
                var examName = tbExamName.Text;
                Dictionary<string, object> data = new Dictionary<string, object>();
                data[TableColumns.EXAM_EXAM_NAME] = examName;
                bool result = examDataService.SaveRecord(data, DatabaseTable.Exam);

                if (result)
                {
                    ApplicationSettingData.Setting.Helper.ShowMessage("Exam data saved successfully.", DialogTitles.Success);
                    ClearData();
                    LoadData();
                }
                else
                {
                    ApplicationSettingData.Setting.Helper.ShowMessage("An error occured while saving record. Please check the log.", DialogTitles.Fail);
                }

            }
            else
            {
                ApplicationSettingData.Setting.Helper.ShowMessage("Exam name cannot be empty.", DialogTitles.Error);
            }
        }

        /// <summary>
        /// This method is used to validate the content of the form.
        /// </summary>
        /// <returns>Returns the status of the form validation - true or false.</returns>
        private bool ValidateExamData()
        {
            return !string.IsNullOrEmpty(tbExamName.Text);
        }

        private void ExamController_Shown(object sender, EventArgs e)
        {
            Form1.ParentForm.Hide();
        }

        private void ExamController_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1.ParentForm.RefreshData();
            Form1.ParentForm.Show();
        }

        // This event occurs when a mouse double clicks on a row. This event is used here for editing.
        private void dgvExamDetails_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Read cell and its metadata.
            var cells = dgvExamDetails.Rows[e.RowIndex].Cells;
            selectedRecord = Convert.ToInt32(cells[0].Value);
            string name = cells[1].Value.ToString();
            tbExamName.Text = name;

            EnableEditMode(true);
            tabber.SelectedIndex = 1;
        }

        /// <summary>
        /// This method is used to enable or disable the edit mode - hide and show buttons.
        /// </summary>
        private void EnableEditMode(bool state)
        {
            if (state)
            {
                btnSaveExam.Visible = false;
                btnUpdateExam.Visible = true;
            }
            else
            {
                btnSaveExam.Visible = true;
                btnUpdateExam.Visible = false;
                ClearData();
                selectedRecord = -1;
            }
        }

        /// <summary>
        /// This method is used to clear the data from the form.
        /// </summary>
        private void ClearData()
        {
            tbExamName.Text = string.Empty;
        }

        private void btnClearExam_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        // This event occurs when a key, or a combination of key is pressed.
        private void dgvExamDetails_KeyPress(object sender, KeyPressEventArgs e)
        {
            char key = e.KeyChar;

            // If "Ctrl + D" is pressed and a row is selected.
            if (Convert.ToInt32(key) == 4 && dgvExamDetails.SelectedRows.Count > 0)
            {
                var result = MessageBox.Show("Are you sure you want to delete this record?", "DELETE?", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    int selectedRow = dgvExamDetails.SelectedRows[0].Index;
                    int recordId = Convert.ToInt32(dgvExamDetails.Rows[selectedRow].Cells[0].Value);
                    bool delResult = examDataService.DeleteRecord(recordId, DatabaseTable.Exam);
                    LoadData();

                    if (!delResult)
                    {
                        ApplicationSettingData.Setting.Helper.ShowMessage("There was a problem in deleting the record. Please check log file.", DialogTitles.Fail);
                    }
                }
            }
        }

        private void btnUpdateExam_Click(object sender, EventArgs e)
        {
            if (selectedRecord != -1)
            {
                if (ValidateExamData())
                {
                    string examName = tbExamName.Text;
                    Dictionary<string, object> data = new Dictionary<string, object>();
                    data[TableColumns.EXAM_EXAM_NAME] = examName;

                    var result = examDataService.EditRecord(selectedRecord, data, DatabaseTable.Exam);

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
                    ApplicationSettingData.Setting.Helper.ShowMessage("Exam name cannot be empty.", DialogTitles.Error);
                }
            }
            else
            {
                ApplicationSettingData.Setting.Helper.ShowMessage("No record is selected.", DialogTitles.Error);
            }
        }
    }
}
