using CreateProjectDDDUoW._0___Core;
using CreateProjectDDDUoW._1___Base;
using CreateProjectDDDUoW.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        #region Form
        public Form1()
        {
            InitializeComponent();

            tx_User.Text = Properties.Settings.Default["User"].ToString();
            tx_Password.Text = Properties.Settings.Default["Password"].ToString();
            tx_Instance.Text = Properties.Settings.Default["Instance"].ToString();
            cb_Context.Text = Properties.Settings.Default["Context"].ToString();
            tx_OutputPath.Text = Properties.Settings.Default["Path"].ToString();
            tx_SolutionName.Text = Properties.Settings.Default["SolutionName"].ToString();
            cb_OutputLanguage.Text = Properties.Settings.Default["OutputLanguage"].ToString();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default["User"] = tx_User.Text;
            Properties.Settings.Default["Password"] = tx_Password.Text;
            Properties.Settings.Default["Instance"] = tx_Instance.Text;
            Properties.Settings.Default["Context"] = cb_Context.Text;
            Properties.Settings.Default["Path"] = tx_OutputPath.Text;
            Properties.Settings.Default["SolutionName"] = tx_SolutionName.Text;
            Properties.Settings.Default["OutputLanguage"] = cb_OutputLanguage.Text;
            
            Properties.Settings.Default.Save();
        }

        private void bt_SelectFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fb = new FolderBrowserDialog();
            fb.SelectedPath = "C:";
            DialogResult result = fb.ShowDialog();
            if (result == DialogResult.OK)
            {
                tx_OutputPath.Text = fb.SelectedPath;
            }
        }
        #endregion

        #region DBConnection
        /// <summary>
        /// Get the list of databases on the instance
        /// </summary>
        /// <returns></returns>
        public List<Contexto> GetDatabaseList()
        {
            List<Contexto> list = new List<Contexto>();

            string conString = $"server={tx_Instance.Text};uid={tx_User.Text};pwd={tx_Password.Text};";
            toolStripStatusLabel.Text = "Connection to the instance.";
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                toolStripStatusLabel.Text = "Connection Open.";
                using (SqlCommand cmd = new SqlCommand("SELECT name from sys.databases", con))
                {
                    toolStripStatusLabel.Text = "Reading Databases.";
                    using (IDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var ctx = new Contexto();
                            ctx.Nome = dr[0].ToString();
                            ctx.StringConexao = $"data source={tx_Instance.Text};initial catalog={dr[0].ToString()};Integrated Security=False; User Id={tx_User.Text};Password={tx_Password.Text}";
                            ctx.Tabelas = SQLTools.GetTables(ctx.StringConexao);
                            if (ctx.Tabelas != null)
                            {
                                list.Add(ctx);
                            }
                            ctx.TabelasSelecionadas = new List<string>();
                        }
                    }
                }
            }
            return list;
        }

        private void bt_Connect_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "done";
            try
            {
                List<Contexto> databases = GetDatabaseList();
                list_DBs.Items.Clear();
                list_DBs.Items.AddRange(databases.ToArray());
                list_DBs.DisplayMember = "Nome";
                list_Selected_Dbs.DisplayMember = "Nome";

                toolStripStatusLabel.Text = "done";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Oops...\r\n Exception: {ex.Message} \r\n\r\n Inner Exception: {ex.InnerException?.Message}");
                toolStripStatusLabel.Text = "Error.";
            }

        }
        #endregion

        #region Manage Databases
        private void bt_AddDB_Click(object sender, EventArgs e)
        {
            list_Selected_Dbs.Items.Add(list_DBs.SelectedItem);
            list_DBs.Items.Remove(list_DBs.SelectedItem);
        }

        private void bt_RemoveDB_Click(object sender, EventArgs e)
        {
            var selectedDB = list_Selected_Dbs.SelectedItem;
            if (MessageBox.Show($"Are you shure to remove {selectedDB}", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                list_Selected_Dbs.Items.Remove(selectedDB);
                list_DBs.Items.Add(selectedDB);
            }
        }

        #region Drag And Drop
        private void list_Selected_Dbs_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Contexto)))
            {
                Contexto str = (Contexto)e.Data.GetData(typeof(Contexto));

                list_Selected_Dbs.Items.Add(str);
            }
        }

        private void list_DBs_MouseDown(object sender, MouseEventArgs e)
        {
            if (list_DBs.Items.Count == 0)
                return;

            int index = list_DBs.IndexFromPoint(e.X, e.Y);
            Contexto s = list_DBs.Items[index] as Contexto;
            DragDropEffects dde1 = DoDragDrop(s,
                DragDropEffects.All);

            if (dde1 == DragDropEffects.All)
            {
                list_DBs.Items.RemoveAt(list_DBs.IndexFromPoint(e.X, e.Y));
            }
        }

        private void list_Selected_Dbs_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }
        #endregion

        private void OrderLists()
        {
            list_DBs.Refresh();
            list_Selected_Dbs.Refresh();
        }

        #endregion

        #region Manage Tables
        private void list_Selected_Dbs_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ctxSelected = list_Selected_Dbs.SelectedItem as Contexto;
            cklist_Tables.Items.Clear();
            if (ctxSelected != null)
            {
                cklist_Tables.Items.AddRange(ctxSelected.Tabelas.OrderBy(t => t).ToArray());
                foreach (var item in ctxSelected.TabelasSelecionadas)
                {
                    cklist_Tables.SetItemCheckState(cklist_Tables.Items.IndexOf(item), CheckState.Checked);
                }
            }
        }

        private void bt_CheckAll_Click(object sender, EventArgs e)
        {
            var ctxSelected = list_Selected_Dbs.SelectedItem as Contexto;
            for (int i = 0; i < cklist_Tables.Items.Count - 1; i++)
            {
                cklist_Tables.SetItemCheckState(i, CheckState.Checked);
            }
            ctxSelected.TabelasSelecionadas = ctxSelected.Tabelas;
            list_Selected_Dbs.SelectedItem = ctxSelected;
        }

        private void BtUncheckAll_Click(object sender, EventArgs e)
        {
            var ctxSelected = list_Selected_Dbs.SelectedItem as Contexto;
            for (int i = 0; i < cklist_Tables.Items.Count - 1; i++)
            {
                cklist_Tables.SetItemCheckState(i, CheckState.Unchecked);
            }
            ctxSelected.TabelasSelecionadas = new List<string>();
            list_Selected_Dbs.SelectedItem = ctxSelected;
        }

        private void cklist_Tables_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ctxSelected = list_Selected_Dbs.SelectedItem as Contexto;
            var itemSelecionado = cklist_Tables.SelectedItem;

            if (itemSelecionado != null)
            {
                if (cklist_Tables.GetItemCheckState(cklist_Tables.Items.IndexOf(itemSelecionado)) == CheckState.Checked)
                {
                    if (!ctxSelected.TabelasSelecionadas.Contains(itemSelecionado))
                    {
                        ctxSelected.TabelasSelecionadas.Add(itemSelecionado.ToString());
                    }

                }
                else
                {
                    if (ctxSelected.TabelasSelecionadas.Contains(itemSelecionado))
                    {
                        ctxSelected.TabelasSelecionadas.Remove(itemSelecionado.ToString());
                    }
                }
            }
            list_Selected_Dbs.SelectedItem = ctxSelected;

        }
        #endregion

        private void bt_GenerateSolution_Click(object sender, EventArgs e)
        {
            var outputpath = tx_OutputPath.Text;
            var solutionname = tx_SolutionName.Text;

            if (
                System.IO.Directory.Exists(outputpath) &&
                MessageBox.Show("Looks like the output folder already exists. Do you want to delete the output folder?", "Hummm...", MessageBoxButtons.YesNo) == DialogResult.Yes
                )
            {
                System.IO.Directory.Delete(outputpath);
            }

            try
            {
                toolStripStatusLabel.Text = "Creating Solution.";
                A_CreateSolution createSln = new A_CreateSolution(outputpath, solutionname);
                toolStripStatusLabel.Text = "Creating Test Project.";
                B_CreateProjectTest createProjectTest = new B_CreateProjectTest(solutionname, outputpath);

                var contexts = list_Selected_Dbs.Items.OfType<Contexto>().ToList();
                toolStripStatusLabel.Text = "Creating Infra.Data Project.";
                D_CreateInfraDados createInfraDados = new D_CreateInfraDados(solutionname, outputpath, contexts, 1);
                toolStripStatusLabel.Text = "Creating API Project.";
                C_CreateProjectAPI createProjectAPI = new C_CreateProjectAPI(solutionname, outputpath, contexts);
                toolStripStatusLabel.Text = "Creating Domain Project.";
                E_CreateDominio criarDominio = new E_CreateDominio(solutionname, outputpath, contexts);
                toolStripStatusLabel.Text = "Creating AppServices Project.";
                F_CreateAplicacao criarAppServico = new F_CreateAplicacao(solutionname, outputpath, contexts);
                toolStripStatusLabel.Text = "Creating SQL Project.";
                G_CreateInfraSQL createInfraSQL = new G_CreateInfraSQL(solutionname, outputpath, contexts);
                toolStripStatusLabel.Text = "Creating DTO Project.";
                H_CreateDTOProject createDTOProject = new H_CreateDTOProject(solutionname, outputpath, contexts);
                toolStripStatusLabel.Text = "Done.";
                MessageBox.Show("Sucess");

                Process.Start(outputpath);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Oops...\r\n Exception: {ex.Message} \r\n\r\n Inner Exception: {ex.InnerException?.Message}");
                toolStripStatusLabel.Text = "Error.";
            }
        }
    }
}
