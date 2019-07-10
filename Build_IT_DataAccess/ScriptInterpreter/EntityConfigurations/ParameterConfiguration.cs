using Build_IT_Data.Entities.Scripts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Build_IT_DataAccess.ScriptInterpreter.EntityConfigurations
{
    public class ParameterConfiguration : IEntityTypeConfiguration<Parameter>
    {
        #region Public_Methods

        public void Configure(EntityTypeBuilder<Parameter> builder)
        {
            builder.ToTable("Scripts_Parameters");

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

            builder.HasMany<ParameterFigure>(p => p.ParameterFigures)
                .WithOne(pp => pp.Parameter)
                .HasForeignKey(pp => pp.ParameterId);
        }

        #endregion // Public_Methods
    }
}
