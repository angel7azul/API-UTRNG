using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.UTRG.Entities;
using API.UTRG.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.UTRG
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public static IConfiguration configuration { get; private set; }

        public Startup(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
               .AddMvcOptions(op => op.OutputFormatters.Add(
                   new XmlDataContractSerializerOutputFormatter()
                   ))
               ;

            var connectionString = Startup.configuration["connectionString:alumnoDB"];
            services.AddDbContext<AlumnoInfoDbContext>(o => o.UseSqlServer(connectionString));

            //Inyectar el repositorio creado CityInfoRepository inyectarlo en el controlador
            services.AddScoped<IAlumnoInfoRepository, AlumnoInfoRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, AlumnoInfoDbContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            context.EnsureSeedDatForContext();
            app.UseStatusCodePages();


            AutoMapper.Mapper.Initialize(cfg =>
            {
                //Mapear Entidad Alumno a Dto Alumno 
                cfg.CreateMap<Entities.Alumno, Models.AlumnoWithoutRedSocialDto>();
                cfg.CreateMap<Entities.Alumno, Models.AlumnoDto>();
                cfg.CreateMap<Entities.RedSocials, Models.RedSocialDto>();


                //Crear Punto de Interes
                cfg.CreateMap<Models.RedSocialForCreation, Entities.RedSocials>();


                //Actualizacion completa de un punto de interes
                cfg.CreateMap<Models.RedSocialForUpdate, Entities.RedSocials>();

                //Actualizacion Parcial
                cfg.CreateMap<Entities.RedSocials, Models.RedSocialForCreation>();
            });



            app.UseMvc();
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
        }
    }
}
