using Build_IT_DataAccess.ScriptInterpreter.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_DataAccess.ScriptInterpreter.EntityConfigurations
{
    public class FigureConfiguration : IEntityTypeConfiguration<Figure>
    {
        #region Public_Methods

        public void Configure(EntityTypeBuilder<Figure> builder)
        {
            builder.ToTable("Scripts_Figures");

            builder.HasKey(f => f.Id);

            builder.Property(f => f.FileName)
                .IsRequired()
                .HasMaxLength(255);
        }

        #endregion // Public_Methods
    }
}
