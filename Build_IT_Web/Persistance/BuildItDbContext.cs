﻿using Microsoft.EntityFrameworkCore;
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
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Parameter> Parameters { get; set; }

        public BuildItDbContext(DbContextOptions<BuildItDbContext> options)
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
