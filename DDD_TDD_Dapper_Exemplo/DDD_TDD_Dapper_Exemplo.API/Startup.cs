using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using DDD_TDD_Dapper_Exemplo.Aplicacao.Interfaces;
using System.IO;

using Swashbuckle.AspNetCore.Swagger;
using DDD_TDD_Dapper_Exemplo.Aplicacao;
using DDD_TDD_Dapper_Exemplo.Dominio.Servicos;
using DDD_TDD_Dapper_Exemplo.Dominio.Interfaces.Servicos;
using DDD_TDD_Dapper_Exemplo.Infra.Dados.Repositorios;
using DDD_TDD_Dapper_Exemplo.Dominio.Interfaces.Repositorios;

namespace DDD_TDD_Dapper_Exemplo.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddAutoMapper();
            services.AddSingleton(Configuration);
            services.AddApiVersioning();

            #region
                services.AddScoped(typeof(IClienteRepositorio), typeof(ClienteRepositorio));
                services.AddScoped(typeof(IClienteServico), typeof(ClienteServico));
                services.AddScoped(typeof(IClienteAppServico), typeof(ClienteAppServico));

                services.AddScoped(typeof(IProdutoRepositorio), typeof(ProdutoRepositorio));
                services.AddScoped(typeof(IClienteServico), typeof(ClienteServico));
                services.AddScoped(typeof(IProdutoAppServico), typeof(ProdutoAppServico));
            #endregion


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API - V1", Version = "v1" });
            });
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}
