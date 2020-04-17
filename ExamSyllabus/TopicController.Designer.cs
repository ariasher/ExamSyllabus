namespace ExamSyllabus
{
    partial class TopicController
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TopicController));
            this.tabber = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvTopicDetails = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TopicName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubjectName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lbExamList = new System.Windows.Forms.ListBox();
            this.btnUpdateTopic = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnAddTopic = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbSubjectList = new System.Windows.Forms.ComboBox();
            this.tbTopicName = new System.Windows.Forms.TextBox();
            this.tabber.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopicDetails)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabber
            // 
            this.tabber.Controls.Add(this.tabPage1);
            this.tabber.Controls.Add(this.tabPage2);
            this.tabber.Location = new System.Drawing.Point(12, 12);
            this.tabber.Name = "tabber";
            this.tabber.SelectedIndex = 0;
            this.tabber.Size = new System.Drawing.Size(431, 430);
            this.tabber.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvTopicDetails);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(423, 404);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "View";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvTopicDetails
            // 
            this.dgvTopicDetails.AllowUserToAddRows = false;
            this.dgvTopicDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTopicDetails.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvTopicDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTopicDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.TopicName,
            this.SubjectName});
            this.dgvTopicDetails.Location = new System.Drawing.Point(3, 3);
            this.dgvTopicDetails.MultiSelect = false;
            this.dgvTopicDetails.Name = "dgvTopicDetails";
            this.dgvTopicDetails.Size = new System.Drawing.Size(417, 398);
            this.dgvTopicDetails.TabIndex = 0;
            this.dgvTopicDetails.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvTopicDetails_CellMouseDoubleClick);
            this.dgvTopicDetails.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvTopicDetails_KeyPress);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // TopicName
            // 
            this.TopicName.DataPropertyName = "TopicName";
            this.TopicName.HeaderText = "Topics";
            this.TopicName.Name = "TopicName";
            this.TopicName.ReadOnly = true;
            // 
            // SubjectName
            // 
            this.SubjectName.DataPropertyName = "SubjectName";
            this.SubjectName.HeaderText = "Subjects";
            this.SubjectName.Name = "SubjectName";
            this.SubjectName.ReadOnly = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lbExamList);
            this.tabPage2.Controls.Add(this.btnUpdateTopic);
            this.tabPage2.Controls.Add(this.btnClear);
            this.tabPage2.Controls.Add(this.btnAddTopic);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.cbSubjectList);
            this.tabPage2.Controls.Add(this.tbTopicName);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(423, 404);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Add";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lbExamList
            // 
            this.lbExamList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbExamList.FormattingEnabled = true;
            this.lbExamList.ItemHeight = 16;
            this.lbExamList.Location = new System.Drawing.Point(154, 174);
            this.lbExamList.Name = "lbExamList";
            this.lbExamList.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbExamList.Size = new System.Drawing.Size(245, 84);
            this.lbExamList.TabIndex = 10;
            // 
            // btnUpdateTopic
            // 
            this.btnUpdateTopic.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateTopic.Location = new System.Drawing.Point(316, 292);
            this.btnUpdateTopic.Name = "btnUpdateTopic";
            this.btnUpdateTopic.Size = new System.Drawing.Size(75, 30);
            this.btnUpdateTopic.TabIndex = 9;
            this.btnUpdateTopic.Text = "Update";
            this.btnUpdateTopic.UseVisualStyleBackColor = true;
            this.btnUpdateTopic.Visible = false;
            this.btnUpdateTopic.Click += new System.EventHandler(this.btnUpdateTopic_Click);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(235, 292);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 30);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnAddTopic
            // 
            this.btnAddTopic.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddTopic.Location = new System.Drawing.Point(154, 292);
            this.btnAddTopic.Name = "btnAddTopic";
            this.btnAddTopic.Size = new System.Drawing.Size(75, 30);
            this.btnAddTopic.TabIndex = 7;
            this.btnAddTopic.Text = "Save";
            this.btnAddTopic.UseVisualStyleBackColor = true;
            this.btnAddTopic.Click += new System.EventHandler(this.btnAddTopic_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Associated Exams";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Topic Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Subject";
            // 
            // cbSubjectList
            // 
            this.cbSubjectList.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbSubjectList.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbSubjectList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSubjectList.FormattingEnabled = true;
            this.cbSubjectList.Location = new System.Drawing.Point(154, 76);
            this.cbSubjectList.Name = "cbSubjectList";
            this.cbSubjectList.Size = new System.Drawing.Size(245, 24);
            this.cbSubjectList.TabIndex = 2;
            // 
            // tbTopicName
            // 
            this.tbTopicName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTopicName.Location = new System.Drawing.Point(154, 125);
            this.tbTopicName.Name = "tbTopicName";
            this.tbTopicName.Size = new System.Drawing.Size(245, 23);
            this.tbTopicName.TabIndex = 1;
            // 
            // TopicController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 454);
            this.Controls.Add(this.tabber);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TopicController";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Topic Details";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TopicController_FormClosing);
            this.Shown += new System.EventHandler(this.TopicController_Shown);
            this.tabber.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopicDetails)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabber;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dgvTopicDetails;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnAddTopic;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbSubjectList;
        private System.Windows.Forms.TextBox tbTopicName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn TopicName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubjectName;
        private System.Windows.Forms.Button btnUpdateTopic;
        private System.Windows.Forms.ListBox lbExamList;
    }
}