using AutoMapper;
using Build_IT_DataAccess;
using Build_IT_DataAccess.DeadLoads;
using Build_IT_DataAccess.DeadLoads.Interfaces;
using Build_IT_DataAccess.DeadLoads.Repositories;
using Build_IT_DataAccess.DeadLoads.Repositories.Interfaces;
using Build_IT_DataAccess.Interfaces;
using Build_IT_DataAccess.ScriptInterpreter;
using Build_IT_DataAccess.ScriptInterpreter.Interfaces;
using Build_IT_DataAccess.ScriptInterpreter.Models;
using Build_IT_DataAccess.ScriptInterpreter.Repositiories;
using Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace Build_IT_Web
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
            services.Configure<FigureSettings>(Configuration.GetSection("PhotoSettings"));            
            string dataAccessAssemblyName = Configuration.GetSection("DataAccess").GetValue<string>("Project");

            services.AddScoped<IScriptRepository, ScriptRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<IParameterRepository, ParameterRepository>();

            services.AddScoped<IScriptInterpreterUnitOfWork, ScriptInterpreterUnitOfWork>();
            services.AddDbContext<ScriptInterpreterDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("Scripts"), 
                b => b.MigrationsAssembly(dataAccessAssemblyName)));
            
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ISubcategoryRepository, SubcategoryRepository>();
            services.AddScoped<IMaterialRepository, MaterialRepository>();

            services.AddScoped<IDeadLoadsUnitOfWork, DeadLoadsUnitOfWork>();
            services.AddDbContext<DeadLoadsDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("DeadLoads"),
                b => b.MigrationsAssembly(dataAccessAssemblyName)));

            services.AddAutoMapper();
            
            services.AddMvc()
                .AddJsonOptions(opt => opt.SerializerSettings.ReferenceLoopHandling = 
                Newtonsoft.Json.ReferenceLoopHandling.Ignore) //ignores self reference object 
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1); //validate api rules
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "wwwroot/clientapp/dist";
                //configuration.RootPath = "wwwroot/clientapp/out-tsc";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseMvc();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });

        }
    }
}
