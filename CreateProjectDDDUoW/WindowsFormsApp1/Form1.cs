using CreateProjectDDDUoW._0___Core;
using CreateProjectDDDUoW._1___Base;
using CreateProjectDDDUoW.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        string solucao = "Solucao";
        List<string> conn = new List<string>();
        string endereco = "C:/Teste/";
        List<Dictionary<string, string>> Bases = new List<Dictionary<string, string>>();
        List<Dictionary<string, string>> Tabelas = new List<Dictionary<string, string>>();

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var ctxSelected = list_Contexts.SelectedItem as Contexto;
            for (int i = 0; i < cklist_Tables.Items.Count -1; i++)
            {
                cklist_Tables.SetItemCheckState(i, CheckState.Checked);
            }
            ctxSelected.TabelasSelecionadas = ctxSelected.Tabelas;
            list_Contexts.SelectedItem = ctxSelected;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var ctxSelected = list_Contexts.SelectedItem as Contexto;
            for (int i = 0; i < cklist_Tables.Items.Count - 1; i++)
            {
                cklist_Tables.SetItemCheckState(i, CheckState.Unchecked);
            }
            ctxSelected.TabelasSelecionadas = new List<string>();
            list_Contexts.SelectedItem = ctxSelected;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            A_CreateSolution createSln = new A_CreateSolution(endereco, solucao);
            B_CreateProjectTest createProjectTest = new B_CreateProjectTest(solucao, endereco);

            var contextos = list_Contexts.Items.OfType<Contexto>().ToList();
            D_CreateInfraDados createInfraDados = new D_CreateInfraDados(solucao, endereco, contextos, 1);
            C_CreateProjectAPI createProjectAPI = new C_CreateProjectAPI(solucao, endereco, contextos);
            E_CreateDominio criarDominio = new E_CreateDominio(solucao, endereco, contextos);
            F_CreateAplicacao criarAppServico = new F_CreateAplicacao(solucao, endereco, contextos);

            G_CreateInfraSQL createInfraSQL = new G_CreateInfraSQL(solucao, endereco, contextos);
            H_CreateDTOProject createDTOProject = new H_CreateDTOProject(solucao, endereco, contextos);

            MessageBox.Show("Solução Criada com sucesso");
        }

        private void bt_SelectFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fb = new FolderBrowserDialog();
            fb.SelectedPath = "C:";
            DialogResult result = fb.ShowDialog();
            if (result == DialogResult.OK)
            {
                tx_ExitFolder.Text = fb.SelectedPath;
            }
        }

        private void bt_AddContext_Click(object sender, EventArgs e)
        {
            var ctx = new Contexto();
            try
            {
                ctx.Nome = tx_ContextName.Text;
                ctx.StringConexao = tx_ConnectionString.Text;
                ctx.Tabelas = SQLTools.GetTables(ctx.StringConexao);
                if (ctx.Tabelas != null)
                {
                    list_Contexts.Items.Add(ctx);
                }
                ctx.TabelasSelecionadas = new List<string>();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void list_Contexts_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ctxSelected = list_Contexts.SelectedItem as Contexto;
            cklist_Tables.Items.Clear();
            if (ctxSelected!= null)
            {
                cklist_Tables.Items.AddRange(ctxSelected.Tabelas.OrderBy(t=>t).ToArray());
                foreach (var item in ctxSelected.TabelasSelecionadas)
                {
                    cklist_Tables.SetItemCheckState(cklist_Tables.Items.IndexOf(item), CheckState.Checked);
                }
            }

        }

        private void cklist_Tables_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ctxSelected = list_Contexts.SelectedItem as Contexto;
            var itemSelecionado = cklist_Tables.SelectedItem;

            if (itemSelecionado!=null)
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
            list_Contexts.SelectedItem = ctxSelected;
        }

        private void btn_RemoverContexto_Click(object sender, EventArgs e)
        {
            list_Contexts.Items.Remove(list_Contexts.SelectedItem);
        }
    }


}
