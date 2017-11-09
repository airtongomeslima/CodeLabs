﻿using CreateProjectDDDUoW._0___Core;
using CustomExtensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateProjectDDDUoW._1___Base
{
    public class F_CreateAplicacao
    {
        protected string _nomeProjeto = "ModeloDDD";
        protected string _baseSolution = "";
        protected string _enderecoProjeto = "";
        protected string _connectionString = "";
        protected Dictionary<string, StringBuilder> arquivos = new Dictionary<string, StringBuilder>();

        public F_CreateAplicacao(string nomeSolucao, string connectionstring, string enderecoRaiz, List<string> repositorios)
        {
            _connectionString = connectionstring;
            _nomeProjeto = $"{nomeSolucao}.Aplicacao";
            _enderecoProjeto = $"{enderecoRaiz}\\{nomeSolucao}\\{_nomeProjeto}";
            _baseSolution = nomeSolucao;

            CreateProject();
            CreateIAppServicoBase();
            CreateIRepositorioAppServico(repositorios);

            CreateAppServicoBase();
            CreateRepositorioAppServico(repositorios);


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

            arquivo.AppendLine("<Project Sdk=\"Microsoft.NET.Sdk\">", 2);
            arquivo.AppendLine("");
            arquivo.AppendLine("  <PropertyGroup Label=\"Globals\">", 1);
            arquivo.AppendLine("    <SccProjectName>SAK</SccProjectName>", 2);
            arquivo.AppendLine("    <SccProvider>SAK</SccProvider>", 2);
            arquivo.AppendLine("    <SccAuxPath>SAK</SccAuxPath>", 2);
            arquivo.AppendLine("    <SccLocalPath>SAK</SccLocalPath>", 2);
            arquivo.AppendLine("  </PropertyGroup>", 1);
            arquivo.AppendLine("");
            arquivo.AppendLine("  <PropertyGroup>", 1);
            arquivo.AppendLine("    <TargetFramework>netcoreapp2.0</TargetFramework>", 2);
            arquivo.AppendLine("  </PropertyGroup>", 1);
            arquivo.AppendLine("");
            arquivo.AppendLine("  <ItemGroup>", 1);
            arquivo.AppendLine($"    <ProjectReference Include=\"..\\{_baseSolution}.Dominio\\ModeloDDD.Dominio.csproj\" />", 2);
            arquivo.AppendLine("  </ItemGroup>", 1);
            arquivo.AppendLine("");
            arquivo.AppendLine("</Project>");
            
            FolderHelper.Create(_enderecoProjeto);
            string endereco = $"{_nomeProjeto}.csproj";
            arquivos.Add(endereco, arquivo);
        }
        
        public void CreateIAppServicoBase()
        {
            StringBuilder arquivo = new StringBuilder();

            arquivo.AppendLine("using System.Collections.Generic;");
            arquivo.AppendLine("");
            arquivo.AppendLine($"namespace {_nomeProjeto}.Interfaces.Repositorios");
            arquivo.AppendLine("{");
            arquivo.AppendLine("public interface IRepositorioBase<TEntity> where TEntity : class", 1);
            arquivo.AppendLine("{", 1);
            arquivo.AppendLine("void Adicionar(TEntity obj);", 3);
            arquivo.AppendLine("TEntity ObterPorId(int id);", 3);
            arquivo.AppendLine("IEnumerable<TEntity> ObterTodos();", 3);
            arquivo.AppendLine("void Atualizar(TEntity obj);", 3);
            arquivo.AppendLine("void Remover(TEntity obj);", 3);
            arquivo.AppendLine("void Dispose();", 3);
            arquivo.AppendLine("}", 1);
            arquivo.AppendLine("}");

            FolderHelper.Create($"{_enderecoProjeto}\\Interfaces");
            string endereco = $"Interfaces\\IAppServicoBase.cs";
            arquivos.Add(endereco, arquivo);
        }

        public void CreateIRepositorioAppServico(List<string> repositorios)
        {

            foreach (var repo in repositorios)
            {
                var repos = repo;
                if (repo.Contains("."))
                {
                    repos = repo.Split('.')[1];
                }

                StringBuilder arquivo = new StringBuilder();

                arquivo.AppendLine($"using {_nomeProjeto}.Entitades;");
                arquivo.AppendLine("");
                arquivo.AppendLine($"namespace {_nomeProjeto}.Interfaces.Repositorios");
                arquivo.AppendLine("{");
                arquivo.AppendLine($"public interface I{repos}Repositorio : IRepositorioBase<{repos}>", 1);
                arquivo.AppendLine("{", 1);
                arquivo.AppendLine("}", 1);
                arquivo.AppendLine("}");


                FolderHelper.Create($"{_enderecoProjeto}\\Interfaces");
                string endereco = $"Interfaces\\I{repos}AppServico.cs";
                arquivos.Add(endereco, arquivo);
            }
        }

        public void CreateAppServicoBase()
        {
            StringBuilder arquivo = new StringBuilder();

            arquivo.AppendLine("using System.Collections.Generic;");
            arquivo.AppendLine("");
            arquivo.AppendLine($"namespace {_nomeProjeto}.Interfaces.Servicos");
            arquivo.AppendLine("{");
            arquivo.AppendLine("    public interface IServicoBase<TEntity> where TEntity : class", 1);
            arquivo.AppendLine("    {", 1);
            arquivo.AppendLine("        void Adicionar(TEntity obj);", 2);
            arquivo.AppendLine("        IEnumerable<TEntity> ObterTodos();", 2);
            arquivo.AppendLine("        TEntity ObterPorId(int id);", 2);
            arquivo.AppendLine("        void Atualizar(TEntity obj);", 2);
            arquivo.AppendLine("        void Remover(TEntity obj);", 2);
            arquivo.AppendLine("        void Dispose();", 2);
            arquivo.AppendLine("    }", 1);
            arquivo.AppendLine("}");


            FolderHelper.Create($"{_enderecoProjeto}");
            string endereco = $"AppServicoBase.cs";
            arquivos.Add(endereco, arquivo);
        }

        public void CreateRepositorioAppServico(List<string> repositorios)
        {

            foreach (var repo in repositorios)
            {
                var repos = repo;
                if (repo.Contains("."))
                {
                    repos = repo.Split('.')[1];
                }
                StringBuilder arquivo = new StringBuilder();

                arquivo.AppendLine($"using {_nomeProjeto}.Entitades;");
                arquivo.AppendLine($"using {_nomeProjeto}.Interfaces.Servicos;");
                arquivo.AppendLine("using System.Collections.Generic;");
                arquivo.AppendLine("");
                arquivo.AppendLine($"namespace {_nomeProjeto}.Interfaces.Servicos");
                arquivo.AppendLine("{");
                arquivo.AppendLine($"public interface I{repos}Servico : IServicoBase<{repos}>", 1);
                arquivo.AppendLine("{", 1);
                arquivo.AppendLine("}", 1);
                arquivo.AppendLine("}");


                FolderHelper.Create($"{_enderecoProjeto}");
                string endereco = $"{repos}AppServico.cs";
                arquivos.Add(endereco, arquivo);
            }
        }
    }
}