using CustomExtensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateProjectDDDUoW._1___Base
{
    public class D_CreateInfraDados
    {
        private static StringBuilder _pRj = new StringBuilder();

        protected string _nomeProjeto = "ModeloDDD";
        protected string _enderecoProjeto = "";
        
        public D_CreateInfraDados(string nomeSolucao, string enderecoRaiz)
        {
            _nomeProjeto = $"{nomeSolucao}.Infra.Dados";
            _enderecoProjeto = $"{enderecoRaiz}\\{nomeSolucao}\\{_nomeProjeto}";
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
            _pRj.AppendLine("");
            _pRj.AppendLine("<PropertyGroup>",1);
            _pRj.AppendLine("<TargetFramework>netcoreapp2.0</TargetFramework>",2);
            _pRj.AppendLine("</PropertyGroup>",1);
            _pRj.AppendLine("");
            _pRj.AppendLine("<ItemGroup>",1);
            _pRj.AppendLine("<Compile Remove=\"Configuracoes\\**\\\" />",2);
            _pRj.AppendLine("<EmbeddedResource Remove=\"Configuracoes\\**\\\" />",2);
            _pRj.AppendLine("<None Remove=\"Configuracoes\\**\\\" />",2);
            _pRj.AppendLine("</ItemGroup>",1);
            _pRj.AppendLine("");
            _pRj.AppendLine("<ItemGroup>",1);
            _pRj.AppendLine("<PackageReference Include=\"AutoMapper.Extensions.Microsoft.DependencyInjection\" Version=\"3.0.1\" />",2);
            _pRj.AppendLine("<PackageReference Include=\"Dapper\" Version=\"1.50.2\" />",2);
            _pRj.AppendLine("<PackageReference Include=\"Microsoft.Extensions.Configuration\" Version=\"2.0.0\" />",2);
            _pRj.AppendLine("</ItemGroup>",1);
            _pRj.AppendLine("");
            _pRj.AppendLine("<ItemGroup>",1);
            _pRj.AppendLine("<ProjectReference Include=\"..\\DDD_TDD_Dapper_Exemplo.Dominio\\DDD_TDD_Dapper_Exemplo.Dominio.csproj\" />",2);
            _pRj.AppendLine("</ItemGroup>",1);
            _pRj.AppendLine("");
            _pRj.AppendLine("</Project>");

        }
    }
}
