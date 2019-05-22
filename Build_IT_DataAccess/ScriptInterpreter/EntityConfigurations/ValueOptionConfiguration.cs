using Build_IT_DataAccess.ScriptInterpreter.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_DataAccess.ScriptInterpreter.EntityConfigurations
{
    public class ValueOptionConfiguration : IEntityTypeConfiguration<ValueOption>
    {
        #region Public_Methods
        
        public void Configure(EntityTypeBuilder<ValueOption> builder)
        {
            builder.ToTable("ValueOptions");

            builder.Property(vo => vo.Name)
                .IsRequired();

            builder.Property(vo => vo.Value)
                .IsRequired();
        }

        #endregion // Public_Methods
    }
}
