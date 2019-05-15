using Build_IT_DataAccess.DeadLoads.Models;
using Build_IT_DataAccess.ScriptInterpreter.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_DataAccess.DeadLoads.EntityConfigurations
{
    public class AdditionConfiguration : IEntityTypeConfiguration<Addition>
    {
        #region Public_Methods

        public void Configure(EntityTypeBuilder<Addition> builder)
        {
            builder.ToTable("Additions");

            builder.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(124);

            builder.Property(a => a.Value)
                .IsRequired();
        }

        #endregion // Public_Methods
    }
}
