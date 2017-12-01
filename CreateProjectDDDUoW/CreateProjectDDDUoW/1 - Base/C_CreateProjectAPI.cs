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
    public class C_CreateProjectAPI
    {
        private Dictionary<string, StringBuilder> arquivos = new Dictionary<string, StringBuilder>();

        protected string _nomeProjeto = "ModeloDDD";
        protected string _baseSolution = "ModeloDDD";
        protected string _enderecoProjeto = "";

        /// <summary>
        /// Criar projeto de Testes unitários
        /// </summary>
        /// <param name="nomeSolucao">Nome do projeto (ex. ModeloDDD, não precisa colocar o .Test nem o .csproj)</param>
        /// <param name="enderecoRaiz"></param>
        public C_CreateProjectAPI(string nomeSolucao, string enderecoRaiz, List<Contexto> contextos)
        {
            _nomeProjeto = $"{nomeSolucao}.Servicos.API";
            _enderecoProjeto = $"{enderecoRaiz}\\{nomeSolucao}\\{_nomeProjeto}";
            _baseSolution = nomeSolucao;
            CreateProject();
            CreateAppSettingsJson(contextos);
            CreateAppSettingsJsonDevelopment();
            CreateProgramCS();
            CreateStartup(contextos);

            CreateErrorView();
            CreateViewStart();
            CreateAutoMapperConfig();
            CreateDomainToViewModelMappingProfile();
            CreateViewModelToDomainMappingProfile();


            if (!Directory.Exists(_enderecoProjeto))
            {
                Directory.CreateDirectory(_enderecoProjeto);
            }


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

        #region Base Projeto

        public void CreateProject()
        {
            StringBuilder arquivo = new StringBuilder();
            arquivo.AppendLine("<Project Sdk=\"Microsoft.NET.Sdk.Web\">");
            arquivo.AppendLine("");
            arquivo.AppendLine("<PropertyGroup Label=\"Globals\">", 1);
            arquivo.AppendLine("<SccProjectName>SAK</SccProjectName>", 2);
            arquivo.AppendLine("<SccProvider>SAK</SccProvider>", 2);
            arquivo.AppendLine("<SccAuxPath>SAK</SccAuxPath>", 2);
            arquivo.AppendLine("<SccLocalPath>SAK</SccLocalPath>", 2);
            arquivo.AppendLine("</PropertyGroup>", 1);
            arquivo.AppendLine("");
            arquivo.AppendLine("<PropertyGroup>", 1);
            arquivo.AppendLine("<TargetFramework>netcoreapp2.0</TargetFramework>");
            arquivo.AppendLine("</PropertyGroup>", 1);
            arquivo.AppendLine("");
            arquivo.AppendLine("<ItemGroup>", 1);
            arquivo.AppendLine("<Folder Include=\"Models\\\" />", 2);
            arquivo.AppendLine("<Folder Include=\"wwwroot\\\" />", 2);
            arquivo.AppendLine("</ItemGroup>", 1);
            arquivo.AppendLine("");
            arquivo.AppendLine("<ItemGroup>", 1);
            arquivo.AppendLine("<PackageReference Include=\"AutoMapper\" Version=\"6.1.1\" />", 2);
            arquivo.AppendLine("<PackageReference Include=\"Microsoft.AspNet.WebApi.Client\" Version=\"5.2.3\" />", 2);
            arquivo.AppendLine("<PackageReference Include=\"Microsoft.AspNet.WebApi.WebHost\" Version=\"5.2.3\" />", 2);
            arquivo.AppendLine("<PackageReference Include=\"AutoMapper.Extensions.Microsoft.DependencyInjection\" Version=\"3.0.1\" />", 2);
            arquivo.AppendLine("<PackageReference Include=\"Microsoft.AspNetCore.All\" Version=\"2.0.0\" />", 2);
            arquivo.AppendLine("<PackageReference Include=\"Microsoft.AspNetCore.Mvc.Versioning\" Version=\"2.0.0\" />", 2);
            arquivo.AppendLine("<PackageReference Include=\"Microsoft.VisualStudio.Web.CodeGeneration.Design\" Version=\"2.0.0\" />", 2);
            arquivo.AppendLine("<PackageReference Include=\"Swashbuckle.AspNetCore\" Version=\"1.0.0\" />", 2);
            arquivo.AppendLine("</ItemGroup>", 1);
            arquivo.AppendLine("");
            arquivo.AppendLine("<ItemGroup>", 1);
            arquivo.AppendLine("<DotNetCliToolReference Include=\"Microsoft.VisualStudio.Web.CodeGeneration.Tools\" Version=\"2.0.0\" />", 2);
            arquivo.AppendLine("</ItemGroup>", 1);
            arquivo.AppendLine("");
            arquivo.AppendLine("<ItemGroup>", 1);
            arquivo.AppendLine($"<ProjectReference Include=\"..\\{_baseSolution}.Aplicacao\\{_baseSolution}.Aplicacao.csproj\" />", 2);
            arquivo.AppendLine($"<ProjectReference Include=\"..\\{_baseSolution}.Infra.Dados\\{_baseSolution}.Infra.Dados.csproj\" />", 2);
            arquivo.AppendLine("</ItemGroup>", 1);
            arquivo.AppendLine("");
            arquivo.AppendLine("</Project>");

            string endereco = $"{_nomeProjeto}.csproj";
            arquivos.Add(endereco, arquivo);
        }

        public void CreateAppSettingsJson(List<Contexto> contextos)
        {
            StringBuilder arquivo = new StringBuilder();

            arquivo.AppendLine("{");
            arquivo.AppendLine("\"ConnectionStrings\": {", 1);
            foreach (var ctx in contextos)
            {
                arquivo.AppendLine($"\"{ctx.Nome}Connection\": \"{ctx.StringConexao}\"");
            }
            arquivo.AppendLine("},", 1);
            arquivo.AppendLine("\"Logging\": {", 1);
            arquivo.AppendLine("\"IncludeScopes\": false,", 2);
            arquivo.AppendLine("\"Debug\": {", 2);
            arquivo.AppendLine("\"LogLevel\": {", 3);
            arquivo.AppendLine("\"Default\": \"Warning\"", 4);
            arquivo.AppendLine("}", 3);
            arquivo.AppendLine("},", 2);
            arquivo.AppendLine("\"Console\": {", 2);
            arquivo.AppendLine("\"LogLevel\": {", 3);
            arquivo.AppendLine("\"Default\": \"Warning\"", 4);
            arquivo.AppendLine("}", 3);
            arquivo.AppendLine("}", 2);
            arquivo.AppendLine("}", 1);
            arquivo.AppendLine("}");


            string endereco = $"appsettings.json";
            arquivos.Add(endereco, arquivo);

        }

        public void CreateAppSettingsJsonDevelopment()
        {
            StringBuilder arquivo = new StringBuilder();

            arquivo.AppendLine("{");
            arquivo.AppendLine("\"Logging\": {", 1);
            arquivo.AppendLine("\"IncludeScopes\": false,", 2);
            arquivo.AppendLine("\"LogLevel\": {", 2);
            arquivo.AppendLine("\"Default\": \"Debug\",", 3);
            arquivo.AppendLine("\"System\": \"Information\",", 3);
            arquivo.AppendLine("\"Microsoft\": \"Information\"", 3);
            arquivo.AppendLine("}", 2);
            arquivo.AppendLine("}", 1);
            arquivo.AppendLine("}");


            string endereco = $"appsettings.Development.json";
            arquivos.Add(endereco, arquivo);

        }

        public void CreateProgramCS()
        {
            StringBuilder arquivo = new StringBuilder();

            arquivo.AppendLine("using System;");
            arquivo.AppendLine("using System.Collections.Generic;");
            arquivo.AppendLine("using System.IO;");
            arquivo.AppendLine("using System.Linq;");
            arquivo.AppendLine("using System.Threading.Tasks;");
            arquivo.AppendLine("using Microsoft.AspNetCore;");
            arquivo.AppendLine("using Microsoft.AspNetCore.Hosting;");
            arquivo.AppendLine("using Microsoft.Extensions.Configuration;");
            arquivo.AppendLine("using Microsoft.Extensions.Logging;");
            arquivo.AppendLine("");
            arquivo.AppendLine($"namespace {_nomeProjeto}");
            arquivo.AppendLine("{");
            arquivo.AppendLine("public class Program", 1);
            arquivo.AppendLine("{", 1);
            arquivo.AppendLine("public static void Main(string[] args)", 2);
            arquivo.AppendLine("{", 2);
            arquivo.AppendLine("BuildWebHost(args).Run();", 3);
            arquivo.AppendLine("}", 2);
            arquivo.AppendLine("");
            arquivo.AppendLine("public static IWebHost BuildWebHost(string[] args) =>", 2);
            arquivo.AppendLine("WebHost.CreateDefaultBuilder(args)", 3);
            arquivo.AppendLine(".UseStartup<Startup>()", 3);
            arquivo.AppendLine(".Build();", 3);
            arquivo.AppendLine("}", 2);
            arquivo.AppendLine("}");

            string endereco = $"Program.cs";
            arquivos.Add(endereco, arquivo);
        }

        public void CreateStartup(List<Contexto> contextos)
        {
            StringBuilder arquivo = new StringBuilder();

            arquivo.AppendLine("using Microsoft.AspNetCore.Builder;");
            arquivo.AppendLine("using Microsoft.AspNetCore.Hosting;");
            arquivo.AppendLine("using Microsoft.Extensions.Configuration;");
            arquivo.AppendLine("using Microsoft.Extensions.DependencyInjection;");
            arquivo.AppendLine("using AutoMapper;");
            arquivo.AppendLine("using System.IO;");
            arquivo.AppendLine("");
            arquivo.AppendLine("using Swashbuckle.AspNetCore.Swagger;");
            arquivo.AppendLine($"using {_baseSolution}.Aplicacao.Interfaces;");
            arquivo.AppendLine($"using {_baseSolution}.Dominio.Servicos;");
            arquivo.AppendLine($"using {_baseSolution}.Dominio.Interfaces.Repositorios;");
            arquivo.AppendLine($"using {_baseSolution}.Dominio.Interfaces.Servicos;");
            arquivo.AppendLine($"using {_baseSolution}.Infra.Dados.Repositorio;");
            arquivo.AppendLine($"using {_baseSolution}.Aplicacao.Aplicacao;");


            foreach (var ctx in contextos)
            {
                arquivo.AppendLine($"using {_baseSolution}.Aplicacao.Interfaces.{ctx.Nome};");
                arquivo.AppendLine($"using {_baseSolution}.Dominio.Servicos.{ctx.Nome};");
                arquivo.AppendLine($"using {_baseSolution}.Dominio.Interfaces.Repositorios.{ctx.Nome};");
                arquivo.AppendLine($"using {_baseSolution}.Dominio.Interfaces.Servicos.{ctx.Nome};");
                arquivo.AppendLine($"using {_baseSolution}.Infra.Dados.Repositorio.{ctx.Nome};");
                arquivo.AppendLine($"using {_baseSolution}.Aplicacao.Aplicacao.{ctx.Nome};");
            }

            arquivo.AppendLine("");
            arquivo.AppendLine($"namespace {_nomeProjeto}");
            arquivo.AppendLine("{");
            arquivo.AppendLine("public class Startup", 1);
            arquivo.AppendLine("{", 1);
            arquivo.AppendLine("public IConfiguration Configuration { get; }", 2);
            arquivo.AppendLine("");
            arquivo.AppendLine("public Startup(IHostingEnvironment env)", 2);
            arquivo.AppendLine("{", 2);
            arquivo.AppendLine("var builder = new ConfigurationBuilder()", 3);
            arquivo.AppendLine(".SetBasePath(Directory.GetCurrentDirectory())", 4);
            arquivo.AppendLine(".AddJsonFile(\"appsettings.json\", optional: true, reloadOnChange: true)", 4);
            arquivo.AppendLine(".AddJsonFile($\"appsettings.{ env.EnvironmentName }.json\", optional: true);", 4);
            arquivo.AppendLine("");
            arquivo.AppendLine("builder.AddEnvironmentVariables();", 3);
            arquivo.AppendLine("Configuration = builder.Build();", 3);
            arquivo.AppendLine("}", 2);
            arquivo.AppendLine("");
            arquivo.AppendLine("public void ConfigureServices(IServiceCollection services)", 2);
            arquivo.AppendLine("{", 2);
            arquivo.AppendLine("services.AddMvc();", 3);
            arquivo.AppendLine("services.AddAutoMapper();", 3);
            arquivo.AppendLine("services.AddSingleton(Configuration);", 3);
            arquivo.AppendLine("services.AddApiVersioning();", 3);
            arquivo.AppendLine("");
            arquivo.AppendLine("#region Declaracoes", 3);

            foreach (var ctx in contextos)
            {
                foreach (var e in ctx.TabelasSelecionadas)
                {

                    var r = e;
                    if (e.Contains("."))
                    {
                        r = e.Split('.')[1];
                    }

                    arquivo.AppendLine($"services.AddScoped(typeof(I{r}Repositorio), typeof({r}Repositorio));", 4);
                    arquivo.AppendLine($"services.AddScoped(typeof(I{r}Servico), typeof({r}Servico));", 4);
                    arquivo.AppendLine($"services.AddScoped(typeof(I{r}AppServico), typeof({r}AppServico));", 4);
                }
            }


            arquivo.AppendLine("#endregion", 3);
            arquivo.AppendLine("");
            arquivo.AppendLine("");
            arquivo.AppendLine("services.AddSwaggerGen(c =>", 3);
            arquivo.AppendLine("{", 3);
            arquivo.AppendLine($"c.SwaggerDoc(\"v1\", new Info {{ Title = \"{_baseSolution} API - V1\", Version = \"v1\" }});", 4);
            arquivo.AppendLine("});", 3);
            arquivo.AppendLine("}", 2);
            arquivo.AppendLine("");
            arquivo.AppendLine("public void Configure(IApplicationBuilder app, IHostingEnvironment env)", 2);
            arquivo.AppendLine("{", 2);
            arquivo.AppendLine("if (env.IsDevelopment())", 3);
            arquivo.AppendLine("{", 3);
            arquivo.AppendLine("app.UseDeveloperExceptionPage();", 4);
            arquivo.AppendLine("}", 3);
            arquivo.AppendLine("");
            arquivo.AppendLine("app.UseMvc();", 3);
            arquivo.AppendLine("");
            arquivo.AppendLine("app.UseSwagger();", 3);
            arquivo.AppendLine("");
            arquivo.AppendLine("app.UseSwaggerUI(c =>", 3);
            arquivo.AppendLine("{", 3);
            arquivo.AppendLine($"c.SwaggerEndpoint(\"/swagger/v1/swagger.json\", \"{_baseSolution} API V1\");", 4);
            arquivo.AppendLine("});", 3);
            arquivo.AppendLine("}", 2);
            arquivo.AppendLine("}", 1);
            arquivo.AppendLine("}");
            arquivo.AppendLine("");

            string endereco = $"Startup.cs";
            arquivos.Add(endereco, arquivo);
        }

        public void CreateErrorView()
        {
            StringBuilder arquivo = new StringBuilder();

            arquivo.AppendLine("@{");
            arquivo.AppendLine("ViewData[\"Title\"] = \"Error\";", 1);
            arquivo.AppendLine("}");
            arquivo.AppendLine("");
            arquivo.AppendLine("<h1 class=\"text-danger\">Error.</h1>");
            arquivo.AppendLine("<h2 class=\"text-danger\">An error occurred while processing your request.</h2>");
            arquivo.AppendLine("");
            arquivo.AppendLine("<h3>Development Mode</h3>");
            arquivo.AppendLine("<p>");
            arquivo.AppendLine("Swapping to <strong>Development</strong> environment will display more detailed information about the error that occurred.", 1);
            arquivo.AppendLine("</p>");
            arquivo.AppendLine("<p>");
            arquivo.AppendLine("<strong>Development environment should not be enabled in deployed applications</strong>, as it can result in sensitive information from exceptions being displayed to end users. For local debugging, development environment can be enabled by setting the <strong>ASPNETCORE_ENVIRONMENT</strong> environment variable to <strong>Development</strong>, and restarting the application.", 1);
            arquivo.AppendLine("</p>");

            FolderHelper.Create($"{_enderecoProjeto}\\Views\\Shared");
            string endereco = $"Views\\Shared\\Error.cshtml";
            arquivos.Add(endereco, arquivo);
        }

        public void CreateViewStart()
        {
            StringBuilder arquivo = new StringBuilder();

            arquivo.AppendLine("@{");
            arquivo.AppendLine("Layout = \"_Layout\";", 1);
            arquivo.AppendLine("}");

            FolderHelper.Create($"{_enderecoProjeto}\\Views");
            string endereco = $"Views\\_ViewStart.cshtml";
            arquivos.Add(endereco, arquivo);
        }

        #endregion

        public void CreateAutoMapperConfig()
        {
            StringBuilder arquivo = new StringBuilder();

            arquivo.AppendLine("using AutoMapper;");
            arquivo.AppendLine("");
            arquivo.AppendLine($"namespace {_nomeProjeto}.AutoMapper");
            arquivo.AppendLine("{");
            arquivo.AppendLine("public class AutoMapperConfig", 1);
            arquivo.AppendLine("{", 1);
            arquivo.AppendLine("public static void RegisterMappings()", 2);
            arquivo.AppendLine("{", 2);
            arquivo.AppendLine("Mapper.Initialize(x =>", 3);
            arquivo.AppendLine("{", 3);
            arquivo.AppendLine("x.AddProfile<DomainToViewModelMappingProfile>();", 4);
            arquivo.AppendLine("x.AddProfile<ViewModelToDomainMappingProfile>();", 4);
            arquivo.AppendLine("});", 3);
            arquivo.AppendLine("}", 2);
            arquivo.AppendLine("}", 1);
            arquivo.AppendLine("}");

            FolderHelper.Create($"{_enderecoProjeto}\\AutoMapper");
            string endereco = $"AutoMapper\\AutoMapper.cs";
            arquivos.Add(endereco, arquivo);
        }

        public void CreateHttpResultHelper()
        {
            StringBuilder arquivo = new StringBuilder();

            arquivo.AppendLine("using System;");
            arquivo.AppendLine("using System.Collections.Generic;");
            arquivo.AppendLine("using System.ComponentModel.DataAnnotations;");
            arquivo.AppendLine("using System.Linq;");
            arquivo.AppendLine("using System.Net;");
            arquivo.AppendLine("using System.Net.Http;");
            arquivo.AppendLine("using System.Web.Http;");
            arquivo.AppendLine("");
            arquivo.AppendLine("namespace Solucao.Servicos.API.Helpers");
            arquivo.AppendLine("{");
            arquivo.AppendLine("/// <summary>", 1);
            arquivo.AppendLine("/// Code by Rafael Nicoleti", 1);
            arquivo.AppendLine("/// At the controller add:", 1);
            arquivo.AppendLine("/// private readonly HttpResult<Your_DTO_Object> _result;", 1);
            arquivo.AppendLine("/// At the controller contructor:", 1);
            arquivo.AppendLine("/// _result = new HttpResult<Your_DTO_Object>();", 1);
            arquivo.AppendLine("/// And at the method response:", 1);
            arquivo.AppendLine("/// _result.Success(Your_DTO_Object);", 1);
            arquivo.AppendLine("/// </summary>", 1);
            arquivo.AppendLine("/// <typeparam name=\"T\">Type of ObjectResponse</typeparam>", 1);
            arquivo.AppendLine("public class HttpResult<T> : IEquatable<HttpResult<T>>", 1);
            arquivo.AppendLine("{", 1);
            arquivo.AppendLine("public override int GetHashCode()", 2);
            arquivo.AppendLine("{", 2);
            arquivo.AppendLine("unchecked", 3);
            arquivo.AppendLine("{", 3);
            arquivo.AppendLine("var hashCode = (int)Answer;", 4);
            arquivo.AppendLine("hashCode = (hashCode * 397) ^ (Data != null ? Data.GetHashCode() : 0);", 4);
            arquivo.AppendLine("hashCode = (hashCode * 397) ^ EqualityComparer<T>.Default.GetHashCode(Model);", 4);
            arquivo.AppendLine("hashCode = (hashCode * 397) ^ (Errors != null ? Errors.GetHashCode() : 0);", 4);
            arquivo.AppendLine("return hashCode;", 4);
            arquivo.AppendLine("}", 3);
            arquivo.AppendLine("}", 2);
            arquivo.AppendLine("");
            arquivo.AppendLine("public HttpStatusCode Answer { get; set; }", 2);
            arquivo.AppendLine("public IEnumerable<T> Data { get; set; }", 2);
            arquivo.AppendLine("public T Model { get; set; }", 2);
            arquivo.AppendLine("public int TotalItems { get; set; }", 2);
            arquivo.AppendLine("public IEnumerable<string> Errors { get; set; }", 2);
            arquivo.AppendLine("");
            arquivo.AppendLine("public HttpResponseMessage Success(T model)", 2);
            arquivo.AppendLine("{", 2);
            arquivo.AppendLine("Answer = HttpStatusCode.OK;", 3);
            arquivo.AppendLine("Model = model;", 3);
            arquivo.AppendLine("var responseMessage = new HttpResponseMessage(HttpStatusCode.OK)", 3);
            arquivo.AppendLine("{", 3);
            arquivo.AppendLine("Content = new ObjectContent<HttpResult<T>>(this, GlobalConfiguration.Configuration.Formatters.JsonFormatter)", 4);
            arquivo.AppendLine("};", 3);
            arquivo.AppendLine("return responseMessage;", 3);
            arquivo.AppendLine("}", 2);
            arquivo.AppendLine("");
            arquivo.AppendLine("public HttpResponseMessage Success(object data)", 2);
            arquivo.AppendLine("{", 2);
            arquivo.AppendLine("throw new NotImplementedException();", 3);
            arquivo.AppendLine("}", 2);
            arquivo.AppendLine("");
            arquivo.AppendLine("public HttpResponseMessage Success(IEnumerable<T> data)", 2);
            arquivo.AppendLine("{", 2);
            arquivo.AppendLine("Answer = HttpStatusCode.OK;", 3);
            arquivo.AppendLine("");
            arquivo.AppendLine("if (data != null)", 3);
            arquivo.AppendLine("Data = data;", 4);
            arquivo.AppendLine("else", 3);
            arquivo.AppendLine("Data = new List<T>();", 4);
            arquivo.AppendLine("");
            arquivo.AppendLine("TotalItems = data.Count();", 3);
            arquivo.AppendLine("");
            arquivo.AppendLine("var responseMessage = new HttpResponseMessage(HttpStatusCode.OK)", 3);
            arquivo.AppendLine("{", 3);
            arquivo.AppendLine("Content = new ObjectContent<HttpResult<T>>(this, GlobalConfiguration.Configuration.Formatters.JsonFormatter)", 4);
            arquivo.AppendLine("};", 3);
            arquivo.AppendLine("");
            arquivo.AppendLine("return responseMessage;", 3);
            arquivo.AppendLine("}", 2);
            arquivo.AppendLine("");
            arquivo.AppendLine("public HttpResponseMessage Success()", 2);
            arquivo.AppendLine("{", 2);
            arquivo.AppendLine("Answer = HttpStatusCode.OK;", 3);
            arquivo.AppendLine("var responseMessage = new HttpResponseMessage(HttpStatusCode.OK)", 3);
            arquivo.AppendLine("{", 3);
            arquivo.AppendLine("Content = new ObjectContent<HttpResult<T>>(this, GlobalConfiguration.Configuration.Formatters.JsonFormatter)", 4);
            arquivo.AppendLine("};", 3);
            arquivo.AppendLine("return responseMessage;", 3);
            arquivo.AppendLine("}", 2);
            arquivo.AppendLine("");
            arquivo.AppendLine("public HttpResponseMessage Error(IList<ValidationResult> errors)", 2);
            arquivo.AppendLine("{", 2);
            arquivo.AppendLine("Answer = HttpStatusCode.InternalServerError;", 3);
            arquivo.AppendLine("Errors = errors.Select(_ => _.ErrorMessage);", 3);
            arquivo.AppendLine("");
            arquivo.AppendLine("var responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError)", 3);
            arquivo.AppendLine("{", 3);
            arquivo.AppendLine("Content = new ObjectContent<HttpResult<T>>(this, GlobalConfiguration.Configuration.Formatters.JsonFormatter)", 4);
            arquivo.AppendLine("};", 3);
            arquivo.AppendLine("return responseMessage;", 3);
            arquivo.AppendLine("}", 2);
            arquivo.AppendLine("");
            arquivo.AppendLine("public HttpResponseMessage Error(string error)", 2);
            arquivo.AppendLine("{", 2);
            arquivo.AppendLine("Answer = HttpStatusCode.InternalServerError;", 3);
            arquivo.AppendLine("Errors = new List<string> { error };", 3);
            arquivo.AppendLine("var responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError)", 3);
            arquivo.AppendLine("{", 3);
            arquivo.AppendLine("Content = new ObjectContent<HttpResult<T>>(this, GlobalConfiguration.Configuration.Formatters.JsonFormatter)", 4);
            arquivo.AppendLine("};", 3);
            arquivo.AppendLine("return responseMessage;", 3);
            arquivo.AppendLine("}", 2);
            arquivo.AppendLine("");
            arquivo.AppendLine("private HttpResponseMessage BadRequest(string error)", 2);
            arquivo.AppendLine("{", 2);
            arquivo.AppendLine("Answer = HttpStatusCode.BadRequest;", 3);
            arquivo.AppendLine("Errors = new List<string> { error };", 3);
            arquivo.AppendLine("var responseMessage = new HttpResponseMessage(HttpStatusCode.BadRequest)", 3);
            arquivo.AppendLine("{", 3);
            arquivo.AppendLine("Content = new ObjectContent<HttpResult<T>>(this, GlobalConfiguration.Configuration.Formatters.JsonFormatter)", 4);
            arquivo.AppendLine("};", 3);
            arquivo.AppendLine("return responseMessage;", 3);
            arquivo.AppendLine("}", 2);
            arquivo.AppendLine("");
            arquivo.AppendLine("private HttpResponseMessage NotFound(string error)", 2);
            arquivo.AppendLine("{", 2);
            arquivo.AppendLine("Answer = HttpStatusCode.NotFound;", 3);
            arquivo.AppendLine("Errors = new List<string> { error };", 3);
            arquivo.AppendLine("var responseMessage = new HttpResponseMessage(HttpStatusCode.NotFound)", 3);
            arquivo.AppendLine("{", 3);
            arquivo.AppendLine("Content = new ObjectContent<HttpResult<T>>(this, GlobalConfiguration.Configuration.Formatters.JsonFormatter)", 4);
            arquivo.AppendLine("};", 3);
            arquivo.AppendLine("return responseMessage;", 3);
            arquivo.AppendLine("}", 2);
            arquivo.AppendLine("");
            arquivo.AppendLine("private HttpResponseMessage AlreadyExists(string error)", 2);
            arquivo.AppendLine("{", 2);
            arquivo.AppendLine("Answer = HttpStatusCode.Conflict;", 3);
            arquivo.AppendLine("Errors = new List<string> { error };", 3);
            arquivo.AppendLine("var responseMessage = new HttpResponseMessage(HttpStatusCode.Conflict)", 3);
            arquivo.AppendLine("{", 3);
            arquivo.AppendLine("Content = new ObjectContent<HttpResult<T>>(this, GlobalConfiguration.Configuration.Formatters.JsonFormatter)", 4);
            arquivo.AppendLine("};", 3);
            arquivo.AppendLine("return responseMessage;", 3);
            arquivo.AppendLine("}", 2);
            arquivo.AppendLine("");
            arquivo.AppendLine("private HttpResponseMessage NotAuthorized(string error)", 2);
            arquivo.AppendLine("{", 2);
            arquivo.AppendLine("Answer = HttpStatusCode.Unauthorized;", 3);
            arquivo.AppendLine("Errors = new List<string> { error };", 3);
            arquivo.AppendLine("var responseMessage = new HttpResponseMessage(HttpStatusCode.Unauthorized)", 3);
            arquivo.AppendLine("{", 3);
            arquivo.AppendLine("Content = new ObjectContent<HttpResult<T>>(this, GlobalConfiguration.Configuration.Formatters.JsonFormatter)", 4);
            arquivo.AppendLine("};", 3);
            arquivo.AppendLine("return responseMessage;", 3);
            arquivo.AppendLine("}", 2);
            arquivo.AppendLine("");
            arquivo.AppendLine("public HttpResponseMessage ReturnCustomException(Exception ex)", 2);
            arquivo.AppendLine("{", 2);
            arquivo.AppendLine("return Error($\"{ex.Message}\");", 3);
            arquivo.AppendLine("}", 2);
            arquivo.AppendLine("");
            arquivo.AppendLine("public bool Equals(HttpResult<T> other)", 2);
            arquivo.AppendLine("{", 2);
            arquivo.AppendLine("if (ReferenceEquals(null, other)) return false;", 3);
            arquivo.AppendLine("if (ReferenceEquals(this, other)) return true;", 3);
            arquivo.AppendLine("return Answer == other.Answer && Equals(Data, other.Data) && EqualityComparer<T>.Default.Equals(Model, other.Model) && Equals(Errors, other.Errors);", 3);
            arquivo.AppendLine("}", 2);
            arquivo.AppendLine("");
            arquivo.AppendLine("public override bool Equals(Object obj)", 2);
            arquivo.AppendLine("{", 2);
            arquivo.AppendLine("if (ReferenceEquals(null, obj)) return false;", 3);
            arquivo.AppendLine("if (ReferenceEquals(this, obj)) return true;", 3);
            arquivo.AppendLine("if (obj.GetType() != GetType()) return false;", 3);
            arquivo.AppendLine("return Equals((HttpResult<T>)obj);", 3);
            arquivo.AppendLine("}", 2);
            arquivo.AppendLine("}", 1);
            arquivo.AppendLine("}");


            FolderHelper.Create($"{_enderecoProjeto}\\Helppers");
            string endereco = $"Helppers\\HttpResult.cs";
            arquivos.Add(endereco, arquivo);
        }

        public void CreateDomainToViewModelMappingProfile()
        {
            StringBuilder arquivo = new StringBuilder();

            arquivo.AppendLine("using AutoMapper;");
            arquivo.AppendLine($"using {_baseSolution}.Dominio.Entitades;");
            arquivo.AppendLine($"//using {_baseSolution}.DTO;");
            arquivo.AppendLine("");
            arquivo.AppendLine($"namespace {_nomeProjeto}.AutoMapper");
            arquivo.AppendLine("{");
            arquivo.AppendLine("public class DomainToViewModelMappingProfile : Profile", 1);
            arquivo.AppendLine("{", 1);
            arquivo.AppendLine("public override string ProfileName", 2);
            arquivo.AppendLine("{", 2);
            arquivo.AppendLine("get { return \"DomainToViewMappings\"; }", 3);
            arquivo.AppendLine("}", 2);
            arquivo.AppendLine("");
            arquivo.AppendLine("public DomainToViewModelMappingProfile()", 2);
            arquivo.AppendLine("{", 2);
            arquivo.AppendLine("////CreateMap<Cliente, ClienteDTO>();", 3);
            arquivo.AppendLine("}", 2);
            arquivo.AppendLine("}", 1);
            arquivo.AppendLine("}");


            FolderHelper.Create($"{_enderecoProjeto}\\AutoMapper");
            string endereco = $"AutoMapper\\DomainToViewModelMappingProfile.cs";
            arquivos.Add(endereco, arquivo);
        }

        public void CreateViewModelToDomainMappingProfile()
        {
            StringBuilder arquivo = new StringBuilder();

            arquivo.AppendLine("using AutoMapper;");
            arquivo.AppendLine($"using {_baseSolution}.Dominio.Entitades;");
            arquivo.AppendLine($"//using {_baseSolution}.DTO;");
            arquivo.AppendLine("");
            arquivo.AppendLine($"namespace {_nomeProjeto}.AutoMapper");
            arquivo.AppendLine("{");
            arquivo.AppendLine("public class ViewModelToDomainMappingProfile : Profile", 1);
            arquivo.AppendLine("{", 1);
            arquivo.AppendLine("public override string ProfileName", 2);
            arquivo.AppendLine("{", 2);
            arquivo.AppendLine("get { return \"ViewModelToDomainMappings\"; }", 3);
            arquivo.AppendLine("}", 2);
            arquivo.AppendLine("");
            arquivo.AppendLine("public ViewModelToDomainMappingProfile()", 2);
            arquivo.AppendLine("{", 2);
            arquivo.AppendLine("////CreateMap<Cliente, ClienteDTO>();", 3);
            arquivo.AppendLine("}", 2);
            arquivo.AppendLine("}", 1);
            arquivo.AppendLine("}");


            FolderHelper.Create($"{_enderecoProjeto}\\AutoMapper");
            string endereco = $"AutoMapper\\ViewModelToDomainMappingProfile.cs";
            arquivos.Add(endereco, arquivo);
        }
    }
}