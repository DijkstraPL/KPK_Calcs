using Build_IT_Data.Entities.Scripts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_DataAccess.ScriptInterpreter.EntityConfigurations
{
    internal class TestParameterConfiguration : IEntityTypeConfiguration<TestParameter>
    {
        #region Public_Methods
        
        public void Configure(EntityTypeBuilder<TestParameter> builder)
        {
            builder.ToTable("Scripts_TestParameters");

            builder.Property(tp => tp.Value)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasOne(tp => tp.Parameter);
        }

        #endregion // Public_Methods
    }
}
