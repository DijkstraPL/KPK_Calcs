using Build_IT_Data.Entities.Scripts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_DataAccess.ScriptInterpreter.EntityConfigurations
{
    internal class TestDataConfiguration : IEntityTypeConfiguration<TestData>
    {
        #region Public_Methods
        
        public void Configure(EntityTypeBuilder<TestData> builder)
        {
            builder.ToTable("Scripts_TestDatas");

            builder.Property(td => td.Name)
                .HasMaxLength(255);

            builder.HasOne<Script>(td => td.Script);

            builder.HasMany<TestParameter>(td => td.TestParameters)
                .WithOne(st => st.TestData)
                .HasForeignKey(st => st.TestDataId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany<Assertion>(td => td.Assertions)
                .WithOne(st => st.TestData)
                .HasForeignKey(st => st.TestDataId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        #endregion // Public_Methods
    }
}
