using ExamSyllabus.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamSyllabus
{
    public partial class SettingController : Form
    {
        public SettingController()
        {
            InitializeComponent();
            LoadSettings();
        }

        /// <summary>
        /// This method is used to load settings from the app config file.
        /// </summary>
        private void LoadSettings()
        {
            var settings = new ConnectionSettingsModel().GetSettings();

            if (settings != null)
            {
                if (settings.Port != 0)
                {
                    cbPort.Checked = true;
                    tbPort.Text = settings.Port.ToString();
                    tbPort.Enabled = true;
                }

                tbServer.Text = settings.Server;
                tbUsername.Text = settings.Username;
                tbPassword.Text = settings.Password;
            }
        }

        private void SettingController_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1.ParentForm.Show();
        }

        private void SettingController_Shown(object sender, EventArgs e)
        {
            Form1.ParentForm.Hide();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            tbServer.Text = string.Empty;
            tbPort.Text = string.Empty;
            tbUsername.Text = string.Empty;
            tbPassword.Text = string.Empty;
            cbPort.Checked = false;
            tbPort.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateData())
            {
                string server = tbServer.Text;
                int port = 0;
                string username = tbUsername.Text;
                string password = tbPassword.Text;

                if (cbPort.Checked)
                    port = Convert.ToInt32(tbPort.Text);

                var settings = new ConnectionSettingsModel
                {
                    Server = server,
                    Port = port,
                    Username = username,
                    Password = password
                };

                settings.SaveSettings();

                ApplicationSettingData.Setting.Helper.ShowMessage("Settings saved. Re-open application to see changes.", Service.DialogTitles.Info);
            }
            else
            {
                ApplicationSettingData.Setting.Helper.ShowMessage("Please check the data and try again.", Service.DialogTitles.Error);
            }
        }

        /// <summary>
        /// This method is used to validate form data.
        /// </summary>
        /// <returns></returns>
        private bool ValidateData()
        {
            bool status = false;

            if (!tbServer.Text.Equals(string.Empty))
            {
                if ((cbPort.Checked && !tbPort.Text.Equals(string.Empty)) || (!cbPort.Checked && tbPort.Text.Equals(string.Empty)))
                {
                    if (tbUsername.Text.Equals(string.Empty) == tbPassword.Text.Equals(string.Empty))
                    {
                        status = true;
                    }
                }
            }

            return status;
        } 

        private void cbPort_CheckedChanged(object sender, EventArgs e)
        {
            tbPort.Enabled = cbPort.Checked;
        }
    }
}
