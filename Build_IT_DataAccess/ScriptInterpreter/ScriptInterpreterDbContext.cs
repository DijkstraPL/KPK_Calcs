using Build_IT_Data.Entities.Scripts;
using Build_IT_Data.Entities.Scripts.Translations;
using Build_IT_DataAccess.ScriptInterpreter.EntityConfigurations;
using Build_IT_DataAccess.ScriptInterpreter.EntityConfigurations.Translations;
using Build_IT_DataAccess.ScriptInterpreter.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Build_IT_DataAccess.ScriptInterpreter
{
    public class ScriptInterpreterDbContext : DbContext, IScriptInterpreterDbContext
    {
        #region Properties

        public DbSet<Script> Scripts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Parameter> Parameters { get; set; }
        public DbSet<Figure> Figures { get; set; }
        public DbSet<ScriptTranslation> ScriptsTranslations { get; set; }
        public DbSet<ParameterTranslation> ParametersTranslations { get; set; }
        public DbSet<ValueOptionTranslation> ValueOptionsTranslations { get; set; }

        #endregion // Properties

        #region Fields

        static private IConfigurationRoot _configuration;

        #endregion // Fields

        #region Constructors

        public ScriptInterpreterDbContext(DbContextOptions<ScriptInterpreterDbContext> options)
            : base(options)
        {
        }

        #endregion // Constructors

        #region Protected_Methods

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                if(_configuration == null)
                {
                    var builder = new ConfigurationBuilder()
                      .SetBasePath(Directory.GetCurrentDirectory())
                      .AddJsonFile("appsettings.json");

                    _configuration = builder.Build();
                }
#if RELEASE
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("Scripts"));
#endif
#if DEBUG
                optionsBuilder.UseSqlServer(_configuration.GetSection("TestConnectionStrings").GetValue<string>("Scripts"));
#endif
            }
            else
                base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ScriptConfiguration());
            modelBuilder.ApplyConfiguration(new TagConfiguration());
            modelBuilder.ApplyConfiguration(new ParameterConfiguration());
            modelBuilder.ApplyConfiguration(new ValueOptionConfiguration());
            modelBuilder.ApplyConfiguration(new ScriptTagConfiguration());
            modelBuilder.ApplyConfiguration(new ParameterFigureConfiguration());
            modelBuilder.ApplyConfiguration(new FigureConfiguration());

            modelBuilder.ApplyConfiguration(new ScriptTranslationConfiguration());
            modelBuilder.ApplyConfiguration(new ParameterTranslationConfiguration());
            modelBuilder.ApplyConfiguration(new ValueOptionTranslationConfiguration());
        }

#endregion // Protected_Methods
    }
}
