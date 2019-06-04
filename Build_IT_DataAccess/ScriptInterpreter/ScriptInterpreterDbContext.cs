using Build_IT_DataAccess.ScriptInterpreter.EntityConfigurations;
using Build_IT_DataAccess.ScriptInterpreter.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.IO;

namespace Build_IT_DataAccess.ScriptInterpreter
{
    public class ScriptInterpreterDbContext : DbContext
    {
        #region Properties
        
        public DbSet<Script> Scripts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Parameter> Parameters { get; set; }

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
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("Scripts"));
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

        }

        #endregion // Protected_Methods
    }
}
