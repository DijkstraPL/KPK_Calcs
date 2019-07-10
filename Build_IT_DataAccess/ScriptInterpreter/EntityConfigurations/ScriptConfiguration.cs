using Build_IT_Data.Entities.Scripts;
using Build_IT_Data.Entities.Scripts.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Build_IT_DataAccess.ScriptInterpreter.EntityConfigurations
{
    public class ScriptConfiguration : IEntityTypeConfiguration<Script>
    {
        #region Public_Methods
        
        public void Configure(EntityTypeBuilder<Script> builder)
        {
            builder.ToTable("Scripts_Scripts");

            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(s => s.Description)
                .IsRequired();

            builder.HasMany<ScriptTag>(s => s.Tags)
                .WithOne(st => st.Script)
                .HasForeignKey(st => st.ScriptId);

            builder.Property(s => s.GroupName)
                .HasMaxLength(255);

            builder.Property(s => s.Author)
                .HasMaxLength(255);

            builder.Property(s => s.Version)
                .HasMaxLength(50);

            builder.Property(s => s.DefaultLanguage)
                .HasDefaultValue(Language.English);

            builder.Property(s => s.AccordingTo)
                .HasMaxLength(255);

            builder.HasMany<Parameter>(s => s.Parameters)
                .WithOne(p => p.Script)
                .HasForeignKey(p => p.ScriptId);
        }

        #endregion // Public_Methods
    }
}
