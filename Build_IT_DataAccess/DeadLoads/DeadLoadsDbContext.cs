using Build_IT_DataAccess.DeadLoads.EntityConfigurations;
using Build_IT_DataAccess.DeadLoads.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_DataAccess.DeadLoads
{
    public class DeadLoadsDbContext : DbContext
    {
        #region Properties
        
        public DbSet<Category> Categories { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Addition> Additions { get; set; }
        public DbSet<MaterialAddition> MaterialAdditions { get; set; }

        #endregion // Properties

        #region Constructors

        public DeadLoadsDbContext(DbContextOptions<DeadLoadsDbContext> options)
            : base(options)
        {
        }

        #endregion // Constructors

        #region Public_Methods

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new SubcategoryConfiguration());
            modelBuilder.ApplyConfiguration(new MaterialConfiguration());
            modelBuilder.ApplyConfiguration(new MaterialAdditionConfiguration());
            modelBuilder.ApplyConfiguration(new AdditionConfiguration());
        }

        #endregion // Public_Methods
    }
}
