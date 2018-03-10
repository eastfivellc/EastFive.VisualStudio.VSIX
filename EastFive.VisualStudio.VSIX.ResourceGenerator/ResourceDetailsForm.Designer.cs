namespace EastFive.VisualStudio.VSIX.ResourceGenerator
{
    partial class ResourceDetailsForm
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
            this.txtResourceName = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lblResourceName = new System.Windows.Forms.Label();
            this.lblResourceNamePlural = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblAPIProject = new System.Windows.Forms.Label();
            this.lblBusinessProject = new System.Windows.Forms.Label();
            this.lblPersistenceProject = new System.Windows.Forms.Label();
            this.lblTestProject = new System.Windows.Forms.Label();
            this.cboAPI = new System.Windows.Forms.ComboBox();
            this.cboBusiness = new System.Windows.Forms.ComboBox();
            this.cboPersistence = new System.Windows.Forms.ComboBox();
            this.cboAPITest = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtResourceName
            // 
            this.txtResourceName.Location = new System.Drawing.Point(139, 14);
            this.txtResourceName.Name = "txtResourceName";
            this.txtResourceName.Size = new System.Drawing.Size(212, 20);
            this.txtResourceName.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(612, 329);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 49);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblResourceName
            // 
            this.lblResourceName.AutoSize = true;
            this.lblResourceName.Location = new System.Drawing.Point(14, 14);
            this.lblResourceName.Name = "lblResourceName";
            this.lblResourceName.Size = new System.Drawing.Size(84, 13);
            this.lblResourceName.TabIndex = 2;
            this.lblResourceName.Text = "Resource Name";
            // 
            // lblResourceNamePlural
            // 
            this.lblResourceNamePlural.AutoSize = true;
            this.lblResourceNamePlural.Location = new System.Drawing.Point(14, 51);
            this.lblResourceNamePlural.Name = "lblResourceNamePlural";
            this.lblResourceNamePlural.Size = new System.Drawing.Size(119, 13);
            this.lblResourceNamePlural.TabIndex = 4;
            this.lblResourceNamePlural.Text = "Resource Name (Plural)";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(139, 48);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(212, 20);
            this.textBox1.TabIndex = 3;
            // 
            // lblAPIProject
            // 
            this.lblAPIProject.AutoSize = true;
            this.lblAPIProject.Location = new System.Drawing.Point(46, 22);
            this.lblAPIProject.Name = "lblAPIProject";
            this.lblAPIProject.Size = new System.Drawing.Size(24, 13);
            this.lblAPIProject.TabIndex = 5;
            this.lblAPIProject.Text = "API";
            // 
            // lblBusinessProject
            // 
            this.lblBusinessProject.AutoSize = true;
            this.lblBusinessProject.Location = new System.Drawing.Point(21, 55);
            this.lblBusinessProject.Name = "lblBusinessProject";
            this.lblBusinessProject.Size = new System.Drawing.Size(49, 13);
            this.lblBusinessProject.TabIndex = 6;
            this.lblBusinessProject.Text = "Business";
            // 
            // lblPersistenceProject
            // 
            this.lblPersistenceProject.AutoSize = true;
            this.lblPersistenceProject.Location = new System.Drawing.Point(8, 86);
            this.lblPersistenceProject.Name = "lblPersistenceProject";
            this.lblPersistenceProject.Size = new System.Drawing.Size(62, 13);
            this.lblPersistenceProject.TabIndex = 7;
            this.lblPersistenceProject.Text = "Persistence";
            // 
            // lblTestProject
            // 
            this.lblTestProject.AutoSize = true;
            this.lblTestProject.Location = new System.Drawing.Point(21, 117);
            this.lblTestProject.Name = "lblTestProject";
            this.lblTestProject.Size = new System.Drawing.Size(48, 13);
            this.lblTestProject.TabIndex = 8;
            this.lblTestProject.Text = "API Test";
            // 
            // cboAPI
            // 
            this.cboAPI.FormattingEnabled = true;
            this.cboAPI.Location = new System.Drawing.Point(76, 19);
            this.cboAPI.Name = "cboAPI";
            this.cboAPI.Size = new System.Drawing.Size(396, 21);
            this.cboAPI.TabIndex = 9;
            // 
            // cboBusiness
            // 
            this.cboBusiness.FormattingEnabled = true;
            this.cboBusiness.Location = new System.Drawing.Point(76, 52);
            this.cboBusiness.Name = "cboBusiness";
            this.cboBusiness.Size = new System.Drawing.Size(396, 21);
            this.cboBusiness.TabIndex = 10;
            // 
            // cboPersistence
            // 
            this.cboPersistence.FormattingEnabled = true;
            this.cboPersistence.Location = new System.Drawing.Point(76, 83);
            this.cboPersistence.Name = "cboPersistence";
            this.cboPersistence.Size = new System.Drawing.Size(396, 21);
            this.cboPersistence.TabIndex = 11;
            // 
            // cboAPITest
            // 
            this.cboAPITest.FormattingEnabled = true;
            this.cboAPITest.Location = new System.Drawing.Point(76, 114);
            this.cboAPITest.Name = "cboAPITest";
            this.cboAPITest.Size = new System.Drawing.Size(396, 21);
            this.cboAPITest.TabIndex = 12;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboAPI);
            this.groupBox1.Controls.Add(this.cboAPITest);
            this.groupBox1.Controls.Add(this.lblAPIProject);
            this.groupBox1.Controls.Add(this.cboPersistence);
            this.groupBox1.Controls.Add(this.lblBusinessProject);
            this.groupBox1.Controls.Add(this.cboBusiness);
            this.groupBox1.Controls.Add(this.lblPersistenceProject);
            this.groupBox1.Controls.Add(this.lblTestProject);
            this.groupBox1.Location = new System.Drawing.Point(17, 90);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(491, 152);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Projects";
            // 
            // ResourceDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblResourceNamePlural);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblResourceName);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtResourceName);
            this.Name = "ResourceDetailsForm";
            this.Text = "East Five Resource Generator";
            this.Load += new System.EventHandler(this.ResourceDetailsForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtResourceName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblResourceName;
        private System.Windows.Forms.Label lblResourceNamePlural;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblAPIProject;
        protected System.Windows.Forms.Label lblBusinessProject;
        protected System.Windows.Forms.Label lblPersistenceProject;
        protected System.Windows.Forms.Label lblTestProject;
        private System.Windows.Forms.ComboBox cboAPI;
        private System.Windows.Forms.ComboBox cboBusiness;
        private System.Windows.Forms.ComboBox cboPersistence;
        private System.Windows.Forms.ComboBox cboAPITest;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}