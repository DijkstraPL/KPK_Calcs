using Build_IT_DataAccess.ScriptInterpreter.EntityConfigurations;
using Build_IT_DataAccess.ScriptInterpreter.Models;
using Microsoft.EntityFrameworkCore;

namespace Build_IT_DataAccess.ScriptInterpreter
{
    public class ScriptInterpreterDbContext : DbContext
    {
        #region Properties
        
        public DbSet<Script> Scripts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Parameter> Parameters { get; set; }

        #endregion // Properties

        #region Constructors
        
        public ScriptInterpreterDbContext(DbContextOptions<ScriptInterpreterDbContext> options)
            : base(options)
        {
        }

        #endregion // Constructors

        #region Public_Methods
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ScriptConfiguration());
            modelBuilder.ApplyConfiguration(new TagConfiguration());
            modelBuilder.ApplyConfiguration(new ParameterConfiguration());
            modelBuilder.ApplyConfiguration(new ValueOptionConfiguration());
            modelBuilder.ApplyConfiguration(new AlternativeScriptConfiguration());
            modelBuilder.ApplyConfiguration(new ScriptTagConfiguration());

        }

        #endregion // Public_Methods
    }
}
