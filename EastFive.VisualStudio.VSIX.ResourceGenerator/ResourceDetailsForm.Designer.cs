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
            this.btnCreateResource = new System.Windows.Forms.Button();
            this.lblResourceName = new System.Windows.Forms.Label();
            this.lblResourceNamePlural = new System.Windows.Forms.Label();
            this.txtResourceNamePlural = new System.Windows.Forms.TextBox();
            this.lblAPIProject = new System.Windows.Forms.Label();
            this.lblBusinessProject = new System.Windows.Forms.Label();
            this.lblPersistenceProject = new System.Windows.Forms.Label();
            this.lblTestProject = new System.Windows.Forms.Label();
            this.cboAPI = new System.Windows.Forms.ComboBox();
            this.cboBusiness = new System.Windows.Forms.ComboBox();
            this.cboPersistence = new System.Windows.Forms.ComboBox();
            this.cboAPITest = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtResourceNameVariable = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtParameterNameJson = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtParameterNameVariablePlural = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAddParamter = new System.Windows.Forms.Button();
            this.lstParameterInfo = new System.Windows.Forms.ListBox();
            this.cboParameterType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtParameterNameVariable = new System.Windows.Forms.TextBox();
            this.lbl4 = new System.Windows.Forms.Label();
            this.txtParameterName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtResourceName
            // 
            this.txtResourceName.Location = new System.Drawing.Point(260, 22);
            this.txtResourceName.Name = "txtResourceName";
            this.txtResourceName.Size = new System.Drawing.Size(212, 20);
            this.txtResourceName.TabIndex = 4;
            // 
            // btnCreateResource
            // 
            this.btnCreateResource.Location = new System.Drawing.Point(389, 668);
            this.btnCreateResource.Name = "btnCreateResource";
            this.btnCreateResource.Size = new System.Drawing.Size(114, 33);
            this.btnCreateResource.TabIndex = 15;
            this.btnCreateResource.Text = "Create Resource";
            this.btnCreateResource.UseVisualStyleBackColor = true;
            this.btnCreateResource.Click += new System.EventHandler(this.btnCreateResource_Click);
            // 
            // lblResourceName
            // 
            this.lblResourceName.AutoSize = true;
            this.lblResourceName.Location = new System.Drawing.Point(45, 22);
            this.lblResourceName.Name = "lblResourceName";
            this.lblResourceName.Size = new System.Drawing.Size(153, 13);
            this.lblResourceName.TabIndex = 2;
            this.lblResourceName.Text = "Resource Name (MyResource)";
            // 
            // lblResourceNamePlural
            // 
            this.lblResourceNamePlural.AutoSize = true;
            this.lblResourceNamePlural.Location = new System.Drawing.Point(11, 74);
            this.lblResourceNamePlural.Name = "lblResourceNamePlural";
            this.lblResourceNamePlural.Size = new System.Drawing.Size(187, 13);
            this.lblResourceNamePlural.TabIndex = 4;
            this.lblResourceNamePlural.Text = "Resource Name Plural (MyResources)";
            // 
            // txtResourceNamePlural
            // 
            this.txtResourceNamePlural.Location = new System.Drawing.Point(260, 71);
            this.txtResourceNamePlural.Name = "txtResourceNamePlural";
            this.txtResourceNamePlural.Size = new System.Drawing.Size(212, 20);
            this.txtResourceNamePlural.TabIndex = 6;
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
            this.cboAPI.TabIndex = 0;
            // 
            // cboBusiness
            // 
            this.cboBusiness.FormattingEnabled = true;
            this.cboBusiness.Location = new System.Drawing.Point(76, 52);
            this.cboBusiness.Name = "cboBusiness";
            this.cboBusiness.Size = new System.Drawing.Size(396, 21);
            this.cboBusiness.TabIndex = 1;
            // 
            // cboPersistence
            // 
            this.cboPersistence.FormattingEnabled = true;
            this.cboPersistence.Location = new System.Drawing.Point(76, 83);
            this.cboPersistence.Name = "cboPersistence";
            this.cboPersistence.Size = new System.Drawing.Size(396, 21);
            this.cboPersistence.TabIndex = 2;
            // 
            // cboAPITest
            // 
            this.cboAPITest.FormattingEnabled = true;
            this.cboAPITest.Location = new System.Drawing.Point(76, 114);
            this.cboAPITest.Name = "cboAPITest";
            this.cboAPITest.Size = new System.Drawing.Size(396, 21);
            this.cboAPITest.TabIndex = 3;
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
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(491, 152);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Projects";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtResourceNameVariable);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtResourceName);
            this.groupBox2.Controls.Add(this.lblResourceName);
            this.groupBox2.Controls.Add(this.lblResourceNamePlural);
            this.groupBox2.Controls.Add(this.txtResourceNamePlural);
            this.groupBox2.Location = new System.Drawing.Point(12, 179);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(491, 120);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Resource Name Substitutions";
            // 
            // txtResourceNameVariable
            // 
            this.txtResourceNameVariable.Location = new System.Drawing.Point(260, 45);
            this.txtResourceNameVariable.Name = "txtResourceNameVariable";
            this.txtResourceNameVariable.Size = new System.Drawing.Size(212, 20);
            this.txtResourceNameVariable.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Resource Name Variable (myResource)";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtParameterNameJson);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txtParameterNameVariablePlural);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.btnAddParamter);
            this.groupBox3.Controls.Add(this.lstParameterInfo);
            this.groupBox3.Controls.Add(this.cboParameterType);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.txtParameterNameVariable);
            this.groupBox3.Controls.Add(this.lbl4);
            this.groupBox3.Controls.Add(this.txtParameterName);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(16, 321);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(486, 341);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Parameter Information";
            // 
            // txtParameterNameJson
            // 
            this.txtParameterNameJson.Location = new System.Drawing.Point(256, 99);
            this.txtParameterNameJson.Name = "txtParameterNameJson";
            this.txtParameterNameJson.Size = new System.Drawing.Size(213, 20);
            this.txtParameterNameJson.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(42, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(200, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Parameter Name Json (this_is_my_name)";
            // 
            // txtParameterNameVariablePlural
            // 
            this.txtParameterNameVariablePlural.Location = new System.Drawing.Point(256, 73);
            this.txtParameterNameVariablePlural.Name = "txtParameterNameVariablePlural";
            this.txtParameterNameVariablePlural.Size = new System.Drawing.Size(213, 20);
            this.txtParameterNameVariablePlural.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(196, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Parameter Name Variable Plural (names)";
            // 
            // btnAddParamter
            // 
            this.btnAddParamter.Location = new System.Drawing.Point(393, 169);
            this.btnAddParamter.Name = "btnAddParamter";
            this.btnAddParamter.Size = new System.Drawing.Size(75, 23);
            this.btnAddParamter.TabIndex = 12;
            this.btnAddParamter.Text = "Add";
            this.btnAddParamter.UseVisualStyleBackColor = true;
            this.btnAddParamter.Click += new System.EventHandler(this.btnAddParamter_Click);
            // 
            // lstParameterInfo
            // 
            this.lstParameterInfo.FormattingEnabled = true;
            this.lstParameterInfo.Location = new System.Drawing.Point(16, 218);
            this.lstParameterInfo.Name = "lstParameterInfo";
            this.lstParameterInfo.Size = new System.Drawing.Size(453, 108);
            this.lstParameterInfo.TabIndex = 13;
            // 
            // cboParameterType
            // 
            this.cboParameterType.FormattingEnabled = true;
            this.cboParameterType.ItemHeight = 13;
            this.cboParameterType.Location = new System.Drawing.Point(256, 122);
            this.cboParameterType.Name = "cboParameterType";
            this.cboParameterType.Size = new System.Drawing.Size(213, 21);
            this.cboParameterType.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Parameter Type";
            // 
            // txtParameterNameVariable
            // 
            this.txtParameterNameVariable.Location = new System.Drawing.Point(256, 45);
            this.txtParameterNameVariable.Name = "txtParameterNameVariable";
            this.txtParameterNameVariable.Size = new System.Drawing.Size(212, 20);
            this.txtParameterNameVariable.TabIndex = 8;
            // 
            // lbl4
            // 
            this.lbl4.AutoSize = true;
            this.lbl4.Location = new System.Drawing.Point(41, 45);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(162, 13);
            this.lbl4.TabIndex = 10;
            this.lbl4.Text = "Parameter Name Variable (name)";
            // 
            // txtParameterName
            // 
            this.txtParameterName.Location = new System.Drawing.Point(256, 19);
            this.txtParameterName.Name = "txtParameterName";
            this.txtParameterName.Size = new System.Drawing.Size(212, 20);
            this.txtParameterName.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Parameter Name (Name)";
            // 
            // ResourceDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 713);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCreateResource);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ResourceDetailsForm";
            this.Text = "East Five Resource Generator";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtResourceName;
        private System.Windows.Forms.Button btnCreateResource;
        private System.Windows.Forms.Label lblResourceName;
        private System.Windows.Forms.Label lblResourceNamePlural;
        private System.Windows.Forms.TextBox txtResourceNamePlural;
        private System.Windows.Forms.Label lblAPIProject;
        protected System.Windows.Forms.Label lblBusinessProject;
        protected System.Windows.Forms.Label lblPersistenceProject;
        protected System.Windows.Forms.Label lblTestProject;
        private System.Windows.Forms.ComboBox cboAPI;
        private System.Windows.Forms.ComboBox cboBusiness;
        private System.Windows.Forms.ComboBox cboPersistence;
        private System.Windows.Forms.ComboBox cboAPITest;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtResourceNameVariable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtParameterNameVariable;
        private System.Windows.Forms.Label lbl4;
        private System.Windows.Forms.TextBox txtParameterName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboParameterType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAddParamter;
        private System.Windows.Forms.ListBox lstParameterInfo;
        private System.Windows.Forms.TextBox txtParameterNameVariablePlural;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtParameterNameJson;
        private System.Windows.Forms.Label label5;
    }
}