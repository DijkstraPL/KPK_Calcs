using Build_IT_DataAccess.DeadLoads.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_DataAccess.DeadLoads.EntityConfigurations
{
    public class MaterialConfiguration : IEntityTypeConfiguration<Material>
    {
        #region Public_Methods

        public void Configure(EntityTypeBuilder<Material> builder)
        {
            builder.ToTable("Materials");

            builder.Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(m => m.MinimumDensity)
                .IsRequired();

            builder.Property(m => m.MaximumDensity)
                .IsRequired();

            builder.Property(m => m.Unit)
                .IsRequired();
        }

        #endregion // Public_Methods
    }
}
