using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Build_IT_Web.Data;
using Build_IT_Web.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
                .AddJsonOptions(opt => opt.SerializerSettings.ReferenceLoopHandling =
                Newtonsoft.Json.ReferenceLoopHandling.Ignore) //ignores self reference object 
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1) //validate api rules
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<GetAllMaterialsQueryValidator>());

            services.AddEntityFrameworkSqlServer();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "wwwroot/clientapp/dist";
                //configuration.RootPath = "wwwroot/clientapp/out-tsc";
            });










            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<ApplicationUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddIdentityServer()
                .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

            services.AddAuthentication()
                .AddIdentityServerJwt();
            services.AddControllersWithViews();
            services.AddRazorPages();
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
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
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseIdentityServer();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

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
