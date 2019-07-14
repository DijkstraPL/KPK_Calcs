using AutoMapper;
using Build_IT_Application.DeadLoads.Categories.Queries.GetAllCategories;
using Build_IT_Application.DeadLoads.Materials.Queries.GetAllMaterials;
using Build_IT_Application.Infrastructures;
using Build_IT_Application.Interfaces;
using Build_IT_Application.Mapping;
using Build_IT_CommonTools;
using Build_IT_CommonTools.Interfaces;
using Build_IT_Data.Entities.Scripts;
using Build_IT_DataAccess;
using Build_IT_DataAccess.DeadLoads;
using Build_IT_DataAccess.DeadLoads.Interfaces;
using Build_IT_DataAccess.DeadLoads.Repositories;
using Build_IT_DataAccess.DeadLoads.Repositories.Interfaces;
using Build_IT_DataAccess.ScriptInterpreter;
using Build_IT_DataAccess.ScriptInterpreter.Interfaces;
using Build_IT_DataAccess.ScriptInterpreter.Repositiories;
using Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces;
using Build_IT_Web.Mapping;
using Build_IT_Web.Services;
using Build_IT_Web.Services.Interfaces;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System.Reflection;
using ScriptMappingProfile = Build_IT_Application.Mapping.ScriptMappingProfile;

namespace Build_IT_Web
{
    public class Startup
    {
        #region Properties

        public IConfiguration Configuration { get; }

        #endregion // Properties

        #region Constructors

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        #endregion // Constructors

        #region Public_Methods

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<FigureSettings>(Configuration.GetSection("PhotoSettings"));
            string dataAccessAssemblyName = Configuration.GetSection("DataAccess").GetValue<string>("Project");

            services.AddScoped<IScriptRepository, ScriptRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<IParameterRepository, ParameterRepository>();

            SetTranslationsServices(services);

            services.AddScoped<IScriptInterpreterUnitOfWork, ScriptInterpreterUnitOfWork>();
#if RELEASE
            services.AddDbContext<ScriptInterpreterDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("Scripts"), 
                b => b.MigrationsAssembly(dataAccessAssemblyName)));
#endif
#if DEBUG
            services.AddDbContext<ScriptInterpreterDbContext>(
                options => options.UseSqlServer(Configuration.GetSection("TestConnectionStrings").GetValue<string>("Scripts"),
                b => b.MigrationsAssembly(dataAccessAssemblyName)));
#endif

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ISubcategoryRepository, SubcategoryRepository>();
            services.AddScoped<IMaterialRepository, MaterialRepository>();

            services.AddScoped<IDeadLoadsUnitOfWork, DeadLoadsUnitOfWork>();
#if RELEASE
            services.AddDbContext<DeadLoadsDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("DeadLoads"),
                b => b.MigrationsAssembly(dataAccessAssemblyName)));
#endif
#if DEBUG
            services.AddDbContext<DeadLoadsDbContext>(
                options => options.UseSqlServer(Configuration.GetSection("TestConnectionStrings").GetValue<string>("DeadLoads"),
                b => b.MigrationsAssembly(dataAccessAssemblyName)));
#endif

            services.AddScoped<IDateTime, MyDateTime>();
            services.AddTransient<INotificationService, NotificationService>();

            services.AddMediatR(typeof(GetAllCategoriesQuery.Handler).GetTypeInfo().Assembly);
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            SetUpAutoMapper(services);

            services.AddMvc()
                .AddJsonOptions(opt => opt.SerializerSettings.ReferenceLoopHandling =
                Newtonsoft.Json.ReferenceLoopHandling.Ignore) //ignores self reference object 
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1) //validate api rules
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<GetAllMaterialsQueryValidator>());

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

        #endregion // Public_Methods

        #region Private_Methods

        private void SetTranslationsServices(IServiceCollection services)
        {
            services.AddScoped<ITranslationRepository, TranslationRepository>();
            services.AddScoped<IScriptTranslationRepository, TranslationRepository>();
            services.AddScoped<IParameterTranslationRepository, TranslationRepository>();
            services.AddScoped<IValueOptionTranslationRepository, TranslationRepository>();

            services.AddScoped<ITranslationService, TranslationService>();
        }

        private static void SetUpAutoMapper(IServiceCollection services)
        {
            services.AddAutoMapper(new Assembly[] {
                typeof(AutoMapperProfile).GetTypeInfo().Assembly,
                typeof(ScriptMappingProfile).GetTypeInfo().Assembly,
                typeof(DeadLoadsMappingProfile).GetTypeInfo().Assembly
            });
        }
        #endregion // Private_Methods
    }
}
