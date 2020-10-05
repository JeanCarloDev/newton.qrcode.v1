using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;
using Newton.ProjetoIntegradorV.QrCode.Business;
using Newton.ProjetoIntegradorV.QrCode.Data;
using Newton.ProjetoIntegradorV.QrCode.Domain.Contract;
using Swashbuckle.AspNetCore.Swagger;

namespace Newton.ProjetoIntegradorV.QrCode.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            #region Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "API Newton.ProjetoIntegradorV.QrCode",
                    Version = "v1",
                    Description = "API Newton.ProjetoIntegradorV.QrCode V1 - Integrantes: Jean Carlo Medeiros Soares / Aguida Nadja / Elmer Rodrigues / Mateus de Oliveira / Valdemir Severino Ferreira / Túlio Henrique Paz da Silva",
                    TermsOfService = "Terms of service"
                });
                c.DescribeAllEnumsAsStrings();

                string caminhoAplicacao = PlatformServices.Default.Application.ApplicationBasePath;
                string nomeAplicacao = PlatformServices.Default.Application.ApplicationName;
                string caminhoXmlDoc = Path.Combine(caminhoAplicacao, $"{nomeAplicacao}.xml");

                c.IncludeXmlComments(caminhoXmlDoc);
            });
            #endregion

            services.AddScoped<IQrCodeData, QrCodeData>();
            services.AddScoped<IQrCodeBusiness, QrCodeBusiness>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
