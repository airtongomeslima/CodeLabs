namespace WindowsFormsApp1
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
            this.cklist_Tables = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tx_Instance = new System.Windows.Forms.TextBox();
            this.cb_Context = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.list_Selected_Dbs = new System.Windows.Forms.ListBox();
            this.bt_CheckAll = new System.Windows.Forms.Button();
            this.BtUncheckAll = new System.Windows.Forms.Button();
            this.bt_GenerateSolution = new System.Windows.Forms.Button();
            this.tx_OutputPath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label5 = new System.Windows.Forms.Label();
            this.bt_SelectFolder = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.tx_SolutionName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.bt_RemoveDB = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tx_User = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.bt_Connect = new System.Windows.Forms.Button();
            this.tx_Password = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.list_DBs = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.bt_AddDB = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.cb_OutputLanguage = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cklist_Tables
            // 
            this.cklist_Tables.CheckOnClick = true;
            this.cklist_Tables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cklist_Tables.FormattingEnabled = true;
            this.cklist_Tables.Location = new System.Drawing.Point(3, 46);
            this.cklist_Tables.Name = "cklist_Tables";
            this.cklist_Tables.Size = new System.Drawing.Size(378, 424);
            this.cklist_Tables.Sorted = true;
            this.cklist_Tables.TabIndex = 1;
            this.cklist_Tables.SelectedIndexChanged += new System.EventHandler(this.cklist_Tables_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Location = new System.Drawing.Point(15, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 33);
            this.label1.TabIndex = 2;
            this.label1.Text = "Instance";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tx_Instance
            // 
            this.tx_Instance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tx_Instance.Location = new System.Drawing.Point(69, 3);
            this.tx_Instance.Name = "tx_Instance";
            this.tx_Instance.Size = new System.Drawing.Size(551, 20);
            this.tx_Instance.TabIndex = 3;
            // 
            // cb_Context
            // 
            this.cb_Context.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cb_Context.FormattingEnabled = true;
            this.cb_Context.Items.AddRange(new object[] {
            "EntityFramework",
            "Dapper"});
            this.cb_Context.Location = new System.Drawing.Point(119, 35);
            this.cb_Context.Name = "cb_Context";
            this.cb_Context.Size = new System.Drawing.Size(487, 21);
            this.cb_Context.TabIndex = 6;
            this.cb_Context.Text = "EntityFramework";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Right;
            this.label3.Location = new System.Drawing.Point(31, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 32);
            this.label3.TabIndex = 7;
            this.label3.Text = "Type of Context";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // list_Selected_Dbs
            // 
            this.list_Selected_Dbs.AllowDrop = true;
            this.list_Selected_Dbs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.list_Selected_Dbs.FormattingEnabled = true;
            this.list_Selected_Dbs.Location = new System.Drawing.Point(375, 53);
            this.list_Selected_Dbs.Name = "list_Selected_Dbs";
            this.list_Selected_Dbs.Size = new System.Drawing.Size(461, 473);
            this.list_Selected_Dbs.Sorted = true;
            this.list_Selected_Dbs.TabIndex = 8;
            this.list_Selected_Dbs.SelectedIndexChanged += new System.EventHandler(this.list_Selected_Dbs_SelectedIndexChanged);
            this.list_Selected_Dbs.DragDrop += new System.Windows.Forms.DragEventHandler(this.list_Selected_Dbs_DragDrop);
            this.list_Selected_Dbs.DragOver += new System.Windows.Forms.DragEventHandler(this.list_Selected_Dbs_DragOver);
            // 
            // bt_CheckAll
            // 
            this.bt_CheckAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bt_CheckAll.Location = new System.Drawing.Point(3, 3);
            this.bt_CheckAll.Name = "bt_CheckAll";
            this.bt_CheckAll.Size = new System.Drawing.Size(183, 31);
            this.bt_CheckAll.TabIndex = 9;
            this.bt_CheckAll.Text = "Check All";
            this.bt_CheckAll.UseVisualStyleBackColor = true;
            this.bt_CheckAll.Click += new System.EventHandler(this.bt_CheckAll_Click);
            // 
            // BtUncheckAll
            // 
            this.BtUncheckAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtUncheckAll.Location = new System.Drawing.Point(192, 3);
            this.BtUncheckAll.Name = "BtUncheckAll";
            this.BtUncheckAll.Size = new System.Drawing.Size(183, 31);
            this.BtUncheckAll.TabIndex = 10;
            this.BtUncheckAll.Text = "Uncheck All";
            this.BtUncheckAll.UseVisualStyleBackColor = true;
            this.BtUncheckAll.Click += new System.EventHandler(this.BtUncheckAll_Click);
            // 
            // bt_GenerateSolution
            // 
            this.bt_GenerateSolution.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_GenerateSolution.Location = new System.Drawing.Point(1091, 700);
            this.bt_GenerateSolution.Name = "bt_GenerateSolution";
            this.bt_GenerateSolution.Size = new System.Drawing.Size(141, 21);
            this.bt_GenerateSolution.TabIndex = 11;
            this.bt_GenerateSolution.Text = "Generate";
            this.bt_GenerateSolution.UseVisualStyleBackColor = true;
            this.bt_GenerateSolution.Click += new System.EventHandler(this.bt_GenerateSolution_Click);
            // 
            // tx_OutputPath
            // 
            this.tx_OutputPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tx_OutputPath.Location = new System.Drawing.Point(3, 3);
            this.tx_OutputPath.Name = "tx_OutputPath";
            this.tx_OutputPath.Size = new System.Drawing.Size(386, 20);
            this.tx_OutputPath.TabIndex = 13;
            this.tx_OutputPath.Text = "C:/Test/";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Right;
            this.label4.Location = new System.Drawing.Point(49, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 33);
            this.label4.TabIndex = 12;
            this.label4.Text = "Output Path";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(375, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(461, 50);
            this.label5.TabIndex = 14;
            this.label5.Text = "Selected DBs";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bt_SelectFolder
            // 
            this.bt_SelectFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bt_SelectFolder.Location = new System.Drawing.Point(395, 3);
            this.bt_SelectFolder.Name = "bt_SelectFolder";
            this.bt_SelectFolder.Size = new System.Drawing.Size(89, 21);
            this.bt_SelectFolder.TabIndex = 15;
            this.bt_SelectFolder.Text = "Select Path";
            this.bt_SelectFolder.UseVisualStyleBackColor = true;
            this.bt_SelectFolder.Click += new System.EventHandler(this.bt_SelectFolder_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(842, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(390, 50);
            this.label6.TabIndex = 16;
            this.label6.Text = "Tables";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tx_SolutionName
            // 
            this.tx_SolutionName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tx_SolutionName.Location = new System.Drawing.Point(119, 3);
            this.tx_SolutionName.Name = "tx_SolutionName";
            this.tx_SolutionName.Size = new System.Drawing.Size(487, 20);
            this.tx_SolutionName.TabIndex = 18;
            this.tx_SolutionName.Text = "Solucao";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Right;
            this.label7.Location = new System.Drawing.Point(37, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 32);
            this.label7.TabIndex = 17;
            this.label7.Text = "Solution Name";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bt_RemoveDB
            // 
            this.bt_RemoveDB.Dock = System.Windows.Forms.DockStyle.Right;
            this.bt_RemoveDB.Location = new System.Drawing.Point(682, 532);
            this.bt_RemoveDB.Name = "bt_RemoveDB";
            this.bt_RemoveDB.Size = new System.Drawing.Size(154, 28);
            this.bt_RemoveDB.TabIndex = 19;
            this.bt_RemoveDB.Text = "Remove DB";
            this.bt_RemoveDB.UseVisualStyleBackColor = true;
            this.bt_RemoveDB.Click += new System.EventHandler(this.bt_RemoveDB_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.21182F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.78818F));
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tx_SolutionName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cb_Context, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(609, 97);
            this.tableLayoutPanel1.TabIndex = 20;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.6383F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.3617F));
            this.tableLayoutPanel2.Controls.Add(this.tx_OutputPath, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.bt_SelectFolder, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(119, 67);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(487, 27);
            this.tableLayoutPanel2.TabIndex = 19;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.75441F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 89.24558F));
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.tx_Instance, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.label8, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.label9, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.tx_User, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 1, 2);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(618, 25);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(623, 97);
            this.tableLayoutPanel3.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Right;
            this.label8.Location = new System.Drawing.Point(34, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 33);
            this.label8.TabIndex = 4;
            this.label8.Text = "User";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Right;
            this.label9.Location = new System.Drawing.Point(10, 66);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 31);
            this.label9.TabIndex = 5;
            this.label9.Text = "Password";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tx_User
            // 
            this.tx_User.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tx_User.Location = new System.Drawing.Point(69, 36);
            this.tx_User.Name = "tx_User";
            this.tx_User.Size = new System.Drawing.Size(551, 20);
            this.tx_User.TabIndex = 6;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.bt_Connect, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.tx_Password, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(69, 69);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(551, 25);
            this.tableLayoutPanel4.TabIndex = 7;
            // 
            // bt_Connect
            // 
            this.bt_Connect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bt_Connect.Location = new System.Drawing.Point(278, 3);
            this.bt_Connect.Name = "bt_Connect";
            this.bt_Connect.Size = new System.Drawing.Size(270, 19);
            this.bt_Connect.TabIndex = 24;
            this.bt_Connect.Text = "Connect";
            this.bt_Connect.UseVisualStyleBackColor = true;
            this.bt_Connect.Click += new System.EventHandler(this.bt_Connect_Click);
            // 
            // tx_Password
            // 
            this.tx_Password.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tx_Password.Location = new System.Drawing.Point(3, 3);
            this.tx_Password.Name = "tx_Password";
            this.tx_Password.Size = new System.Drawing.Size(269, 20);
            this.tx_Password.TabIndex = 23;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.5F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.5F));
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel3, 1, 1);
            this.tableLayoutPanel5.Controls.Add(this.label10, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.label11, 1, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.26087F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 81.73913F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(1244, 125);
            this.tableLayoutPanel5.TabIndex = 22;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Location = new System.Drawing.Point(3, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(609, 22);
            this.label10.TabIndex = 22;
            this.label10.Text = "Project Config";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Location = new System.Drawing.Point(618, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(623, 22);
            this.label11.TabIndex = 23;
            this.label11.Text = "Connection String";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // list_DBs
            // 
            this.list_DBs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.list_DBs.FormattingEnabled = true;
            this.list_DBs.Location = new System.Drawing.Point(3, 53);
            this.list_DBs.Name = "list_DBs";
            this.list_DBs.Size = new System.Drawing.Size(366, 473);
            this.list_DBs.Sorted = true;
            this.list_DBs.TabIndex = 23;
            this.list_DBs.MouseDown += new System.Windows.Forms.MouseEventHandler(this.list_DBs_MouseDown);
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel6.ColumnCount = 3;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.3787F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.6213F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 395F));
            this.tableLayoutPanel6.Controls.Add(this.bt_AddDB, 0, 2);
            this.tableLayoutPanel6.Controls.Add(this.label12, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.list_DBs, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.list_Selected_Dbs, 1, 1);
            this.tableLayoutPanel6.Controls.Add(this.label6, 2, 0);
            this.tableLayoutPanel6.Controls.Add(this.bt_RemoveDB, 1, 2);
            this.tableLayoutPanel6.Controls.Add(this.label5, 1, 0);
            this.tableLayoutPanel6.Controls.Add(this.tableLayoutPanel7, 2, 1);
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 131);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 3;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.565217F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.43478F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(1235, 563);
            this.tableLayoutPanel6.TabIndex = 24;
            // 
            // bt_AddDB
            // 
            this.bt_AddDB.Dock = System.Windows.Forms.DockStyle.Right;
            this.bt_AddDB.Location = new System.Drawing.Point(215, 532);
            this.bt_AddDB.Name = "bt_AddDB";
            this.bt_AddDB.Size = new System.Drawing.Size(154, 28);
            this.bt_AddDB.TabIndex = 26;
            this.bt_AddDB.Text = "Add DB";
            this.bt_AddDB.UseVisualStyleBackColor = true;
            this.bt_AddDB.Click += new System.EventHandler(this.bt_AddDB_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Location = new System.Drawing.Point(3, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(366, 50);
            this.label12.TabIndex = 25;
            this.label12.Text = "Allowed DBs";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 1;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Controls.Add(this.tableLayoutPanel8, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.cklist_Tables, 0, 1);
            this.tableLayoutPanel7.Location = new System.Drawing.Point(842, 53);
            this.tableLayoutPanel7.MinimumSize = new System.Drawing.Size(0, 100);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 2;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 430F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(384, 473);
            this.tableLayoutPanel7.TabIndex = 24;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 2;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.Controls.Add(this.bt_CheckAll, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.BtUncheckAll, 1, 0);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel8.MinimumSize = new System.Drawing.Size(0, 30);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 1;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(378, 37);
            this.tableLayoutPanel8.TabIndex = 0;
            // 
            // cb_OutputLanguage
            // 
            this.cb_OutputLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cb_OutputLanguage.FormattingEnabled = true;
            this.cb_OutputLanguage.Items.AddRange(new object[] {
            "Português (PT-BR)",
            "English (EN-US)"});
            this.cb_OutputLanguage.Location = new System.Drawing.Point(105, 700);
            this.cb_OutputLanguage.Name = "cb_OutputLanguage";
            this.cb_OutputLanguage.Size = new System.Drawing.Size(170, 21);
            this.cb_OutputLanguage.TabIndex = 25;
            this.cb_OutputLanguage.Text = "Português (PT-BR)";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 703);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Output Language";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 733);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1244, 22);
            this.statusStrip1.TabIndex = 27;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(16, 17);
            this.toolStripStatusLabel.Text = "...";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1244, 755);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cb_OutputLanguage);
            this.Controls.Add(this.tableLayoutPanel6);
            this.Controls.Add(this.tableLayoutPanel5);
            this.Controls.Add(this.bt_GenerateSolution);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Mega Blaster Awesome DDD Solution Creator 2000 Automatic";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel8.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckedListBox cklist_Tables;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tx_Instance;
        private System.Windows.Forms.ComboBox cb_Context;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox list_Selected_Dbs;
        private System.Windows.Forms.Button bt_CheckAll;
        private System.Windows.Forms.Button BtUncheckAll;
        private System.Windows.Forms.Button bt_GenerateSolution;
        private System.Windows.Forms.TextBox tx_OutputPath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button bt_SelectFolder;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tx_SolutionName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button bt_RemoveDB;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tx_User;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button bt_Connect;
        private System.Windows.Forms.TextBox tx_Password;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ListBox list_DBs;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button bt_AddDB;
        private System.Windows.Forms.ComboBox cb_OutputLanguage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
    }
}

