using CustomExtensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateProjectDDDUoW._1___Base
{
    public class B_CreateProjectTest
    {
        private static StringBuilder _pRj = new StringBuilder();

        protected string _nomeProjeto = "ModeloDDD";
        protected string _baseSolution = "";
        protected string _enderecoProjeto = "";

        /// <summary>
        /// Criar projeto de Testes unitários
        /// </summary>
        /// <param name="nomeSolucao">Nome do projeto (ex. ModeloDDD, não precisa colocar o .Test nem o .csproj)</param>
        /// <param name="enderecoRaiz"></param>
        public B_CreateProjectTest(string nomeSolucao, string enderecoRaiz)
        {
            _nomeProjeto = $"{nomeSolucao}.Test";
            _enderecoProjeto = $"{enderecoRaiz}\\{nomeSolucao}\\{_nomeProjeto}";
            _baseSolution = nomeSolucao;
            CreateProject();

            if (!Directory.Exists(_enderecoProjeto))
            {
                Directory.CreateDirectory(_enderecoProjeto);
            }

            string arquivo = $"{_enderecoProjeto}\\{_nomeProjeto}.csproj";
            if (File.Exists(arquivo))
            {
                File.Delete(arquivo);
            }

            File.WriteAllText(arquivo, _pRj.ToString());
        }

        public void CreateProject()
        {
            _pRj.AppendLine("<Project Sdk=\"Microsoft.NET.Sdk\">");

            _pRj.AppendLine("<PropertyGroup Label=\"Globals\">", 1);
            _pRj.AppendLine("<SccProjectName>SAK</SccProjectName>", 2);
            _pRj.AppendLine("<SccProvider>SAK</SccProvider>",2);
            _pRj.AppendLine("<SccAuxPath>SAK</SccAuxPath>",2);
            _pRj.AppendLine("<SccLocalPath>SAK</SccLocalPath>",2);
            _pRj.AppendLine("</PropertyGroup>",1);
            _pRj.AppendLine("");
            _pRj.AppendLine("<PropertyGroup>",1);
            _pRj.AppendLine("<TargetFramework>netcoreapp2.0</TargetFramework>",2);
            _pRj.AppendLine("");
            _pRj.AppendLine("<IsPackable>false</IsPackable>",2);
            _pRj.AppendLine("</PropertyGroup>",1);
            _pRj.AppendLine("");
            _pRj.AppendLine("<ItemGroup>",1);
            _pRj.AppendLine("<PackageReference Include=\"Microsoft.NET.Test.Sdk\" Version=\"15.3.0-preview-20170628-02\" />", 2);
            _pRj.AppendLine("<PackageReference Include=\"MSTest.TestAdapter\" Version=\"1.1.18\" />", 2);
            _pRj.AppendLine("<PackageReference Include=\"MSTest.TestFramework\" Version=\"1.1.18\" />",2);
            _pRj.AppendLine("</ItemGroup>",1);
            _pRj.AppendLine("");
            _pRj.AppendLine("</Project>");

        }
    }
}
