namespace ExamSyllabus
{
    partial class RelationshipController
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RelationshipController));
            this.btnReset = new System.Windows.Forms.Button();
            this.btnAddRelationship = new System.Windows.Forms.Button();
            this.cbSubjectList = new System.Windows.Forms.ComboBox();
            this.lbExamList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbTopicsList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(253, 347);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 30);
            this.btnReset.TabIndex = 0;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnAddRelationship
            // 
            this.btnAddRelationship.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddRelationship.Location = new System.Drawing.Point(172, 347);
            this.btnAddRelationship.Name = "btnAddRelationship";
            this.btnAddRelationship.Size = new System.Drawing.Size(75, 30);
            this.btnAddRelationship.TabIndex = 1;
            this.btnAddRelationship.Text = "Save";
            this.btnAddRelationship.UseVisualStyleBackColor = true;
            this.btnAddRelationship.Click += new System.EventHandler(this.btnAddRelationship_Click);
            // 
            // cbSubjectList
            // 
            this.cbSubjectList.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbSubjectList.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbSubjectList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSubjectList.FormattingEnabled = true;
            this.cbSubjectList.Location = new System.Drawing.Point(172, 68);
            this.cbSubjectList.Name = "cbSubjectList";
            this.cbSubjectList.Size = new System.Drawing.Size(245, 24);
            this.cbSubjectList.TabIndex = 2;
            this.cbSubjectList.SelectedIndexChanged += new System.EventHandler(this.cbSubjectList_SelectedIndexChanged);
            // 
            // lbExamList
            // 
            this.lbExamList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbExamList.FormattingEnabled = true;
            this.lbExamList.ItemHeight = 16;
            this.lbExamList.Location = new System.Drawing.Point(172, 228);
            this.lbExamList.Name = "lbExamList";
            this.lbExamList.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbExamList.Size = new System.Drawing.Size(245, 84);
            this.lbExamList.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(33, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Subject";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(33, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Topic";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(33, 228);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Associated Exams";
            // 
            // lbTopicsList
            // 
            this.lbTopicsList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTopicsList.FormattingEnabled = true;
            this.lbTopicsList.ItemHeight = 16;
            this.lbTopicsList.Location = new System.Drawing.Point(172, 117);
            this.lbTopicsList.Name = "lbTopicsList";
            this.lbTopicsList.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbTopicsList.Size = new System.Drawing.Size(245, 84);
            this.lbTopicsList.TabIndex = 8;
            // 
            // RelationshipController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 454);
            this.Controls.Add(this.lbTopicsList);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbExamList);
            this.Controls.Add(this.cbSubjectList);
            this.Controls.Add(this.btnAddRelationship);
            this.Controls.Add(this.btnReset);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RelationshipController";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Relationship";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RelationshipController_FormClosing);
            this.Shown += new System.EventHandler(this.RelationshipController_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnAddRelationship;
        private System.Windows.Forms.ComboBox cbSubjectList;
        private System.Windows.Forms.ListBox lbExamList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lbTopicsList;
    }
}