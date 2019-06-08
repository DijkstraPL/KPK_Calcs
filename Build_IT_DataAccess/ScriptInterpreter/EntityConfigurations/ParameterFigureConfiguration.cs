using Build_IT_DataAccess.ScriptInterpreter.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_DataAccess.ScriptInterpreter.EntityConfigurations
{
    public class ParameterFigureConfiguration : IEntityTypeConfiguration<ParameterFigure>
    {
        #region Public_Methods

        public void Configure(EntityTypeBuilder<ParameterFigure> builder)
        {
            builder.ToTable("ParameterFigures");

            builder.HasKey(pf
                => new { pf.ParameterId, pf.FigureId });
        }

        #endregion // Public_Methods
    }
}
