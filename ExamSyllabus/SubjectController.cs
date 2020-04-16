using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExamSyllabus.Service;
using ExamSyllabus.Model;

namespace ExamSyllabus
{
    public partial class SubjectController : Form
    {
        private IDataService<SubjectModel> subjectDataService;
        int selectedRecord = -1;

        public SubjectController()
        {
            InitializeComponent();
            subjectDataService = new DataService<SubjectModel>();
            LoadData();
        }

        /// <summary>
        /// This method is used to load the exam data in the table.
        /// </summary>
        private void LoadData()
        {
            DataTable data = subjectDataService.GetRecords(DatabaseTable.Subject);

            // Convert datatable data to a list, sort it by name.
            List<SubjectModel> modelData = (from DataRow row in data.Rows
                                         select new SubjectModel
                                         {
                                             Deleted = Convert.ToBoolean(row[TableColumns.COMMON_DELETED]),
                                             Id = Convert.ToInt32(row[TableColumns.COMMON_ID]),
                                             SubjectName = row[TableColumns.SUBJECT_SUBJECT_NAME].ToString()
                                         })
                                         .ToList();

            modelData = modelData.OrderBy(x => x.SubjectName).ToList();

            dgvSubjectDetails.AutoGenerateColumns = false;
            dgvSubjectDetails.DataSource = modelData;
        }

        private void SubjectController_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1.ParentForm.RefreshData();
            Form1.ParentForm.Show();
        }

        private void SubjectController_Shown(object sender, EventArgs e)
        {
            Form1.ParentForm.Hide();
        }

        private void btnAddSubject_Click(object sender, EventArgs e)
        {
            if (ValidateExamData())
            {
                var subjectName = tbSubjectName.Text;
                Dictionary<string, object> data = new Dictionary<string, object>();
                data[TableColumns.SUBJECT_SUBJECT_NAME] = subjectName;
                bool result = subjectDataService.SaveRecord(data, DatabaseTable.Subject);

                if (result)
                {
                    ApplicationSettingData.Setting.Helper.ShowMessage("Subject data saved successfully.", DialogTitles.Success);
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
                ApplicationSettingData.Setting.Helper.ShowMessage("Subject name cannot be empty.", DialogTitles.Error);
            }
        }

        /// <summary>
        /// This method is used to validate the content of the form.
        /// </summary>
        /// <returns>Returns the status of the form validation - true or false.</returns>
        private bool ValidateExamData()
        {
            return !string.IsNullOrEmpty(tbSubjectName.Text);
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
            tbSubjectName.Text = string.Empty;
        }

        private void btnUpdateSubject_Click(object sender, EventArgs e)
        {
            if (selectedRecord != -1)
            {
                if (ValidateExamData())
                {
                    string subjectName = tbSubjectName.Text;
                    Dictionary<string, object> data = new Dictionary<string, object>();
                    data[TableColumns.SUBJECT_SUBJECT_NAME] = subjectName;

                    var result = subjectDataService.EditRecord(selectedRecord, data, DatabaseTable.Subject);

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
                    ApplicationSettingData.Setting.Helper.ShowMessage("Subject name cannot be empty.", DialogTitles.Error);
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
                btnAddSubject.Visible = false;
                btnUpdateSubject.Visible = true;
            }
            else
            {
                btnAddSubject.Visible = true;
                btnUpdateSubject.Visible = false;
                ClearData();
                selectedRecord = -1;
            }
        }

        // This event occurs when a mouse double clicks on a row. This event is used here for editing.
        private void dgvSubjectDetails_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Read cell and its metadata.
            var cells = dgvSubjectDetails.Rows[e.RowIndex].Cells;
            selectedRecord = Convert.ToInt32(cells[0].Value);
            string name = cells[1].Value.ToString();
            tbSubjectName.Text = name;

            EnableEditMode(true);
            tabber.SelectedIndex = 1;
        }

        // This event occurs when a key, or a combination of key is pressed.
        private void dgvSubjectDetails_KeyPress(object sender, KeyPressEventArgs e)
        {
            char key = e.KeyChar;

            // If "Ctrl + D" is pressed and a row is selected.
            if (Convert.ToInt32(key) == 4 && dgvSubjectDetails.SelectedRows.Count > 0)
            {
                var result = MessageBox.Show("Are you sure you want to delete this record?", "DELETE?", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    int selectedRow = dgvSubjectDetails.SelectedRows[0].Index;
                    int recordId = Convert.ToInt32(dgvSubjectDetails.Rows[selectedRow].Cells[0].Value);
                    bool delResult = subjectDataService.DeleteRecord(recordId, DatabaseTable.Subject);
                    LoadData();

                    if (!delResult)
                    {
                        ApplicationSettingData.Setting.Helper.ShowMessage("There was a problem in deleting the record. Please check log file.", DialogTitles.Fail);
                    }
                }
            }
        }
    }
}
