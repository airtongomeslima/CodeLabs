using CreateProjectDDDUoW._0___Core;
using CreateProjectDDDUoW._1___Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateProjectDDDUoW
{
    class Program
    {
        static void Main(string[] args)
        {
            string solucao = "Solucao";
            string conn = "data source=DESKTOP-AORA6GM;initial catalog=semsdb;Integrated Security=False; User Id=sa;Password=160189;";
            A_CreateSolution createSln = new A_CreateSolution("C:/Teste/", solucao);
            B_CreateProjectTest createProjectTest = new B_CreateProjectTest(solucao, "C:/Teste/");
            C_CreateProjectAPI createProjectAPI = new C_CreateProjectAPI(solucao, "C:/Teste/", conn);

            List<string> classes = SQLTools.GetTables(conn);
            Dictionary<string, string> arquivos = SQLTools.GetClasses(classes, conn);
            foreach (var item in arquivos)
            {
                string endereco = $"C:\\Teste\\Solucao\\{solucao}.Dominio\\Entitades";
                if (!System.IO.Directory.Exists(endereco))
                {
                    System.IO.Directory.CreateDirectory(endereco);
                }

                System.IO.File.WriteAllText(
                    $"{endereco}\\{item.Key}.cs",
                    item.Value
                    );

                //Console.WriteLine($"{item.Key}\r\n{item.Value}\r\n---------------------\r\n\r\n");
            }

            Console.WriteLine("Solution Criada");
            Console.ReadLine();
        }
    }
}
