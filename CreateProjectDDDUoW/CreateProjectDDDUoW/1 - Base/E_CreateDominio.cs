using CreateProjectDDDUoW._0___Core;
using CreateProjectDDDUoW.Models;
using CustomExtensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateProjectDDDUoW._1___Base
{
    public class E_CreateDominio
    {
        protected string _nomeProjeto = "ModeloDDD";
        protected string _baseSolution = "";
        protected string _enderecoProjeto = "";
        protected Dictionary<string, StringBuilder> arquivos = new Dictionary<string, StringBuilder>();

        public E_CreateDominio(string nomeSolucao, string enderecoRaiz, List<Contexto> contextos)
        {
            _nomeProjeto = $"{nomeSolucao}.Dominio";
            _enderecoProjeto = $"{enderecoRaiz}\\{nomeSolucao}\\{_nomeProjeto}";
            _baseSolution = nomeSolucao;
            CreateProject();
            CreateEntidades(contextos);

            CreateIRepositorioBase();
            CreateRepositorioInterfaces(contextos);

            CreateIServicoBase();
            CreateIRepositorioService(contextos);

            CreateServicoBase();
            CreateRepositorioServico(contextos);


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
            arquivo.AppendLine("<PropertyGroup Label=\"Globals\">", 1);
            arquivo.AppendLine("<SccProjectName>SAK</SccProjectName>", 2);
            arquivo.AppendLine("<SccProvider>SAK</SccProvider>", 2);
            arquivo.AppendLine("<SccAuxPath>SAK</SccAuxPath>", 2);
            arquivo.AppendLine("<SccLocalPath>SAK</SccLocalPath>", 2);
            arquivo.AppendLine("</PropertyGroup>", 1);
            arquivo.AppendLine("");
            arquivo.AppendLine("<PropertyGroup>", 1);
            arquivo.AppendLine("<TargetFramework>netcoreapp2.0</TargetFramework>", 2);
            arquivo.AppendLine("</PropertyGroup>", 1);
            arquivo.AppendLine("");
            arquivo.AppendLine("</Project>");


            FolderHelper.Create(_enderecoProjeto);
            string endereco = $"{_nomeProjeto}.csproj";
            arquivos.Add(endereco, arquivo);
        }

        public void CreateEntidades(List<Contexto> contextos)
        {
            foreach (var ctx in contextos)
            {
                Dictionary<string, string> entities = SQLTools.GetClasses(ctx.TabelasSelecionadas, ctx.Nome, ctx.StringConexao, _nomeProjeto);
                foreach (var item in entities)
                {
                    var repos = item.Key;
                    if (item.Key.Contains("."))
                    {
                        repos = item.Key.Split('.')[1];
                    }

                    FolderHelper.Create($"{_enderecoProjeto}\\Entidades\\{ctx.Nome}");
                    string endereco = $"{_enderecoProjeto}\\Entidades\\{ctx.Nome}\\{repos}.cs";

                    File.WriteAllText(endereco, item.Value);
                }
            }
        }

        public void CreateIRepositorioBase()
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

            FolderHelper.Create($"{_enderecoProjeto}\\Interfaces\\Repositorios");
            string endereco = $"Interfaces\\Repositorios\\IRepositorioBase.cs";
            arquivos.Add(endereco, arquivo);
        }

        public void CreateRepositorioInterfaces(List<Contexto> contextos)
        {
            foreach (var ctx in contextos)
            {
                foreach (var repo in ctx.TabelasSelecionadas)
                {
                    var repos = repo;
                    if (repo.Contains("."))
                    {
                        repos = repo.Split('.')[1];
                    }

                    StringBuilder arquivo = new StringBuilder();

                    arquivo.AppendLine($"using {_nomeProjeto}.Entitades.{ctx.Nome};");
                    arquivo.AppendLine("");
                    arquivo.AppendLine($"namespace {_nomeProjeto}.Interfaces.Repositorios.{ctx.Nome}");
                    arquivo.AppendLine("{");
                    arquivo.AppendLine($"public interface I{repos}Repositorio : IRepositorioBase<{repos}Entity>", 1);
                    arquivo.AppendLine("{", 1);
                    arquivo.AppendLine("}", 1);
                    arquivo.AppendLine("}");


                    FolderHelper.Create($"{_enderecoProjeto}\\Interfaces\\Repositorios\\{ctx.Nome}");
                    string endereco = $"Interfaces\\Repositorios\\{ctx.Nome}\\I{repos}Repositorio.cs";
                    arquivos.Add(endereco, arquivo);
                }
            }
        }

        public void CreateIServicoBase()
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


            FolderHelper.Create($"{_enderecoProjeto}\\Interfaces\\Servicos");
            string endereco = $"Interfaces\\Servicos\\IServicoBase.cs";
            arquivos.Add(endereco, arquivo);
        }

        public void CreateIRepositorioService(List<Contexto> contextos)
        {
            foreach (var ctx in contextos)
            {
                foreach (var repo in ctx.TabelasSelecionadas)
                {
                    var repos = repo;
                    if (repo.Contains("."))
                    {
                        repos = repo.Split('.')[1];
                    }
                    StringBuilder arquivo = new StringBuilder();

                    arquivo.AppendLine($"using {_nomeProjeto}.Entitades.{ctx.Nome};");
                    arquivo.AppendLine("");
                    arquivo.AppendLine($"namespace {_nomeProjeto}.Interfaces.Servicos.{ctx.Nome}");
                    arquivo.AppendLine("{");
                    arquivo.AppendLine($"public interface I{repos}Servico : IServicoBase<{repos}Entity>", 1);
                    arquivo.AppendLine("{", 1);
                    arquivo.AppendLine("}", 1);
                    arquivo.AppendLine("}");


                    FolderHelper.Create($"{_enderecoProjeto}\\Interfaces\\Servicos\\{ctx.Nome}");
                    string endereco = $"Interfaces\\Servicos\\{ctx.Nome}\\I{repos}Servico.cs";
                    arquivos.Add(endereco, arquivo);
                }
            }
        }

        public void CreateServicoBase()
        {
            StringBuilder arquivo = new StringBuilder();

            arquivo.AppendLine($"using {_nomeProjeto}.Interfaces.Repositorios;");
            arquivo.AppendLine($"using {_nomeProjeto}.Interfaces.Servicos;");
            arquivo.AppendLine("using System;");
            arquivo.AppendLine("using System.Collections.Generic;");
            arquivo.AppendLine("");
            arquivo.AppendLine($"namespace {_nomeProjeto}.Servicos", 2);
            arquivo.AppendLine("{");
            arquivo.AppendLine("public class ServicoBase<TEntity> : IDisposable, IServicoBase<TEntity> where TEntity : class");
            arquivo.AppendLine("{", 1);
            arquivo.AppendLine("private readonly IRepositorioBase<TEntity> _repositorio;", 2);
            arquivo.AppendLine("");
            arquivo.AppendLine("public ServicoBase(IRepositorioBase<TEntity> repositorio)", 2);
            arquivo.AppendLine("{", 2);
            arquivo.AppendLine("_repositorio = repositorio;", 3);
            arquivo.AppendLine("}", 2);
            arquivo.AppendLine("");
            arquivo.AppendLine("public void Adicionar(TEntity obj)", 2);
            arquivo.AppendLine("{", 2);
            arquivo.AppendLine("_repositorio.Adicionar(obj);", 3);
            arquivo.AppendLine("}", 2);
            arquivo.AppendLine("");
            arquivo.AppendLine("public TEntity ObterPorId(int id)", 2);
            arquivo.AppendLine("{", 2);
            arquivo.AppendLine("return _repositorio.ObterPorId(id);", 3);
            arquivo.AppendLine("}", 2);
            arquivo.AppendLine("");
            arquivo.AppendLine("public IEnumerable<TEntity> ObterTodos()", 2);
            arquivo.AppendLine("{", 2);
            arquivo.AppendLine("return _repositorio.ObterTodos();", 3);
            arquivo.AppendLine("}", 2);
            arquivo.AppendLine("");
            arquivo.AppendLine("public void Remover(TEntity obj)", 2);
            arquivo.AppendLine("{", 2);
            arquivo.AppendLine("_repositorio.Remover(obj);", 3);
            arquivo.AppendLine("}", 2);
            arquivo.AppendLine("");
            arquivo.AppendLine("public void Atualizar(TEntity obj)", 2);
            arquivo.AppendLine("{", 2);
            arquivo.AppendLine("_repositorio.Atualizar(obj);", 3);
            arquivo.AppendLine("}", 2);
            arquivo.AppendLine("");
            arquivo.AppendLine("public void Dispose()", 2);
            arquivo.AppendLine("{", 2);
            arquivo.AppendLine("_repositorio.Dispose();", 3);
            arquivo.AppendLine("}", 2);
            arquivo.AppendLine("}", 1);
            arquivo.AppendLine("}");

            FolderHelper.Create($"{_enderecoProjeto}\\Servicos");
            string endereco = $"Servicos\\ServicoBase.cs";
            arquivos.Add(endereco, arquivo);
        }

        public void CreateRepositorioServico(List<Contexto> contextos)
        {
            foreach (var ctx in contextos)
            {
                foreach (var repo in ctx.TabelasSelecionadas)
                {
                    var repos = repo;
                    if (repo.Contains("."))
                    {
                        repos = repo.Split('.')[1];
                    }
                    StringBuilder arquivo = new StringBuilder();

                    arquivo.AppendLine($"using {_nomeProjeto}.Entitades.{ctx.Nome};");
                    arquivo.AppendLine($"using {_nomeProjeto}.Interfaces.Servicos.{ctx.Nome};");
                    arquivo.AppendLine($"using {_nomeProjeto}.Interfaces.Repositorios.{ctx.Nome};");
                    arquivo.AppendLine("");
                    arquivo.AppendLine($"namespace {_nomeProjeto}.Servicos.{ctx.Nome}");
                    arquivo.AppendLine("{");
                    arquivo.AppendLine($"public class {repos}Servico : ServicoBase<{repos}Entity>, I{repos}Servico", 1);
                    arquivo.AppendLine("{", 1);
                    arquivo.AppendLine($"private I{repos}Repositorio _repositorio;", 2);
                    arquivo.AppendLine("");
                    arquivo.AppendLine($"public {repos}Servico(I{repos}Repositorio repositorio) : base(repositorio)", 2);
                    arquivo.AppendLine("{", 2);
                    arquivo.AppendLine("_repositorio = repositorio;", 3);
                    arquivo.AppendLine("}", 2);
                    arquivo.AppendLine("}", 1);
                    arquivo.AppendLine("}");
                    
                    FolderHelper.Create($"{_enderecoProjeto}\\Servicos\\{ctx.Nome}");
                    string endereco = $"Servicos\\{ctx.Nome}\\{repos}Servico.cs";
                    arquivos.Add(endereco, arquivo);
                }
            }
        }
    }
}
