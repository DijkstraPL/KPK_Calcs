using Build_IT_DataAccess.ScriptInterpreter.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_DataAccess.ScriptInterpreter.EntityConfigurations
{
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        #region Public_Methods
        
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.ToTable("Scripts_Tags");

            builder.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);
        }

        #endregion // Public_Methods
    }
}
