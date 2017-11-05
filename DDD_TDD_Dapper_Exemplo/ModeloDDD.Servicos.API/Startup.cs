using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using System.IO;
using Swashbuckle.AspNetCore.Swagger;
using ModeloDDD.Aplicacao.Interfaces;
using ModeloDDD.Aplicacao;
using ModeloDDD.Dominio.Servicos;
using ModeloDDD.Dominio.Interfaces.Repositorios;
using ModeloDDD.Dominio.Interfaces.Servicos;
using ModeloDDD.Infra.Dados.Respositorio;

namespace ModeloDDD.Servicos.API
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

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddAutoMapper();
            services.AddSingleton(Configuration);

            #region Injection
                        
            services.AddScoped(typeof(IClienteRepositorio), typeof(ClienteRepositorio));
            services.AddScoped(typeof(IClienteServico), typeof(ClienteServico));
            services.AddScoped(typeof(IClienteAppServico), typeof(ClienteAppServico));
            
            #endregion


            services.AddApiVersioning();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "API - V1", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
            });
        }
    }
}
