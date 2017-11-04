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
        private static Dictionary<string, StringBuilder> arquivos = new Dictionary<string, StringBuilder>();

        protected string _nomeProjeto = "ModeloDDD";
        protected string _enderecoProjeto = "";
        protected string _connectionString = "";

        /// <summary>
        /// Criar projeto de Testes unitários
        /// </summary>
        /// <param name="nomeSolucao">Nome do projeto (ex. ModeloDDD, não precisa colocar o .Test nem o .csproj)</param>
        /// <param name="enderecoRaiz"></param>
        public C_CreateProjectAPI(string nomeSolucao, string enderecoRaiz, string connectionString)
        {
            _nomeProjeto = $"{nomeSolucao}.Servicos.API";
            _enderecoProjeto = $"{enderecoRaiz}\\{nomeSolucao}\\{_nomeProjeto}";
            _connectionString = connectionString;
            CreateProject();
            CreateAppSettingsJson();
            CreateAppSettingsJsonDevelopment();
            CreateProgramCS();
            CreateStartup();

            

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
            arquivo.AppendLine("</PropertyGroup>",1);
            arquivo.AppendLine("");
            arquivo.AppendLine("<PropertyGroup>",1);
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
            arquivo.AppendLine("<PackageReference Include=\"AutoMapper.Extensions.Microsoft.DependencyInjection\" Version=\"3.0.1\" />", 2);
            arquivo.AppendLine("<PackageReference Include=\"Microsoft.AspNetCore.All\" Version=\"2.0.0\" />", 2);
            arquivo.AppendLine("<PackageReference Include=\"Microsoft.AspNetCore.Mvc.Versioning\" Version=\"2.0.0\" />", 2);
            arquivo.AppendLine("<PackageReference Include=\"Microsoft.VisualStudio.Web.CodeGeneration.Design\" Version=\"2.0.0\" />", 2);
            arquivo.AppendLine($"<PackageReference Include=\"{_nomeProjeto}.DTO\" Version=\"1.0.0\" />", 2);
            arquivo.AppendLine("<PackageReference Include=\"Swashbuckle.AspNetCore\" Version=\"1.0.0\" />", 2);
            arquivo.AppendLine("</ItemGroup>", 1);
            arquivo.AppendLine("");
            arquivo.AppendLine("<ItemGroup>", 1);
            arquivo.AppendLine("<DotNetCliToolReference Include=\"Microsoft.VisualStudio.Web.CodeGeneration.Tools\" Version=\"2.0.0\" />", 2);
            arquivo.AppendLine("</ItemGroup>", 1);
            arquivo.AppendLine("");
            arquivo.AppendLine("<ItemGroup>", 1);
            arquivo.AppendLine($"<ProjectReference Include=\"..\\{_nomeProjeto}.Aplicacao\\{_nomeProjeto}.Aplicacao.csproj\\\" />", 2);
            arquivo.AppendLine($"<ProjectReference Include=\"..\\{_nomeProjeto}.Infra.Dados\\{_nomeProjeto}.Infra.Dados.csproj\\\" />", 2);
            arquivo.AppendLine("</ItemGroup>", 1);
            arquivo.AppendLine("");
            arquivo.AppendLine("</Project>");

            string endereco = $"{_nomeProjeto}.csproj";
            arquivos.Add(endereco, arquivo);
        }

        public void CreateAppSettingsJson()
        {
            StringBuilder arquivo = new StringBuilder();

            arquivo.AppendLine("{");
            arquivo.AppendLine("\"ConnectionStrings\": {", 1);
            arquivo.AppendLine($"\"ModeloTDDConnection\": \"{_connectionString}\"");
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
            arquivo.AppendLine($"namespace {_nomeProjeto}.API");
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

        public void CreateStartup()
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
            arquivo.AppendLine($"using {_nomeProjeto}.Aplicacao;");
            arquivo.AppendLine($"using {_nomeProjeto}.Aplicacao.Interfaces;");
            arquivo.AppendLine($"using {_nomeProjeto}.Dominio.Servicos;");
            arquivo.AppendLine($"using {_nomeProjeto}.Dominio.Interfaces.Repositorios;");
            arquivo.AppendLine($"using {_nomeProjeto}.Dominio.Interfaces.Servicos;");
            arquivo.AppendLine($"using {_nomeProjeto}.Infra.Dados.Repositorios;");
            arquivo.AppendLine("");
            arquivo.AppendLine($"namespace {_nomeProjeto}.API");
            arquivo.AppendLine("{");
            arquivo.AppendLine("    public class Startup",1);
            arquivo.AppendLine("    {",1);
            arquivo.AppendLine("        public IConfiguration Configuration { get; }", 2);
            arquivo.AppendLine("");
            arquivo.AppendLine("        public Startup(IHostingEnvironment env)", 2);
            arquivo.AppendLine("        {",2);
            arquivo.AppendLine("            var builder = new ConfigurationBuilder()",3);
            arquivo.AppendLine("                .SetBasePath(Directory.GetCurrentDirectory())",4);
            arquivo.AppendLine("                .AddJsonFile(\"appsettings.json\", optional: true, reloadOnChange: true)",4);
            arquivo.AppendLine("                .AddJsonFile($\"appsettings.{ env.EnvironmentName }.json\", optional: true);",4);
            arquivo.AppendLine("");
            arquivo.AppendLine("            builder.AddEnvironmentVariables();",3);
            arquivo.AppendLine("            Configuration = builder.Build();",3);
            arquivo.AppendLine("        }",2);
            arquivo.AppendLine("");
            arquivo.AppendLine("        public void ConfigureServices(IServiceCollection services)",2);
            arquivo.AppendLine("        {",2);
            arquivo.AppendLine("            services.AddMvc();",3);
            arquivo.AppendLine("            services.AddAutoMapper();",3);
            arquivo.AppendLine("            services.AddSingleton(Configuration);",3);
            arquivo.AppendLine("            services.AddApiVersioning();",3);
            arquivo.AppendLine("");
            arquivo.AppendLine("            #region",3);
            arquivo.AppendLine("                services.AddScoped(typeof(IClienteRepositorio), typeof(ClienteRepositorio));",4);
            arquivo.AppendLine("                services.AddScoped(typeof(IClienteServico), typeof(ClienteServico));",4);
            arquivo.AppendLine("                services.AddScoped(typeof(IClienteAppServico), typeof(ClienteAppServico));",4);
            arquivo.AppendLine("");
            arquivo.AppendLine("                services.AddScoped(typeof(IProdutoRepositorio), typeof(ProdutoRepositorio));",4);
            arquivo.AppendLine("                services.AddScoped(typeof(IClienteServico), typeof(ClienteServico));",4);
            arquivo.AppendLine("                services.AddScoped(typeof(IProdutoAppServico), typeof(ProdutoAppServico));",4);
            arquivo.AppendLine("            #endregion",3);
            arquivo.AppendLine("");
            arquivo.AppendLine("");
            arquivo.AppendLine("            services.AddSwaggerGen(c =>",3);
            arquivo.AppendLine("            {",3);
            arquivo.AppendLine($"                c.SwaggerDoc(\"v1\", new Info {{ Title = \"{_nomeProjeto} API - V1\", Version = \"v1\" }});",4);
            arquivo.AppendLine("            });",3);
            arquivo.AppendLine("        }",2);
            arquivo.AppendLine("        ");
            arquivo.AppendLine("        public void Configure(IApplicationBuilder app, IHostingEnvironment env)",2);
            arquivo.AppendLine("        {",2);
            arquivo.AppendLine("            if (env.IsDevelopment())",3);
            arquivo.AppendLine("            {",3);
            arquivo.AppendLine("                app.UseDeveloperExceptionPage();",4);
            arquivo.AppendLine("            }",3);
            arquivo.AppendLine("");
            arquivo.AppendLine("            app.UseMvc();",3);
            arquivo.AppendLine("");
            arquivo.AppendLine("            app.UseSwagger();",3);
            arquivo.AppendLine("");
            arquivo.AppendLine("            app.UseSwaggerUI(c =>",3);
            arquivo.AppendLine("            {",3);
            arquivo.AppendLine($"                c.SwaggerEndpoint(\"/swagger/v1/swagger.json\", \"{_nomeProjeto} API V1\");",4);
            arquivo.AppendLine("            });",3);
            arquivo.AppendLine("        }",2);
            arquivo.AppendLine("    }",1);
            arquivo.AppendLine("}");
            arquivo.AppendLine("");

            string endereco = $"Startup.cs";
            arquivos.Add(endereco, arquivo);
        }

        public void Create()
        {

        }

        #endregion

    }
}