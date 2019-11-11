using Build_IT_Data.Entities.Scripts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Build_IT_DataAccess.ScriptInterpreter.EntityConfigurations
{
    public class VersionConfiguration : IEntityTypeConfiguration<Version>
    {
        #region Public_Methods

        public void Configure(EntityTypeBuilder<Version> builder)
        {
            builder.ToTable("Scripts_Versions");
            
            builder.Property(v => v.Description)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(v => v.AccordingTo)
                .HasMaxLength(255);

            builder.HasMany<Parameter>(v => v.Parameters)
                .WithOne(p => p.Version)
                .HasForeignKey(p => p.VersionId);

            builder.Property(s => s.IsPublic)
                .HasDefaultValue(false);
        }

        #endregion // Public_Methods
    }
}
