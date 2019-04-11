using Build_IT_DataAccess.DeadLoads.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_DataAccess.DeadLoads
{
    public class DeadLoadsDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<Material> Materials { get; set; }

        public DeadLoadsDbContext(DbContextOptions<DeadLoadsDbContext> options)
            : base(options)
        {
        }

    }
}
