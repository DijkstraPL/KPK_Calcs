using Build_IT_DataAccess.DeadLoads.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_DataAccess.DeadLoads.EntityConfigurations
{
    public class SubcategoryConfiguration : IEntityTypeConfiguration<Subcategory>
    {
        #region Public_Methods

        public void Configure(EntityTypeBuilder<Subcategory> builder)
        {
            builder.ToTable("DeadLoads_Subcategories");

            builder.Property(sc => sc.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasMany<Material>(sc => sc.Materials)
                .WithOne(m => m.Subcategory)
                .HasForeignKey(m => m.SubcategoryId);
        }

        #endregion // Public_Methods
    }
}
