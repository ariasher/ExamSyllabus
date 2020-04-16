namespace ExamSyllabus
{
    partial class ExamController
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExamController));
            this.tabber = new System.Windows.Forms.TabControl();
            this.View = new System.Windows.Forms.TabPage();
            this.dgvExamDetails = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExamName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Add = new System.Windows.Forms.TabPage();
            this.btnUpdateExam = new System.Windows.Forms.Button();
            this.btnClearExam = new System.Windows.Forms.Button();
            this.btnSaveExam = new System.Windows.Forms.Button();
            this.tbExamName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabber.SuspendLayout();
            this.View.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExamDetails)).BeginInit();
            this.Add.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabber
            // 
            this.tabber.Controls.Add(this.View);
            this.tabber.Controls.Add(this.Add);
            this.tabber.Location = new System.Drawing.Point(12, 12);
            this.tabber.Name = "tabber";
            this.tabber.SelectedIndex = 0;
            this.tabber.Size = new System.Drawing.Size(431, 430);
            this.tabber.TabIndex = 0;
            // 
            // View
            // 
            this.View.Controls.Add(this.dgvExamDetails);
            this.View.Location = new System.Drawing.Point(4, 22);
            this.View.Name = "View";
            this.View.Padding = new System.Windows.Forms.Padding(3);
            this.View.Size = new System.Drawing.Size(423, 404);
            this.View.TabIndex = 0;
            this.View.Text = "View";
            this.View.UseVisualStyleBackColor = true;
            // 
            // dgvExamDetails
            // 
            this.dgvExamDetails.AllowUserToAddRows = false;
            this.dgvExamDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvExamDetails.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvExamDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExamDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.ExamName});
            this.dgvExamDetails.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.dgvExamDetails.Location = new System.Drawing.Point(0, 3);
            this.dgvExamDetails.Name = "dgvExamDetails";
            this.dgvExamDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvExamDetails.Size = new System.Drawing.Size(420, 400);
            this.dgvExamDetails.TabIndex = 0;
            this.dgvExamDetails.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvExamDetails_CellMouseDoubleClick);
            this.dgvExamDetails.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvExamDetails_KeyPress);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // ExamName
            // 
            this.ExamName.DataPropertyName = "ExamName";
            this.ExamName.HeaderText = "Exams";
            this.ExamName.Name = "ExamName";
            this.ExamName.ReadOnly = true;
            // 
            // Add
            // 
            this.Add.Controls.Add(this.btnUpdateExam);
            this.Add.Controls.Add(this.btnClearExam);
            this.Add.Controls.Add(this.btnSaveExam);
            this.Add.Controls.Add(this.tbExamName);
            this.Add.Controls.Add(this.label1);
            this.Add.Location = new System.Drawing.Point(4, 22);
            this.Add.Name = "Add";
            this.Add.Padding = new System.Windows.Forms.Padding(3);
            this.Add.Size = new System.Drawing.Size(423, 404);
            this.Add.TabIndex = 1;
            this.Add.Text = "Add";
            this.Add.UseVisualStyleBackColor = true;
            // 
            // btnUpdateExam
            // 
            this.btnUpdateExam.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateExam.Location = new System.Drawing.Point(295, 207);
            this.btnUpdateExam.Name = "btnUpdateExam";
            this.btnUpdateExam.Size = new System.Drawing.Size(75, 30);
            this.btnUpdateExam.TabIndex = 4;
            this.btnUpdateExam.Text = "Update";
            this.btnUpdateExam.UseVisualStyleBackColor = true;
            this.btnUpdateExam.Visible = false;
            this.btnUpdateExam.Click += new System.EventHandler(this.btnUpdateExam_Click);
            // 
            // btnClearExam
            // 
            this.btnClearExam.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearExam.Location = new System.Drawing.Point(214, 207);
            this.btnClearExam.Name = "btnClearExam";
            this.btnClearExam.Size = new System.Drawing.Size(75, 30);
            this.btnClearExam.TabIndex = 3;
            this.btnClearExam.Text = "Clear";
            this.btnClearExam.UseVisualStyleBackColor = true;
            this.btnClearExam.Click += new System.EventHandler(this.btnClearExam_Click);
            // 
            // btnSaveExam
            // 
            this.btnSaveExam.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveExam.Location = new System.Drawing.Point(133, 207);
            this.btnSaveExam.Name = "btnSaveExam";
            this.btnSaveExam.Size = new System.Drawing.Size(75, 30);
            this.btnSaveExam.TabIndex = 2;
            this.btnSaveExam.Text = "Save";
            this.btnSaveExam.UseVisualStyleBackColor = true;
            this.btnSaveExam.Click += new System.EventHandler(this.btnSaveExam_Click);
            // 
            // tbExamName
            // 
            this.tbExamName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbExamName.Location = new System.Drawing.Point(133, 153);
            this.tbExamName.Name = "tbExamName";
            this.tbExamName.Size = new System.Drawing.Size(245, 23);
            this.tbExamName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(44, 156);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Exam Name";
            // 
            // ExamController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 454);
            this.Controls.Add(this.tabber);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExamController";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Exam Details";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ExamController_FormClosing);
            this.Shown += new System.EventHandler(this.ExamController_Shown);
            this.tabber.ResumeLayout(false);
            this.View.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExamDetails)).EndInit();
            this.Add.ResumeLayout(false);
            this.Add.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabber;
        private System.Windows.Forms.TabPage View;
        private System.Windows.Forms.DataGridView dgvExamDetails;
        private System.Windows.Forms.TabPage Add;
        private System.Windows.Forms.Button btnClearExam;
        private System.Windows.Forms.Button btnSaveExam;
        private System.Windows.Forms.TextBox tbExamName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExamName;
        private System.Windows.Forms.Button btnUpdateExam;
    }
}