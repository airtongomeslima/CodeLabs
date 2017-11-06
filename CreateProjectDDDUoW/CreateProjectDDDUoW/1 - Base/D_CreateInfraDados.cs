using CreateProjectDDDUoW._0___Core;
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
        protected string _nomeProjeto = "ModeloDDD";
        protected string _enderecoProjeto = "";
        protected Dictionary<string, StringBuilder> arquivos = new Dictionary<string, StringBuilder>();

        public D_CreateInfraDados(string nomeSolucao, string enderecoRaiz, List<Dictionary<string, string>> entities)
        {
            _nomeProjeto = $"{nomeSolucao}.Infra.Dados";
            _enderecoProjeto = $"{enderecoRaiz}\\{nomeSolucao}\\{_nomeProjeto}";
            CreateProject();

            foreach (var item in arquivos)
            {
                string arquivo = $"{_enderecoProjeto}\\{item.Key}";
                if (File.Exists(arquivo))
                {
                    File.Delete(arquivo);
                }

                File.WriteAllText(arquivo, item.Value.ToString());
            }
        }

        public void CreateProject()
        {
            StringBuilder arquivo = new StringBuilder();

            arquivo.AppendLine("<Project Sdk=\"Microsoft.NET.Sdk\">");
            arquivo.AppendLine("");
            arquivo.AppendLine("<PropertyGroup>", 1);
            arquivo.AppendLine("<TargetFramework>netcoreapp2.0</TargetFramework>", 2);
            arquivo.AppendLine("</PropertyGroup>", 1);
            arquivo.AppendLine("");
            arquivo.AppendLine("<ItemGroup>", 1);
            arquivo.AppendLine("<Compile Remove=\"Configuracoes\\**\\\" />", 2);
            arquivo.AppendLine("<EmbeddedResource Remove=\"Configuracoes\\**\\\" />", 2);
            arquivo.AppendLine("<None Remove=\"Configuracoes\\**\\\" />", 2);
            arquivo.AppendLine("</ItemGroup>", 1);
            arquivo.AppendLine("");
            arquivo.AppendLine("<ItemGroup>", 1);
            arquivo.AppendLine("<PackageReference Include=\"AutoMapper.Extensions.Microsoft.DependencyInjection\" Version=\"3.0.1\" />", 2);
            arquivo.AppendLine("<PackageReference Include=\"Dapper\" Version=\"1.50.2\" />", 2);
            arquivo.AppendLine("<PackageReference Include=\"Microsoft.Extensions.Configuration\" Version=\"2.0.0\" />", 2);
            arquivo.AppendLine("</ItemGroup>", 1);
            arquivo.AppendLine("");
            arquivo.AppendLine("<ItemGroup>", 1);
            arquivo.AppendLine($"<ProjectReference Include=\"..\\{_nomeProjeto}\\{_nomeProjeto}.Dominio.csproj\" />", 2);
            arquivo.AppendLine("</ItemGroup>", 1);
            arquivo.AppendLine("");
            arquivo.AppendLine("</Project>");

            FolderHelper.Create(_enderecoProjeto);
            string endereco = $"{_nomeProjeto}.csproj";
            arquivos.Add(endereco, arquivo);
        }

        public void CreateRepositoryFile()
        {
            StringBuilder arquivo = new StringBuilder();

            arquivo.AppendLine("using Microsoft.Extensions.Configuration;");
            arquivo.AppendLine("using ModeloDDD.Dominio.Interfaces.Repositorios;");
            arquivo.AppendLine("using System;");
            arquivo.AppendLine("using System.Collections.Generic;");
            arquivo.AppendLine("");
            arquivo.AppendLine($"namespace {_nomeProjeto}.Infra.Dados.Respositorio");
            arquivo.AppendLine("{");
            arquivo.AppendLine("public class RepositorioBase<TEntity> : IDisposable, IRepositorioBase<TEntity> where TEntity : class",1);
            arquivo.AppendLine("{",1);
            arquivo.AppendLine("protected Contexto.Contexto contexto;",2);
            arquivo.AppendLine("");
            arquivo.AppendLine("public RepositorioBase(IConfiguration config)",2);
            arquivo.AppendLine("{", 2);
            arquivo.AppendLine("contexto = new Contexto.Contexto(config);", 3);
            arquivo.AppendLine("}", 2);
            arquivo.AppendLine("");
            arquivo.AppendLine("public void Adicionar(TEntity obj)", 2);
            arquivo.AppendLine("{", 2);
            arquivo.AppendLine("contexto.Inserir<TEntity>(obj);", 3);
            arquivo.AppendLine("}", 2);
            arquivo.AppendLine("");
            arquivo.AppendLine("public void Atualizar(TEntity obj)", 2);
            arquivo.AppendLine("{", 2);
            arquivo.AppendLine("contexto.Atualizar<TEntity>(obj);", 3);
            arquivo.AppendLine("}", 2);
            arquivo.AppendLine("");
            arquivo.AppendLine("public TEntity ObterPorId(int id)", 2);
            arquivo.AppendLine("{", 2);
            arquivo.AppendLine("return contexto.ObterPorId<TEntity>(id);", 3);
            arquivo.AppendLine("}", 2);
            arquivo.AppendLine("");
            arquivo.AppendLine("public IEnumerable<TEntity> ObterTodos()", 2);
            arquivo.AppendLine("{", 2);
            arquivo.AppendLine("return contexto.LerTudo<TEntity>();", 3);
            arquivo.AppendLine("}", 2);
            arquivo.AppendLine("");
            arquivo.AppendLine("public IEnumerable<TEntity> Where(string param)", 2);
            arquivo.AppendLine("{", 2);
            arquivo.AppendLine("return contexto.Where<TEntity>(param);", 3);
            arquivo.AppendLine("}", 2);
            arquivo.AppendLine("");
            arquivo.AppendLine("public void Remover(int id)", 2);
            arquivo.AppendLine("{", 2);
            arquivo.AppendLine("contexto.Deletar<TEntity>(id);", 3);
            arquivo.AppendLine("}", 2);
            arquivo.AppendLine("");
            arquivo.AppendLine("public void Dispose()", 2);
            arquivo.AppendLine("{", 2);
            arquivo.AppendLine("contexto.Dispose();", 3);
            arquivo.AppendLine("}", 2);
            arquivo.AppendLine("}");
            arquivo.AppendLine("}");

            FolderHelper.Create($"{_enderecoProjeto}\\Repository");
            string endereco = $"Repository\\{_nomeProjeto}.csproj";
            arquivos.Add(endereco, arquivo);
        }

        public void CreateEntityContext()
        {
            StringBuilder arquivo = new StringBuilder();

            FolderHelper.Create($"{_enderecoProjeto}\\Context");
            string endereco = $"Context\\context.cs";
            arquivos.Add(endereco, arquivo);
        }

        public void CreateDapperContext()
        {
            StringBuilder arquivo = new StringBuilder();

            FolderHelper.Create($"{_enderecoProjeto}\\Context");
            string endereco = $"Context\\context.cs";
            arquivos.Add(endereco, arquivo);
        }
    }
}
