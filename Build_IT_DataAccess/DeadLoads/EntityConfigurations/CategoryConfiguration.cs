using Build_IT_DataAccess.DeadLoads.Models;
using Build_IT_DataAccess.ScriptInterpreter.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_DataAccess.DeadLoads.EntityConfigurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        #region Public_Methods

        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("DeadLoads_Categories");

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasMany<Subcategory>(c => c.Subcategories)
                .WithOne(sc => sc.Category)
                .HasForeignKey(sc => sc.CategoryId);
        }

        #endregion // Public_Methods
    }
}
