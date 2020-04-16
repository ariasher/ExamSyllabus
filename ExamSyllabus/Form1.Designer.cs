using System.Windows.Forms;

namespace ExamSyllabus
{
    partial class Form1
    {
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem examToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem subjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem topicToolStripMenuItem;
        private ComboBox cbExamList;
        private ComboBox cbSubjectList;
        private Panel panel1;
        private Button btnReset;
        private Button btnSearch;
        private Label label2;
        private Label label1;
        private Panel panel2;
        private DataGridView dgvSyllabusDetails;
        private Button btnAddRelation;
        private ToolTip ttAddRelationship;

        public static new Form1 ParentForm;

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.examToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.topicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbExamList = new System.Windows.Forms.ComboBox();
            this.cbSubjectList = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAddRelation = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvSyllabusDetails = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubjectName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TopicName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExamName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ttAddRelationship = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSyllabusDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(884, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.examToolStripMenuItem,
            this.subjectToolStripMenuItem,
            this.topicToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // examToolStripMenuItem
            // 
            this.examToolStripMenuItem.Name = "examToolStripMenuItem";
            this.examToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.examToolStripMenuItem.Text = "Exam";
            this.examToolStripMenuItem.Click += new System.EventHandler(this.examToolStripMenuItem_Click);
            // 
            // subjectToolStripMenuItem
            // 
            this.subjectToolStripMenuItem.Name = "subjectToolStripMenuItem";
            this.subjectToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.subjectToolStripMenuItem.Text = "Subject";
            this.subjectToolStripMenuItem.Click += new System.EventHandler(this.subjectToolStripMenuItem_Click);
            // 
            // topicToolStripMenuItem
            // 
            this.topicToolStripMenuItem.Name = "topicToolStripMenuItem";
            this.topicToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.topicToolStripMenuItem.Text = "Topic";
            this.topicToolStripMenuItem.Click += new System.EventHandler(this.topicToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // cbExamList
            // 
            this.cbExamList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbExamList.FormattingEnabled = true;
            this.cbExamList.Location = new System.Drawing.Point(52, 13);
            this.cbExamList.Name = "cbExamList";
            this.cbExamList.Size = new System.Drawing.Size(202, 24);
            this.cbExamList.TabIndex = 1;
            // 
            // cbSubjectList
            // 
            this.cbSubjectList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSubjectList.FormattingEnabled = true;
            this.cbSubjectList.Location = new System.Drawing.Point(333, 13);
            this.cbSubjectList.Name = "cbSubjectList";
            this.cbSubjectList.Size = new System.Drawing.Size(202, 24);
            this.cbSubjectList.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnAddRelation);
            this.panel1.Controls.Add(this.cbSubjectList);
            this.panel1.Controls.Add(this.btnReset);
            this.panel1.Controls.Add(this.cbExamList);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(860, 51);
            this.panel1.TabIndex = 3;
            // 
            // btnAddRelation
            // 
            this.btnAddRelation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddRelation.Image = global::ExamSyllabus.Properties.Resources.icons8_add_30;
            this.btnAddRelation.Location = new System.Drawing.Point(817, 10);
            this.btnAddRelation.Name = "btnAddRelation";
            this.btnAddRelation.Size = new System.Drawing.Size(32, 32);
            this.btnAddRelation.TabIndex = 4;
            this.ttAddRelationship.SetToolTip(this.btnAddRelation, "Add relationship between exam and topic.");
            this.btnAddRelation.UseVisualStyleBackColor = true;
            this.btnAddRelation.Click += new System.EventHandler(this.btnAddRelation_Click);
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(622, 10);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 30);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(541, 10);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 30);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(272, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Subject";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Exam";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvSyllabusDetails);
            this.panel2.Location = new System.Drawing.Point(12, 84);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(860, 466);
            this.panel2.TabIndex = 4;
            // 
            // dgvSyllabusDetails
            // 
            this.dgvSyllabusDetails.AllowUserToAddRows = false;
            this.dgvSyllabusDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSyllabusDetails.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvSyllabusDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSyllabusDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.SubjectName,
            this.TopicName,
            this.ExamName});
            this.dgvSyllabusDetails.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.dgvSyllabusDetails.Location = new System.Drawing.Point(3, 3);
            this.dgvSyllabusDetails.Name = "dgvSyllabusDetails";
            this.dgvSyllabusDetails.ReadOnly = true;
            this.dgvSyllabusDetails.Size = new System.Drawing.Size(854, 460);
            this.dgvSyllabusDetails.TabIndex = 0;
            this.dgvSyllabusDetails.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvSyllabusDetails_KeyPress);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // SubjectName
            // 
            this.SubjectName.DataPropertyName = "SubjectName";
            this.SubjectName.HeaderText = "Subjects";
            this.SubjectName.Name = "SubjectName";
            this.SubjectName.ReadOnly = true;
            // 
            // TopicName
            // 
            this.TopicName.DataPropertyName = "TopicName";
            this.TopicName.HeaderText = "Topics";
            this.TopicName.Name = "TopicName";
            this.TopicName.ReadOnly = true;
            // 
            // ExamName
            // 
            this.ExamName.DataPropertyName = "ExamName";
            this.ExamName.HeaderText = "Exams";
            this.ExamName.Name = "ExamName";
            this.ExamName.ReadOnly = true;
            // 
            // ttAddRelationship
            // 
            this.ttAddRelationship.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttAddRelationship.ToolTipTitle = "Add Relationship";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 562);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ExamSyllabus";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSyllabusDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private void examToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            new ExamController().Show();
        }

        private void subjectToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            new SubjectController().Show();
        }

        private void topicToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            new TopicController().Show();
        }

        private void btnAddRelation_Click(object sender, System.EventArgs e)
        {
            new RelationshipController().Show();
        }

        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn SubjectName;
        private DataGridViewTextBoxColumn TopicName;
        private DataGridViewTextBoxColumn ExamName;
        private ToolStripMenuItem settingsToolStripMenuItem;
    }
}

