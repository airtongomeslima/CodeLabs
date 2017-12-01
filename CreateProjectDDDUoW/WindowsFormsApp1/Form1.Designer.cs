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
            this.bt_AddContext = new System.Windows.Forms.Button();
            this.cklist_Tables = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tx_ContextName = new System.Windows.Forms.TextBox();
            this.tx_ConnectionString = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_Mapper = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.list_Contexts = new System.Windows.Forms.ListBox();
            this.bt_CheckAll = new System.Windows.Forms.Button();
            this.BtUncheckAll = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.tx_ExitFolder = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label5 = new System.Windows.Forms.Label();
            this.bt_SelectFolder = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.tx_SolutionName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bt_AddContext
            // 
            this.bt_AddContext.Location = new System.Drawing.Point(438, 84);
            this.bt_AddContext.Name = "bt_AddContext";
            this.bt_AddContext.Size = new System.Drawing.Size(75, 23);
            this.bt_AddContext.TabIndex = 0;
            this.bt_AddContext.Text = "Adicionar";
            this.bt_AddContext.UseVisualStyleBackColor = true;
            this.bt_AddContext.Click += new System.EventHandler(this.bt_AddContext_Click);
            // 
            // cklist_Tables
            // 
            this.cklist_Tables.FormattingEnabled = true;
            this.cklist_Tables.Location = new System.Drawing.Point(496, 161);
            this.cklist_Tables.Name = "cklist_Tables";
            this.cklist_Tables.Size = new System.Drawing.Size(288, 529);
            this.cklist_Tables.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nome do Contexto";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // tx_ContextName
            // 
            this.tx_ContextName.Location = new System.Drawing.Point(113, 32);
            this.tx_ContextName.Name = "tx_ContextName";
            this.tx_ContextName.Size = new System.Drawing.Size(400, 20);
            this.tx_ContextName.TabIndex = 3;
            this.tx_ContextName.Text = "Context";
            // 
            // tx_ConnectionString
            // 
            this.tx_ConnectionString.Location = new System.Drawing.Point(113, 58);
            this.tx_ConnectionString.Name = "tx_ConnectionString";
            this.tx_ConnectionString.Size = new System.Drawing.Size(400, 20);
            this.tx_ConnectionString.TabIndex = 5;
            this.tx_ConnectionString.Text = "data source=./;initial catalog=AdventureWorks2014;Integrated Security=False; User" +
    " Id=sa;Password=123456;";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "String de Conexão";
            // 
            // cb_Mapper
            // 
            this.cb_Mapper.FormattingEnabled = true;
            this.cb_Mapper.Items.AddRange(new object[] {
            "EntityFramework",
            "Dapper"});
            this.cb_Mapper.Location = new System.Drawing.Point(619, 31);
            this.cb_Mapper.Name = "cb_Mapper";
            this.cb_Mapper.Size = new System.Drawing.Size(355, 21);
            this.cb_Mapper.TabIndex = 6;
            this.cb_Mapper.Text = "EntityFramework";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(531, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Tipo de Mapper";
            // 
            // list_Contexts
            // 
            this.list_Contexts.FormattingEnabled = true;
            this.list_Contexts.Location = new System.Drawing.Point(15, 131);
            this.list_Contexts.Name = "list_Contexts";
            this.list_Contexts.Size = new System.Drawing.Size(432, 563);
            this.list_Contexts.TabIndex = 8;
            // 
            // bt_CheckAll
            // 
            this.bt_CheckAll.Location = new System.Drawing.Point(496, 131);
            this.bt_CheckAll.Name = "bt_CheckAll";
            this.bt_CheckAll.Size = new System.Drawing.Size(141, 23);
            this.bt_CheckAll.TabIndex = 9;
            this.bt_CheckAll.Text = "Marcar Todos";
            this.bt_CheckAll.UseVisualStyleBackColor = true;
            this.bt_CheckAll.Click += new System.EventHandler(this.button2_Click);
            // 
            // BtUncheckAll
            // 
            this.BtUncheckAll.Location = new System.Drawing.Point(643, 131);
            this.BtUncheckAll.Name = "BtUncheckAll";
            this.BtUncheckAll.Size = new System.Drawing.Size(141, 23);
            this.BtUncheckAll.TabIndex = 10;
            this.BtUncheckAll.Text = "Desmarcar Todos";
            this.BtUncheckAll.UseVisualStyleBackColor = true;
            this.BtUncheckAll.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(833, 667);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(141, 23);
            this.button4.TabIndex = 11;
            this.button4.Text = "Gerar";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // tx_ExitFolder
            // 
            this.tx_ExitFolder.Location = new System.Drawing.Point(619, 61);
            this.tx_ExitFolder.Name = "tx_ExitFolder";
            this.tx_ExitFolder.Size = new System.Drawing.Size(355, 20);
            this.tx_ExitFolder.TabIndex = 13;
            this.tx_ExitFolder.Text = "C:/Project/";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(532, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Pasta de Saída";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Contextos";
            // 
            // bt_SelectFolder
            // 
            this.bt_SelectFolder.Location = new System.Drawing.Point(899, 84);
            this.bt_SelectFolder.Name = "bt_SelectFolder";
            this.bt_SelectFolder.Size = new System.Drawing.Size(75, 23);
            this.bt_SelectFolder.TabIndex = 15;
            this.bt_SelectFolder.Text = "Selecionar Pasta";
            this.bt_SelectFolder.UseVisualStyleBackColor = true;
            this.bt_SelectFolder.Click += new System.EventHandler(this.bt_SelectFolder_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(493, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Tabelas";
            // 
            // tx_SolutionName
            // 
            this.tx_SolutionName.Location = new System.Drawing.Point(113, 6);
            this.tx_SolutionName.Name = "tx_SolutionName";
            this.tx_SolutionName.Size = new System.Drawing.Size(861, 20);
            this.tx_SolutionName.TabIndex = 18;
            this.tx_SolutionName.Text = "Solucao";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Nome da Solução";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 707);
            this.Controls.Add(this.tx_SolutionName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.bt_SelectFolder);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tx_ExitFolder);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.BtUncheckAll);
            this.Controls.Add(this.bt_CheckAll);
            this.Controls.Add(this.list_Contexts);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cb_Mapper);
            this.Controls.Add(this.tx_ConnectionString);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tx_ContextName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cklist_Tables);
            this.Controls.Add(this.bt_AddContext);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_AddContext;
        private System.Windows.Forms.CheckedListBox cklist_Tables;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tx_ContextName;
        private System.Windows.Forms.TextBox tx_ConnectionString;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cb_Mapper;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox list_Contexts;
        private System.Windows.Forms.Button bt_CheckAll;
        private System.Windows.Forms.Button BtUncheckAll;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox tx_ExitFolder;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button bt_SelectFolder;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tx_SolutionName;
        private System.Windows.Forms.Label label7;
    }
}

