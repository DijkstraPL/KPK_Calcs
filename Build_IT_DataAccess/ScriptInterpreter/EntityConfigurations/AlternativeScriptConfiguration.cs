using Build_IT_DataAccess.ScriptInterpreter.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_DataAccess.ScriptInterpreter.EntityConfigurations
{
    public class AlternativeScriptConfiguration : IEntityTypeConfiguration<AlternativeScript>
    {
        #region Public_Methods
        
        public void Configure(EntityTypeBuilder<AlternativeScript> builder)
        {
            builder.ToTable("AlternativeScripts");

            builder.Property(s => s.ScriptName)
                .IsRequired()
                .HasMaxLength(255);
        }

        #endregion // Public_Methods
    }
}
