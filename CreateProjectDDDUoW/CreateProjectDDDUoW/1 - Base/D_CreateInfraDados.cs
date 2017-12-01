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
    public class D_CreateInfraDados
    {
        protected string _nomeProjeto = "ModeloDDD";
        protected string _baseSolution = "ModeloDDD";
        protected string _enderecoProjeto = "";
        protected int _tipoContexto = 1;
        protected Dictionary<string, StringBuilder> arquivos = new Dictionary<string, StringBuilder>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nomeSolucao"></param>
        /// <param name="enderecoRaiz"></param>
        /// <param name="repositorios"></param>
        /// <param name="tipoContexto">(1 = Entity Framework, 2 = Dapper)</param>
        public D_CreateInfraDados(string nomeSolucao, string enderecoRaiz, List<Contexto> contextos, int tipoContexto)
        {
            _nomeProjeto = $"{nomeSolucao}.Infra.Dados";
            _baseSolution = nomeSolucao;
            _enderecoProjeto = $"{enderecoRaiz}\\{nomeSolucao}\\{_nomeProjeto}";
            CreateProject();
            CreateRepositorioBase();
            CreateRepositorios(contextos);

            if (tipoContexto == 1)
            {
                CreateEntityContext(contextos);
            }
            else if (tipoContexto == 2)
            {
                CreateDapperContext();
            }



            foreach (var item in arquivos)
            {
                string arquivo = $"{_enderecoProjeto}\\{item.Key}";
                if (File.Exists(arquivo))
                {
                    File.Delete(arquivo);
                }

                try
                {
                    File.WriteAllText(arquivo, item.Value.ToString());
                }
                catch (Exception)
                {
                }

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
            arquivo.AppendLine("<PackageReference Include=\"Microsoft.Extensions.Configuration\" Version=\"2.0.0\" />", 2);
            if (_tipoContexto == 1)
            {
                arquivo.AppendLine("<PackageReference Include=\"Microsoft.EntityFrameworkCore\" Version=\"2.0.1\" />", 2);
                arquivo.AppendLine("<PackageReference Include=\"Microsoft.EntityFrameworkCore.SqlServer\" Version=\"2.0.1\" />", 2);
            }
            else
            {
                arquivo.AppendLine("<PackageReference Include=\"Dapper\" Version=\"1.50.2\" />", 2);
            }
            arquivo.AppendLine("</ItemGroup>", 1);
            arquivo.AppendLine("");
            arquivo.AppendLine("<ItemGroup>", 1);
            arquivo.AppendLine($"<ProjectReference Include=\"..\\{_baseSolution}.Dominio\\{_baseSolution}.Dominio.csproj\" />", 2);
            arquivo.AppendLine("</ItemGroup>", 1);
            arquivo.AppendLine("");
            arquivo.AppendLine("</Project>");

            FolderHelper.Create(_enderecoProjeto);
            string endereco = $"{_nomeProjeto}.csproj";
            try
            {
                arquivos.Add(endereco, arquivo);
            }
            catch (Exception)
            {

            }
        }

        public void CreateRepositorioBase()
        {
            StringBuilder arquivo = new StringBuilder();

            arquivo.AppendLine("using Microsoft.Extensions.Configuration;");
            arquivo.AppendLine($"using {_baseSolution}.Dominio.Interfaces.Repositorios;");
            arquivo.AppendLine("using System;");
            arquivo.AppendLine("using System.Collections.Generic;");
            arquivo.AppendLine("using System.Linq;");
            arquivo.AppendLine("");
            arquivo.AppendLine($"namespace {_nomeProjeto}.Repositorio");
            arquivo.AppendLine("{");
            arquivo.AppendLine("public class RepositorioBase<TEntity> : IDisposable, IRepositorioBase<TEntity> where TEntity : class", 1);
            arquivo.AppendLine("{", 1);
            arquivo.AppendLine("protected Contexto.Contexto contexto;", 2);
            arquivo.AppendLine("");
            arquivo.AppendLine("public RepositorioBase(IConfiguration config)", 2);
            arquivo.AppendLine("{", 2);
            arquivo.AppendLine("contexto = new Contexto.Contexto(config);", 3);
            arquivo.AppendLine("}", 2);
            arquivo.AppendLine("");
            arquivo.AppendLine("public void Adicionar(TEntity obj)", 2);
            arquivo.AppendLine("{", 2);
            arquivo.AppendLine("contexto.Add<TEntity>(obj);", 3);
            arquivo.AppendLine("}", 2);
            arquivo.AppendLine("");
            arquivo.AppendLine("public void Atualizar(TEntity obj)", 2);
            arquivo.AppendLine("{", 2);
            arquivo.AppendLine("contexto.Update<TEntity>(obj);", 3);
            arquivo.AppendLine("}", 2);
            arquivo.AppendLine("");
            arquivo.AppendLine("public TEntity ObterPorId(int id)", 2);
            arquivo.AppendLine("{", 2);
            arquivo.AppendLine("return contexto.Find<TEntity>(id);", 3);
            arquivo.AppendLine("}", 2);
            arquivo.AppendLine("");
            arquivo.AppendLine("public IEnumerable<TEntity> ObterTodos()", 2);
            arquivo.AppendLine("{", 2);
            arquivo.AppendLine("return contexto.Set<TEntity>();", 3);
            arquivo.AppendLine("}", 2);
            arquivo.AppendLine("");
            arquivo.AppendLine("public void Remover(TEntity obj)", 2);
            arquivo.AppendLine("{", 2);
            arquivo.AppendLine("contexto.Remove<TEntity>(obj);", 3);
            arquivo.AppendLine("}", 2);
            arquivo.AppendLine("");
            arquivo.AppendLine("public void Dispose()", 2);
            arquivo.AppendLine("{", 2);
            arquivo.AppendLine("contexto.Dispose();", 3);
            arquivo.AppendLine("}", 2);
            arquivo.AppendLine("}", 1);
            arquivo.AppendLine("}");

            FolderHelper.Create($"{_enderecoProjeto}\\Repositorio");
            string endereco = $"Repositorio\\RepositorioBase.cs";
            try
            {
                arquivos.Add(endereco, arquivo);
            }
            catch (Exception)
            {

            }
        }

        public void CreateRepositorios(List<Contexto> contextos)
        {
            foreach (var contexto in contextos)
            {
                foreach (var repo in contexto.TabelasSelecionadas)
                {
                    var item = repo;
                    if (repo.Contains("."))
                    {
                        item = repo.Split('.')[1];
                    }

                    StringBuilder arquivo = new StringBuilder();

                    arquivo.AppendLine("using Microsoft.Extensions.Configuration;");
                    arquivo.AppendLine($"using {_baseSolution}.Dominio.Entitades;");
                    arquivo.AppendLine($"using {_baseSolution}.Dominio.Interfaces.Repositorios;");
                    arquivo.AppendLine("");
                    arquivo.AppendLine($"namespace {contexto.Nome}.{_nomeProjeto}.Repositorio");
                    arquivo.AppendLine("{");
                    arquivo.AppendLine($"public class {item}Repositorio : RepositorioBase<{item}Entity>, I{item}Repositorio", 1);
                    arquivo.AppendLine("{", 1);
                    arquivo.AppendLine($"public {item}Repositorio(IConfiguration config) : base(config)", 2);
                    arquivo.AppendLine("{", 2);
                    arquivo.AppendLine("}", 2);
                    arquivo.AppendLine("}", 1);
                    arquivo.AppendLine("}");

                    FolderHelper.Create($"{_enderecoProjeto}\\Repositorio");
                    string endereco = $"Repositorio\\{contexto.Nome}\\{item}.cs";
                    try
                    {
                        arquivos.Add(endereco, arquivo);
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }

        public void CreateEntityContext(List<Contexto> contextos)
        {
            foreach (var contexto in contextos)
            {
                StringBuilder arquivo = new StringBuilder();

                arquivo.AppendLine("using Microsoft.EntityFrameworkCore;");
                arquivo.AppendLine("using Microsoft.Extensions.Configuration;");
                arquivo.AppendLine($"using {_baseSolution}.Dominio.Entitades.{contexto.Nome};");
                arquivo.AppendLine("using System;");
                arquivo.AppendLine("using System.Collections.Generic;");
                arquivo.AppendLine("using System.Linq;");
                arquivo.AppendLine("using System.Text;");
                arquivo.AppendLine("");
                arquivo.AppendLine($"namespace {_nomeProjeto}.Contexto{contexto.Nome}");
                arquivo.AppendLine("{");
                arquivo.AppendLine("public partial class Contexto : DbContext", 1);
                arquivo.AppendLine("{", 1);
                arquivo.AppendLine("IConfiguration _config;", 2);
                arquivo.AppendLine("");
                arquivo.AppendLine("public Contexto(IConfiguration config)", 2);
                arquivo.AppendLine("{", 2);
                arquivo.AppendLine("_config = config;", 3);
                arquivo.AppendLine("}", 2);
                arquivo.AppendLine("");
                arquivo.AppendLine("protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)", 2);
                arquivo.AppendLine("{", 2);
                arquivo.AppendLine($"optionsBuilder.UseSqlServer(_config.GetConnectionString(\"{contexto.StringConexaoNome}\"));", 3);
                arquivo.AppendLine("}", 2);
                arquivo.AppendLine("");

                foreach (var repo in contexto.TabelasSelecionadas)
                {
                    var entidade = repo;
                    if (repo.Contains("."))
                    {
                        entidade = repo.Split('.')[1];
                    }
                    arquivo.AppendLine($"public virtual DbSet<{entidade}> {entidade} {{ get; set; }}", 2);
                }


                arquivo.AppendLine("");
                arquivo.AppendLine("protected override void OnModelCreating(ModelBuilder modelBuilder)", 2);
                arquivo.AppendLine("{", 2);
                arquivo.AppendLine("//A regra padrão para quando houver tentativa de deletar registro com relação", 3);
                arquivo.AppendLine("foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))", 3);
                arquivo.AppendLine("{", 3);
                arquivo.AppendLine("    relationship.DeleteBehavior = DeleteBehavior.Restrict;", 4);
                arquivo.AppendLine("}", 3);
                arquivo.AppendLine("");
                arquivo.AppendLine("base.OnModelCreating(modelBuilder);", 3);
                arquivo.AppendLine("////Coloque aqui as relações, não vou fazer isso, ai é preguiça de mais", 3);
                arquivo.AppendLine("}", 2);
                arquivo.AppendLine("");
                arquivo.AppendLine("}", 1);
                arquivo.AppendLine("}");


                FolderHelper.Create($"{_enderecoProjeto}\\Context{contexto.Nome}");
                string endereco = $"Context\\Context{contexto.Nome}.cs";
                try
                {
                    arquivos.Add(endereco, arquivo);
                }
                catch (Exception)
                {

                }
            }
        }

        public void CreateDapperContext()
        {
            StringBuilder arquivo = new StringBuilder();

            arquivo.AppendLine("using Dapper;");
            arquivo.AppendLine("using Microsoft.Extensions.Configuration;");
            arquivo.AppendLine("using System;");
            arquivo.AppendLine("using System.Collections.Generic;");
            arquivo.AppendLine("using System.ComponentModel.DataAnnotations;");
            arquivo.AppendLine("using System.Data;");
            arquivo.AppendLine("using System.Data.SqlClient;");
            arquivo.AppendLine("using System.Linq;");
            arquivo.AppendLine("using System.Reflection;");
            arquivo.AppendLine("");
            arquivo.AppendLine($"namespace {_nomeProjeto}.Contexto");
            arquivo.AppendLine("{");
            arquivo.AppendLine("/// <summary>", 1);
            arquivo.AppendLine("/// Falta adicionar insert/update e delete de objetos relacionados", 1);
            arquivo.AppendLine("/// Missing insert/update and delete of related objects", 1);
            arquivo.AppendLine("/// </summary>", 1);
            arquivo.AppendLine("public class Contexto : IDisposable", 1);
            arquivo.AppendLine("{", 1);
            arquivo.AppendLine("private string ObterIdDoObjeto<T>()", 2);
            arquivo.AppendLine("{", 2);
            arquivo.AppendLine("PropertyInfo[] properties = typeof(T).GetProperties();", 3);
            arquivo.AppendLine("");
            arquivo.AppendLine("string key = $\"{typeof(T).Name}Id\";", 3);
            arquivo.AppendLine("");
            arquivo.AppendLine("foreach (PropertyInfo property in properties)", 3);
            arquivo.AppendLine("{", 3);
            arquivo.AppendLine("var attribute = Attribute.GetCustomAttribute(property, typeof(KeyAttribute))", 4);
            arquivo.AppendLine("as KeyAttribute;", 5);
            arquivo.AppendLine("");
            arquivo.AppendLine("if (attribute != null)", 4);
            arquivo.AppendLine("{", 4);
            arquivo.AppendLine("key = property.Name;", 5);
            arquivo.AppendLine("}", 4);
            arquivo.AppendLine("}", 3);
            arquivo.AppendLine("");
            arquivo.AppendLine("return key;", 3);
            arquivo.AppendLine("}", 2);
            arquivo.AppendLine("");
            arquivo.AppendLine("public static string GetPropValue(object src, string propName)", 2);
            arquivo.AppendLine("{", 2);
            arquivo.AppendLine("return src.GetType().GetProperty(propName).GetValue(src, null).ToString();", 3);
            arquivo.AppendLine("}", 2);
            arquivo.AppendLine("");
            arquivo.AppendLine("IDbConnection db;", 2);
            arquivo.AppendLine("");
            arquivo.AppendLine("public Contexto(IConfiguration config)", 2);
            arquivo.AppendLine("{", 2);
            arquivo.AppendLine("db = new SqlConnection(config.GetConnectionString(\"ModeloDDDConnection\"));", 3);
            arquivo.AppendLine("}", 2);
            arquivo.AppendLine("");
            arquivo.AppendLine("public List<T> Set<T>()", 2);
            arquivo.AppendLine("{", 2);
            arquivo.AppendLine("string tipo = typeof(T).Name;", 3);
            arquivo.AppendLine("return db.Query<T>($\"Select * From {tipo} (nolock)\").ToList();", 3);
            arquivo.AppendLine("}", 2);
            arquivo.AppendLine("");
            arquivo.AppendLine("public T Find<T>(int id)", 2);
            arquivo.AppendLine("{", 2);
            arquivo.AppendLine("string key = ObterIdDoObjeto<T>();", 3);
            arquivo.AppendLine("return db.Query<T>($\"Select * From {typeof(T).Name} (nolock) WHERE {key} = @Id\", new { id }).SingleOrDefault();", 3);
            arquivo.AppendLine("}", 2);
            arquivo.AppendLine("", 2);
            arquivo.AppendLine("public int Add<T>(T objeto)", 2);
            arquivo.AppendLine("{", 2);
            arquivo.AppendLine("var props = typeof(T).GetProperties();", 3);
            arquivo.AppendLine("");
            arquivo.AppendLine("string campos = \"\";", 3);
            arquivo.AppendLine("campos = props.Where(p => p.Name.ToUpper() != \"ID\" || p.Name.ToUpper() == $\"{typeof(T).Name}ID\")", 3);
            arquivo.AppendLine(".Select(p => p.Name).Aggregate((a, b) => $\"[{a}], [{b}]\");", 4);
            arquivo.AppendLine("");
            arquivo.AppendLine("string values = \"\";", 3);
            arquivo.AppendLine("values = props.Where(p => p.Name.ToUpper() != \"ID\" || p.Name.ToUpper() == $\"{typeof(T).Name}ID\")", 3);
            arquivo.AppendLine(".Select(p => p.Name).Select(p => typeof(T).GetProperty(p)?.GetValue(objeto, null).ToString()).Aggregate((a, b) => $\"'{a}', '{b}'\");", 4);
            arquivo.AppendLine("");
            arquivo.AppendLine("string sqlQuery = $\"INSERT INTO {typeof(T).Name} ({campos}) VALUES ({values})\";", 3);
            arquivo.AppendLine("int rowsAffected = db.Execute(sqlQuery, objeto);", 3);
            arquivo.AppendLine("return rowsAffected;", 3);
            arquivo.AppendLine("}", 2);
            arquivo.AppendLine("");
            arquivo.AppendLine("public int Update<T>(T objeto)", 2);
            arquivo.AppendLine("{", 2);
            arquivo.AppendLine("string key = ObterIdDoObjeto<T>();", 3);
            arquivo.AppendLine("");
            arquivo.AppendLine("var props = typeof(T).GetProperties();", 3);
            arquivo.AppendLine("string updatestr = \"\";", 3);
            arquivo.AppendLine("var nomes = props.Where(p => p.Name.ToUpper() != \"ID\" || p.Name.ToUpper() == $\"{typeof(T).Name}ID\")", 3);
            arquivo.AppendLine(".Select(p => p.Name);", 4);
            arquivo.AppendLine("updatestr = nomes.Aggregate((a, b) => $\"{a}=@{a}, {b}=@{b}\");", 3);
            arquivo.AppendLine("");
            arquivo.AppendLine("string sqlQuery = $\"UPDATE Author SET {updatestr} WHERE {key} = @Id\";", 3);
            arquivo.AppendLine("int rowsAffected = db.Execute(sqlQuery, objeto);", 3);
            arquivo.AppendLine("return rowsAffected;", 3);
            arquivo.AppendLine("}", 2);
            arquivo.AppendLine("");
            arquivo.AppendLine("public T Remove<T>(T obj)", 2);
            arquivo.AppendLine("{", 2);
            arquivo.AppendLine("string key = ObterIdDoObjeto<T>();", 3);
            arquivo.AppendLine("string id = GetPropValue(obj, key);", 3);
            arquivo.AppendLine("return db.Query<T>($\"Delete From {typeof(T).Name} WHERE {key} = @Id\", new { id }).SingleOrDefault();", 3);
            arquivo.AppendLine("}", 2);
            arquivo.AppendLine("");
            arquivo.AppendLine("public List<T> Ler<T>(string sPName)", 2);
            arquivo.AppendLine("{", 2);
            arquivo.AppendLine("return db.Query<T>(sPName,", 3);
            arquivo.AppendLine("commandType: CommandType.StoredProcedure).ToList();", 3);
            arquivo.AppendLine("}", 2);
            arquivo.AppendLine("");
            arquivo.AppendLine("public void Dispose()", 2);
            arquivo.AppendLine("{", 2);
            arquivo.AppendLine("db.Dispose();", 3);
            arquivo.AppendLine("}", 2);
            arquivo.AppendLine("}", 1);
            arquivo.AppendLine("}");

            FolderHelper.Create($"{_enderecoProjeto}\\Context");
            string endereco = $"Context\\Context.cs";
            try
            {
                arquivos.Add(endereco, arquivo);
            }
            catch (Exception)
            {

            }
        }
    }
}
