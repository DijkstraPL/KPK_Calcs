using Build_IT_Data.Entities.Scripts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_DataAccess.ScriptInterpreter.EntityConfigurations
{
    internal class AssertionConfiguration : IEntityTypeConfiguration<Assertion>
    {
        #region Public_Methods

        public void Configure(EntityTypeBuilder<Assertion> builder)
        {
            builder.ToTable("Scripts_Assertions");

            builder.Property(s => s.Value)
                .IsRequired();
        }

        #endregion // Public_Methods
    }
}
