using Build_IT_DataAccess.ScriptInterpreter.Models;
using Microsoft.EntityFrameworkCore;

namespace Build_IT_DataAccess.ScriptInterpreter
{
    public class ScriptInterpreterDbContext : DbContext
    {
        public DbSet<Script> Scripts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Parameter> Parameters { get; set; }

        public ScriptInterpreterDbContext(DbContextOptions<ScriptInterpreterDbContext> options)
            :base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ScriptTag>().HasKey(st
                => new { st.ScriptId, st.TagId });            
        }
    }
}
