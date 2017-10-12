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
            A_CreateSolution createSln = new A_CreateSolution("C:/Teste/", "Solucao");

            Console.WriteLine("Solution Criada");
            Console.ReadLine();
        }
    }
}
