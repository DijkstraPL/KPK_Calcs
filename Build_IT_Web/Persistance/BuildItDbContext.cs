using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Build_IT_Web.Models;

namespace Build_IT_Web.Persistance
{
    public class BuildItDbContext : DbContext
    {
        public DbSet<Script> Scripts { get; set; }
        
        public BuildItDbContext(DbContextOptions<BuildItDbContext> options)
            :base(options)
        {

        }
    }
}
