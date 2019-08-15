using Build_IT_Data.Entities.Application;
using Build_IT_DataAccess.Application.EntityConfigurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Build_IT_DataAccess.Application
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        #region Properties
        
        public DbSet<Token> Tokens { get; set; }

        #endregion // Properties

        #region Constructors

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        #endregion // Constructors

        #region Public_Methods

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ApplicationUserConfiguration());
            modelBuilder.ApplyConfiguration(new TokenConfiguration());
        }

        #endregion // Public_Methods
    }
}
