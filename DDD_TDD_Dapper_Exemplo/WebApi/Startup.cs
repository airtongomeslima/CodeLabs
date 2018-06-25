using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using API.Application;
using API.Domain.Infrastructure.Data;
using API.Domain.Infrastructure.Data.Interfaces;
using API.Domain.Repositories;
using API.Domain.Repositories.Interfaces;
using API.Integration.Wcf;
using API.Integration.Wcf.Interfaces;
using API.Services;
using API.Services.Facades;
using API.Services.Facades.Interfaces;
using API.Services.Interfaces;
using API.WebApi.Filters;
using Swashbuckle.AspNetCore.Swagger;

namespace API.WebApi
{
    public class Startup
    {
        ILoggerFactory _loggerFactory;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(
               config =>
               {
                   config.Filters.Add(typeof(GlobalExceptionFilter));
               });


            #region Filters

            services.AddScoped<InterceptCallActionFilter>();

            #endregion

            #region Logging

            if (this._loggerFactory == null)
                this._loggerFactory = (ILoggerFactory)new LoggerFactory();

            services.AddSingleton(this._loggerFactory);
            services.AddLogging();

            #endregion

            #region Injection

            services.AddScoped(typeof(TesteDbContext));
            services.AddScoped(typeof(ITesteUnitOfWork), typeof(TesteUnitOfWork));
            services.AddScoped(typeof(IArquiteturaExemploRepository), typeof(ArquiteturaExemploRepository));

            services.AddScoped(typeof(IClienteIntegration), typeof(ClienteIntegration));

            services.AddScoped(typeof(IArquiteturaExemploService), typeof(ArquiteturaExemploService));
            services.AddScoped(typeof(IArquiteturaExemploIntegracaoLegadoFacade), typeof(ArquiteturaExemploIntegracaoLegadoFacade));
            services.AddScoped(typeof(ArquiteturaExemploApplication));

            #endregion

            #region Swagger

            services.AddApiVersioning();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "API - V1", Version = "v1" });
            });

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
            ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
            loggerFactory.AddLog4Net();
            loggerFactory.AddConsole(Configuration.GetSection("Logging")); //log levels set in your configuration
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseMvc();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
            });
        }
    }
}
