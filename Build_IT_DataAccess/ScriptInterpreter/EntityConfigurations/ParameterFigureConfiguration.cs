using Build_IT_Data.Entities.Scripts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Build_IT_DataAccess.ScriptInterpreter.EntityConfigurations
{
    public class ParameterFigureConfiguration : IEntityTypeConfiguration<ParameterFigure>
    {
        #region Public_Methods

        public void Configure(EntityTypeBuilder<ParameterFigure> builder)
        {
            builder.ToTable("Scripts_ParameterFigures");

            builder.HasKey(pf
                => new { pf.ParameterId, pf.FigureId });
        }

        #endregion // Public_Methods
    }
}
