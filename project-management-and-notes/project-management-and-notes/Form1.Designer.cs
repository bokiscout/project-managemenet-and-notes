namespace project_management_and_notes
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnEditProject = new System.Windows.Forms.Button();
            this.btnDeleteProject = new System.Windows.Forms.Button();
            this.btnAddProject = new System.Windows.Forms.Button();
            this.lbProjects = new System.Windows.Forms.ListBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.cbSort = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gbLoginInfo = new System.Windows.Forms.GroupBox();
            this.btnDeleteLoginInfo = new System.Windows.Forms.Button();
            this.btnEdiLoginInfo = new System.Windows.Forms.Button();
            this.btnAddLoginInfo = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.cbLoginInfo = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbLoginInfoUsername = new System.Windows.Forms.TextBox();
            this.tbLoginInfoPassword = new System.Windows.Forms.TextBox();
            this.tbLoginInfoUrl = new System.Windows.Forms.TextBox();
            this.gbAssignments = new System.Windows.Forms.GroupBox();
            this.btnDeleteAssignment = new System.Windows.Forms.Button();
            this.clbAssignments = new System.Windows.Forms.CheckedListBox();
            this.btnEditAssignment = new System.Windows.Forms.Button();
            this.btnAddAssignment = new System.Windows.Forms.Button();
            this.tbProjectName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbClientName = new System.Windows.Forms.TextBox();
            this.tbStatus = new System.Windows.Forms.TextBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbDeadLine = new System.Windows.Forms.TextBox();
            this.tbStartDate = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnSearch = new System.Windows.Forms.Button();
            this.Search = new System.Windows.Forms.Label();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnEditCss = new System.Windows.Forms.Button();
            this.rtbCssCodeDetails = new System.Windows.Forms.RichTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnAddCssCode = new System.Windows.Forms.Button();
            this.lbCssCodes = new System.Windows.Forms.ListBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gbLoginInfo.SuspendLayout();
            this.gbAssignments.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnEditProject);
            this.groupBox1.Controls.Add(this.btnDeleteProject);
            this.groupBox1.Controls.Add(this.btnAddProject);
            this.groupBox1.Controls.Add(this.lbProjects);
            this.groupBox1.Location = new System.Drawing.Point(6, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(228, 438);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Projects";
            // 
            // btnEditProject
            // 
            this.btnEditProject.Enabled = false;
            this.btnEditProject.Location = new System.Drawing.Point(9, 380);
            this.btnEditProject.Name = "btnEditProject";
            this.btnEditProject.Size = new System.Drawing.Size(210, 23);
            this.btnEditProject.TabIndex = 3;
            this.btnEditProject.Text = "Edit Project";
            this.btnEditProject.UseVisualStyleBackColor = true;
            this.btnEditProject.Click += new System.EventHandler(this.btnEditProject_Click);
            // 
            // btnDeleteProject
            // 
            this.btnDeleteProject.Enabled = false;
            this.btnDeleteProject.Location = new System.Drawing.Point(9, 409);
            this.btnDeleteProject.Name = "btnDeleteProject";
            this.btnDeleteProject.Size = new System.Drawing.Size(210, 23);
            this.btnDeleteProject.TabIndex = 2;
            this.btnDeleteProject.Text = "Delete";
            this.btnDeleteProject.UseVisualStyleBackColor = true;
            this.btnDeleteProject.Click += new System.EventHandler(this.btnDeleteProject_Click);
            // 
            // btnAddProject
            // 
            this.btnAddProject.Location = new System.Drawing.Point(9, 351);
            this.btnAddProject.Name = "btnAddProject";
            this.btnAddProject.Size = new System.Drawing.Size(210, 23);
            this.btnAddProject.TabIndex = 1;
            this.btnAddProject.Text = "Create Project";
            this.btnAddProject.UseVisualStyleBackColor = true;
            this.btnAddProject.Click += new System.EventHandler(this.btnAddProject_Click);
            // 
            // lbProjects
            // 
            this.lbProjects.Location = new System.Drawing.Point(9, 19);
            this.lbProjects.Name = "lbProjects";
            this.lbProjects.Size = new System.Drawing.Size(210, 316);
            this.lbProjects.TabIndex = 0;
            this.lbProjects.SelectedIndexChanged += new System.EventHandler(this.lbProjects_SelectedIndexChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(1, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(796, 522);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.comboBox2);
            this.tabPage1.Controls.Add(this.cbSort);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(788, 496);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Projects";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Ascending",
            "Descending",
            "Completed",
            "..."});
            this.comboBox2.Location = new System.Drawing.Point(240, 21);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(148, 21);
            this.comboBox2.TabIndex = 4;
            // 
            // cbSort
            // 
            this.cbSort.FormattingEnabled = true;
            this.cbSort.Items.AddRange(new object[] {
            "Deadline",
            "Status"});
            this.cbSort.Location = new System.Drawing.Point(15, 21);
            this.cbSort.Name = "cbSort";
            this.cbSort.Size = new System.Drawing.Size(219, 21);
            this.cbSort.TabIndex = 3;
            this.cbSort.SelectedIndexChanged += new System.EventHandler(this.cbSort_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Sort by";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gbLoginInfo);
            this.groupBox2.Controls.Add(this.gbAssignments);
            this.groupBox2.Controls.Add(this.tbProjectName);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.tbClientName);
            this.groupBox2.Controls.Add(this.tbStatus);
            this.groupBox2.Controls.Add(this.linkLabel1);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.tbDeadLine);
            this.groupBox2.Controls.Add(this.tbStartDate);
            this.groupBox2.Location = new System.Drawing.Point(240, 51);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(538, 438);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Details";
            // 
            // gbLoginInfo
            // 
            this.gbLoginInfo.Controls.Add(this.btnDeleteLoginInfo);
            this.gbLoginInfo.Controls.Add(this.btnEdiLoginInfo);
            this.gbLoginInfo.Controls.Add(this.btnAddLoginInfo);
            this.gbLoginInfo.Controls.Add(this.label10);
            this.gbLoginInfo.Controls.Add(this.cbLoginInfo);
            this.gbLoginInfo.Controls.Add(this.label9);
            this.gbLoginInfo.Controls.Add(this.label8);
            this.gbLoginInfo.Controls.Add(this.label3);
            this.gbLoginInfo.Controls.Add(this.tbLoginInfoUsername);
            this.gbLoginInfo.Controls.Add(this.tbLoginInfoPassword);
            this.gbLoginInfo.Controls.Add(this.tbLoginInfoUrl);
            this.gbLoginInfo.Location = new System.Drawing.Point(13, 168);
            this.gbLoginInfo.Name = "gbLoginInfo";
            this.gbLoginInfo.Size = new System.Drawing.Size(279, 229);
            this.gbLoginInfo.TabIndex = 27;
            this.gbLoginInfo.TabStop = false;
            this.gbLoginInfo.Text = "LoginInfo";
            // 
            // btnDeleteLoginInfo
            // 
            this.btnDeleteLoginInfo.Enabled = false;
            this.btnDeleteLoginInfo.Location = new System.Drawing.Point(12, 198);
            this.btnDeleteLoginInfo.Name = "btnDeleteLoginInfo";
            this.btnDeleteLoginInfo.Size = new System.Drawing.Size(261, 23);
            this.btnDeleteLoginInfo.TabIndex = 33;
            this.btnDeleteLoginInfo.Text = "Delete Selected";
            this.btnDeleteLoginInfo.UseVisualStyleBackColor = true;
            this.btnDeleteLoginInfo.Click += new System.EventHandler(this.btnDeleteLoginInfo_Click);
            // 
            // btnEdiLoginInfo
            // 
            this.btnEdiLoginInfo.Enabled = false;
            this.btnEdiLoginInfo.Location = new System.Drawing.Point(12, 169);
            this.btnEdiLoginInfo.Name = "btnEdiLoginInfo";
            this.btnEdiLoginInfo.Size = new System.Drawing.Size(261, 23);
            this.btnEdiLoginInfo.TabIndex = 32;
            this.btnEdiLoginInfo.Text = "Edit Selected";
            this.btnEdiLoginInfo.UseVisualStyleBackColor = true;
            this.btnEdiLoginInfo.Click += new System.EventHandler(this.btnEdiLoginInfo_Click);
            // 
            // btnAddLoginInfo
            // 
            this.btnAddLoginInfo.Enabled = false;
            this.btnAddLoginInfo.Location = new System.Drawing.Point(12, 140);
            this.btnAddLoginInfo.Name = "btnAddLoginInfo";
            this.btnAddLoginInfo.Size = new System.Drawing.Size(261, 23);
            this.btnAddLoginInfo.TabIndex = 31;
            this.btnAddLoginInfo.Text = "Add New login Information";
            this.btnAddLoginInfo.UseVisualStyleBackColor = true;
            this.btnAddLoginInfo.Click += new System.EventHandler(this.btnAddLoginInfo_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 13);
            this.label10.TabIndex = 30;
            this.label10.Text = "Show info for:";
            // 
            // cbLoginInfo
            // 
            this.cbLoginInfo.FormattingEnabled = true;
            this.cbLoginInfo.Location = new System.Drawing.Point(92, 19);
            this.cbLoginInfo.Name = "cbLoginInfo";
            this.cbLoginInfo.Size = new System.Drawing.Size(181, 21);
            this.cbLoginInfo.TabIndex = 29;
            this.cbLoginInfo.SelectedIndexChanged += new System.EventHandler(this.cbLoginInfo_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 112);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 13);
            this.label9.TabIndex = 28;
            this.label9.Text = "URL";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 89);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 27;
            this.label8.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Username";
            // 
            // tbLoginInfoUsername
            // 
            this.tbLoginInfoUsername.Location = new System.Drawing.Point(92, 60);
            this.tbLoginInfoUsername.Name = "tbLoginInfoUsername";
            this.tbLoginInfoUsername.Size = new System.Drawing.Size(181, 20);
            this.tbLoginInfoUsername.TabIndex = 22;
            // 
            // tbLoginInfoPassword
            // 
            this.tbLoginInfoPassword.Location = new System.Drawing.Point(92, 86);
            this.tbLoginInfoPassword.Name = "tbLoginInfoPassword";
            this.tbLoginInfoPassword.Size = new System.Drawing.Size(181, 20);
            this.tbLoginInfoPassword.TabIndex = 24;
            // 
            // tbLoginInfoUrl
            // 
            this.tbLoginInfoUrl.Location = new System.Drawing.Point(92, 112);
            this.tbLoginInfoUrl.Name = "tbLoginInfoUrl";
            this.tbLoginInfoUrl.Size = new System.Drawing.Size(181, 20);
            this.tbLoginInfoUrl.TabIndex = 25;
            // 
            // gbAssignments
            // 
            this.gbAssignments.Controls.Add(this.btnDeleteAssignment);
            this.gbAssignments.Controls.Add(this.clbAssignments);
            this.gbAssignments.Controls.Add(this.btnEditAssignment);
            this.gbAssignments.Controls.Add(this.btnAddAssignment);
            this.gbAssignments.Location = new System.Drawing.Point(304, 13);
            this.gbAssignments.Name = "gbAssignments";
            this.gbAssignments.Size = new System.Drawing.Size(228, 419);
            this.gbAssignments.TabIndex = 26;
            this.gbAssignments.TabStop = false;
            this.gbAssignments.Text = "Assignments";
            // 
            // btnDeleteAssignment
            // 
            this.btnDeleteAssignment.Enabled = false;
            this.btnDeleteAssignment.Location = new System.Drawing.Point(6, 390);
            this.btnDeleteAssignment.Name = "btnDeleteAssignment";
            this.btnDeleteAssignment.Size = new System.Drawing.Size(210, 23);
            this.btnDeleteAssignment.TabIndex = 18;
            this.btnDeleteAssignment.Text = "Delete";
            this.btnDeleteAssignment.UseVisualStyleBackColor = true;
            this.btnDeleteAssignment.Click += new System.EventHandler(this.btnDeleteAssignment_Click);
            // 
            // clbAssignments
            // 
            this.clbAssignments.FormattingEnabled = true;
            this.clbAssignments.Location = new System.Drawing.Point(10, 19);
            this.clbAssignments.Name = "clbAssignments";
            this.clbAssignments.Size = new System.Drawing.Size(210, 304);
            this.clbAssignments.TabIndex = 17;
            this.clbAssignments.SelectedIndexChanged += new System.EventHandler(this.clbAssignments_SelectedIndexChanged);
            this.clbAssignments.SelectedValueChanged += new System.EventHandler(this.clbAssignments_SelectedValueChanged);
            // 
            // btnEditAssignment
            // 
            this.btnEditAssignment.Enabled = false;
            this.btnEditAssignment.Location = new System.Drawing.Point(6, 361);
            this.btnEditAssignment.Name = "btnEditAssignment";
            this.btnEditAssignment.Size = new System.Drawing.Size(210, 23);
            this.btnEditAssignment.TabIndex = 15;
            this.btnEditAssignment.Text = "Edit";
            this.btnEditAssignment.UseVisualStyleBackColor = true;
            this.btnEditAssignment.Click += new System.EventHandler(this.btnEditAssignment_Click);
            // 
            // btnAddAssignment
            // 
            this.btnAddAssignment.Enabled = false;
            this.btnAddAssignment.Location = new System.Drawing.Point(6, 332);
            this.btnAddAssignment.Name = "btnAddAssignment";
            this.btnAddAssignment.Size = new System.Drawing.Size(210, 23);
            this.btnAddAssignment.TabIndex = 16;
            this.btnAddAssignment.Text = "Add";
            this.btnAddAssignment.UseVisualStyleBackColor = true;
            this.btnAddAssignment.Click += new System.EventHandler(this.btnAddAssignment_Click);
            // 
            // tbProjectName
            // 
            this.tbProjectName.Location = new System.Drawing.Point(105, 13);
            this.tbProjectName.Name = "tbProjectName";
            this.tbProjectName.Size = new System.Drawing.Size(187, 20);
            this.tbProjectName.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Client Name";
            // 
            // tbClientName
            // 
            this.tbClientName.Location = new System.Drawing.Point(105, 38);
            this.tbClientName.Name = "tbClientName";
            this.tbClientName.Size = new System.Drawing.Size(187, 20);
            this.tbClientName.TabIndex = 18;
            // 
            // tbStatus
            // 
            this.tbStatus.Enabled = false;
            this.tbStatus.Location = new System.Drawing.Point(105, 64);
            this.tbStatus.Name = "tbStatus";
            this.tbStatus.Size = new System.Drawing.Size(187, 20);
            this.tbStatus.TabIndex = 17;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(6, 419);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(124, 13);
            this.linkLabel1.TabIndex = 12;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "See notes for this project";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Status";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Deadline";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Start Date";
            // 
            // tbDeadLine
            // 
            this.tbDeadLine.Location = new System.Drawing.Point(105, 128);
            this.tbDeadLine.Name = "tbDeadLine";
            this.tbDeadLine.Size = new System.Drawing.Size(187, 20);
            this.tbDeadLine.TabIndex = 2;
            // 
            // tbStartDate
            // 
            this.tbStartDate.Location = new System.Drawing.Point(105, 93);
            this.tbStartDate.Name = "tbStartDate";
            this.tbStartDate.Size = new System.Drawing.Size(187, 20);
            this.tbStartDate.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnSearch);
            this.tabPage2.Controls.Add(this.Search);
            this.tabPage2.Controls.Add(this.tbSearch);
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(788, 496);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Notes";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(673, 27);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(105, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // Search
            // 
            this.Search.AutoSize = true;
            this.Search.Location = new System.Drawing.Point(9, 13);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(41, 13);
            this.Search.TabIndex = 3;
            this.Search.Text = "Search";
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(12, 29);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(655, 20);
            this.tbSearch.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnEditCss);
            this.groupBox4.Controls.Add(this.rtbCssCodeDetails);
            this.groupBox4.Location = new System.Drawing.Point(235, 62);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(543, 427);
            this.groupBox4.TabIndex = 17;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Note details";
            // 
            // btnEditCss
            // 
            this.btnEditCss.Enabled = false;
            this.btnEditCss.Location = new System.Drawing.Point(6, 398);
            this.btnEditCss.Name = "btnEditCss";
            this.btnEditCss.Size = new System.Drawing.Size(531, 23);
            this.btnEditCss.TabIndex = 5;
            this.btnEditCss.Text = "Edit";
            this.btnEditCss.UseVisualStyleBackColor = true;
            this.btnEditCss.Click += new System.EventHandler(this.btnEditCss_Click);
            // 
            // rtbCssCodeDetails
            // 
            this.rtbCssCodeDetails.Location = new System.Drawing.Point(6, 19);
            this.rtbCssCodeDetails.Name = "rtbCssCodeDetails";
            this.rtbCssCodeDetails.Size = new System.Drawing.Size(531, 368);
            this.rtbCssCodeDetails.TabIndex = 3;
            this.rtbCssCodeDetails.Text = "";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnAddCssCode);
            this.groupBox3.Controls.Add(this.lbCssCodes);
            this.groupBox3.Location = new System.Drawing.Point(6, 62);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(223, 427);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Notes";
            // 
            // btnAddCssCode
            // 
            this.btnAddCssCode.Enabled = false;
            this.btnAddCssCode.Location = new System.Drawing.Point(6, 398);
            this.btnAddCssCode.Name = "btnAddCssCode";
            this.btnAddCssCode.Size = new System.Drawing.Size(210, 23);
            this.btnAddCssCode.TabIndex = 4;
            this.btnAddCssCode.Text = "Add New .css";
            this.btnAddCssCode.UseVisualStyleBackColor = true;
            this.btnAddCssCode.Click += new System.EventHandler(this.btnAddCssCode_Click);
            // 
            // lbCssCodes
            // 
            this.lbCssCodes.Location = new System.Drawing.Point(6, 19);
            this.lbCssCodes.Name = "lbCssCodes";
            this.lbCssCodes.Size = new System.Drawing.Size(210, 368);
            this.lbCssCodes.TabIndex = 2;
            this.lbCssCodes.SelectedIndexChanged += new System.EventHandler(this.lbCssCodes_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 524);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Project Management and Notes";
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gbLoginInfo.ResumeLayout(false);
            this.gbLoginInfo.PerformLayout();
            this.gbAssignments.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lbProjects;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox cbSort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label Search;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox rtbCssCodeDetails;
        private System.Windows.Forms.ListBox lbCssCodes;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbDeadLine;
        private System.Windows.Forms.TextBox tbStartDate;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button btnAddAssignment;
        private System.Windows.Forms.Button btnEditAssignment;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnAddProject;
        private System.Windows.Forms.GroupBox gbLoginInfo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbLoginInfoUsername;
        private System.Windows.Forms.TextBox tbLoginInfoPassword;
        private System.Windows.Forms.TextBox tbLoginInfoUrl;
        private System.Windows.Forms.GroupBox gbAssignments;
        private System.Windows.Forms.TextBox tbProjectName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbClientName;
        private System.Windows.Forms.TextBox tbStatus;
        private System.Windows.Forms.Button btnAddCssCode;
        private System.Windows.Forms.Button btnEditCss;
        private System.Windows.Forms.CheckedListBox clbAssignments;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbLoginInfo;
        private System.Windows.Forms.Button btnDeleteLoginInfo;
        private System.Windows.Forms.Button btnEdiLoginInfo;
        private System.Windows.Forms.Button btnAddLoginInfo;
        private System.Windows.Forms.Button btnDeleteAssignment;
        private System.Windows.Forms.Button btnDeleteProject;
        private System.Windows.Forms.Button btnEditProject;
    }
}

