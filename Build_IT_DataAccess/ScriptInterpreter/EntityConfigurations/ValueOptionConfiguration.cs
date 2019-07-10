using Build_IT_Data.Entities.Scripts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Build_IT_DataAccess.ScriptInterpreter.EntityConfigurations
{
    public class ValueOptionConfiguration : IEntityTypeConfiguration<ValueOption>
    {
        #region Public_Methods
        
        public void Configure(EntityTypeBuilder<ValueOption> builder)
        {
            builder.ToTable("Scripts_ValueOptions");

            builder.Property(vo => vo.Name)
                .IsRequired();

            builder.Property(vo => vo.Value)
                .IsRequired();
        }

        #endregion // Public_Methods
    }
}
