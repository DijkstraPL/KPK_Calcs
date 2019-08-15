using Build_IT_Data.Entities.Scripts.Translations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Build_IT_DataAccess.ScriptInterpreter.EntityConfigurations.Translations
{
    internal class ScriptTranslationConfiguration : IEntityTypeConfiguration<ScriptTranslation>
    {
        #region Public_Methods

        public void Configure(EntityTypeBuilder<ScriptTranslation> builder)
        {
            builder.ToTable("Scripts_ScriptsTranslations");

            builder.Property(s => s.Name)
                .HasMaxLength(255);
        }

        #endregion // Public_Methods
    }
}
