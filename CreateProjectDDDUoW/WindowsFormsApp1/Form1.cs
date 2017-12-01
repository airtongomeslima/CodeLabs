using CreateProjectDDDUoW._0___Core;
using CreateProjectDDDUoW._1___Base;
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

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            A_CreateSolution createSln = new A_CreateSolution(endereco, solucao);
            B_CreateProjectTest createProjectTest = new B_CreateProjectTest(solucao, endereco);


            D_CreateInfraDados createInfraDados = new D_CreateInfraDados(solucao, endereco, classes, 2);
            C_CreateProjectAPI createProjectAPI = new C_CreateProjectAPI(solucao, endereco, conn, classes);
            E_CreateDominio criarDominio = new E_CreateDominio(solucao, conn, endereco, classes);
            F_CreateAplicacao criarAppServico = new F_CreateAplicacao(solucao, conn, endereco, classes);
            G_CreateInfraSQL createInfraSQL = new G_CreateInfraSQL(solucao, conn, endereco, classes);
            H_CreateDTOProject createDTOProject = new H_CreateDTOProject(solucao, conn, endereco, classes);

            Console.WriteLine("Solution Criada");
            Console.ReadLine();
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

        }
    }
}
