using Build_IT_Data.Entities.Scripts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Build_IT_DataAccess.ScriptInterpreter.EntityConfigurations
{
    internal class TagConfiguration : IEntityTypeConfiguration<Tag>
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
