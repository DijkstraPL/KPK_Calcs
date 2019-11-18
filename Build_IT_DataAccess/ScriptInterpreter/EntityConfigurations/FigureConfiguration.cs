using Build_IT_Data.Entities.Scripts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Build_IT_DataAccess.ScriptInterpreter.EntityConfigurations
{
    internal class FigureConfiguration : IEntityTypeConfiguration<Figure>
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
