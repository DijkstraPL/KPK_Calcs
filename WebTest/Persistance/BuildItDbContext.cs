using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTest.Models;

namespace WebTest.Persistance
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
