using AutoMapper;
using Build_IT_Application.Application.User.Commands.CreateUser;
using Build_IT_Application.Application.User.Commands.GetToken;
using Build_IT_Application.DeadLoads.Categories.Queries.GetAllCategories;
using Build_IT_Application.DeadLoads.Materials.Queries.GetAllMaterials;
using Build_IT_Application.Infrastructures;
using Build_IT_Application.Interfaces;
using Build_IT_Application.Mapping;
using Build_IT_CommonTools;
using Build_IT_CommonTools.Interfaces;
using Build_IT_Data.Entities.Application;
using Build_IT_Data.Entities.Scripts;
using Build_IT_DataAccess;
using Build_IT_DataAccess.Application;
using Build_IT_DataAccess.Application.Interfaces;
using Build_IT_DataAccess.DeadLoads;
using Build_IT_DataAccess.DeadLoads.Interfaces;
using Build_IT_DataAccess.DeadLoads.Repositories;
using Build_IT_DataAccess.DeadLoads.Repositories.Interfaces;
using Build_IT_DataAccess.ScriptInterpreter;
using Build_IT_DataAccess.ScriptInterpreter.Interfaces;
using Build_IT_DataAccess.ScriptInterpreter.Repositiories;
using Build_IT_DataAccess.ScriptInterpreter.Repositiories.Interfaces;
using Build_IT_Web.Services.Interfaces;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Reflection;
using System.Text;
using System.Text.Json;

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

            SetTranslationsServices(services);

            SetDbContexts(services, dataAccessAssemblyName);
            SetRepositoriesServices(services);

            services.AddScoped<IDateTime, MyDateTime>();
            services.AddTransient<INotificationService, NotificationService>();
            AddAuthorizationServices(services);

            ConfigureMediatR(services);

            SetUpAutoMapper(services);

            SetAuthorizationServices(services);
            SetAuthenticationServices(services);

            services.AddMvc()
                .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore) //ignores self reference object 
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0) //validate api rules
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<GetAllMaterialsQueryValidator>());

            services.AddEntityFrameworkSqlServer();

            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            //});


            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "wwwroot/clientapp/dist";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            //app.UseSwagger();
            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            //});

            app.UseRouting();

            app.UseAuthentication();
           // app.UseIdentityServer();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }
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

            using (var serviceScope =
                app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();
                var userManager = serviceScope.ServiceProvider.GetService<UserManager<ApplicationUser>>();
                dbContext.Database.Migrate();
                DbSeeder.Seed(dbContext, roleManager, userManager);
            }
        }

        #endregion // Public_Methods

        #region Private_Methods

        private void SetTranslationsServices(IServiceCollection services)
        {
            services.AddScoped<ITranslationRepository, TranslationRepository>();
            services.AddScoped<IScriptTranslationRepository, TranslationRepository>();
            services.AddScoped<IParameterTranslationRepository, TranslationRepository>();
            services.AddScoped<IValueOptionTranslationRepository, TranslationRepository>();

            services.AddScoped<Build_IT_Application.Infrastructures.Interfaces.ITranslationService, Build_IT_Application.Infrastructures.TranslationService>();
            services.AddScoped<ITranslationService, Services.TranslationService>();
        }

        private void SetDbContexts(IServiceCollection services, string dataAccessAssemblyName)
        {
#if RELEASE
            services.AddDbContext<ScriptInterpreterDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("Scripts"), 
                b => b.MigrationsAssembly(dataAccessAssemblyName)));
            
            services.AddDbContext<DeadLoadsDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("DeadLoads"),
                b => b.MigrationsAssembly(dataAccessAssemblyName)));
            
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("Application"),
                b => b.MigrationsAssembly(dataAccessAssemblyName)));
#endif
#if DEBUG
            services.AddDbContext<ScriptInterpreterDbContext>(
                options => options.UseSqlServer(Configuration.GetSection("TestConnectionStrings").GetValue<string>("Scripts"),
                b => b.MigrationsAssembly(dataAccessAssemblyName)));

            services.AddDbContext<DeadLoadsDbContext>(
                options => options.UseSqlServer(Configuration.GetSection("TestConnectionStrings").GetValue<string>("DeadLoads"),
                b => b.MigrationsAssembly(dataAccessAssemblyName)));

            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(Configuration.GetSection("TestConnectionStrings").GetValue<string>("Application"),
                b => b.MigrationsAssembly(dataAccessAssemblyName)));
#endif
        }

        private void SetRepositoriesServices(IServiceCollection services)
        {
            services.AddScoped<IApplicationUnitOfWork, ApplicationUnitOfWork>();

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ISubcategoryRepository, SubcategoryRepository>();
            services.AddScoped<IMaterialRepository, MaterialRepository>();

            services.AddScoped<IDeadLoadsUnitOfWork, DeadLoadsUnitOfWork>();

            services.AddScoped<IScriptRepository, ScriptRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<IParameterRepository, ParameterRepository>();

            services.AddScoped<IScriptInterpreterUnitOfWork, ScriptInterpreterUnitOfWork>();
        }

        private void AddAuthorizationServices(IServiceCollection services)
        {
            services.AddTransient<IRequestHandler<CreateUserCommand>, CreateUserCommand.Handler>();
            services.AddTransient<IRequestHandler<TokenRequestCommand, TokenResponseQuery>, TokenRequestCommand.Handler>();
        }

        private void ConfigureMediatR(IServiceCollection services)
        {
            services.AddMediatR(typeof(GetAllCategoriesQuery.Handler).GetTypeInfo().Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
        }

        private void SetUpAutoMapper(IServiceCollection services)
        {
            services.AddAutoMapper(new Assembly[] {
                typeof(AutoMapperProfile).GetTypeInfo().Assembly,
                typeof(ScriptMappingProfile).GetTypeInfo().Assembly,
                typeof(DeadLoadsMappingProfile).GetTypeInfo().Assembly
            });

            services.AddScoped<IScriptMappingProfile, ScriptMappingProfile>();
        }

        private void SetAuthorizationServices(IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>(
                options =>
                {
                    options.Password.RequireDigit = true;
                    options.Password.RequireLowercase = true;
                    options.Password.RequireUppercase = true;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequiredLength = 7;
                }).AddEntityFrameworkStores<ApplicationDbContext>();

        }

        private void SetAuthenticationServices(IServiceCollection services)
        {
            services.AddAuthentication(opts =>
            {
                opts.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                opts.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opts.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidIssuer = Configuration["Auth:Jwt:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(
                           Encoding.UTF8.GetBytes(Configuration["Auth:Jwt:Key"])),
                    ValidAudience = Configuration["Auth:Jwt:Audience"],
                    ClockSkew = TimeSpan.Zero,

                    RequireExpirationTime = true,
                    ValidateIssuer = true,
                    ValidateIssuerSigningKey = true,
                    ValidateAudience = true
                };
            });
        }


        #endregion // Private_Methods
    }
}
