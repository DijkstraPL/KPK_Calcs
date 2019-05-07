using Build_IT_DataAccess.ScriptInterpreter.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_DataAccess.ScriptInterpreter.EntityConfigurations
{
    public class ParameterConfiguration : IEntityTypeConfiguration<Parameter>
    {
        #region Public_Methods

        public void Configure(EntityTypeBuilder<Parameter> builder)
        {
            builder.ToTable("Parameters");

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(p => p.Number)
                .IsRequired();

            builder.Property(p => p.ValueType)
                .IsRequired();

            builder.HasMany<ValueOption>(p => p.ValueOptions)
                .WithOne(vo => vo.Parameter)
                .HasForeignKey(vo => vo.ParameterId);

            builder.HasMany<AlternativeScript>(p => p.NestedScripts)
                .WithOne(s => s.Parameter)
                .HasForeignKey(s => s.ParameterId);
        }

        #endregion // Public_Methods
    }
}
