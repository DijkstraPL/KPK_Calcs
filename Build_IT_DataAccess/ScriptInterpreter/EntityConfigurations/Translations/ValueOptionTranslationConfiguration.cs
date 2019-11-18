using Build_IT_Data.Entities.Scripts.Translations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Build_IT_DataAccess.ScriptInterpreter.EntityConfigurations.Translations
{
    internal class ValueOptionTranslationConfiguration : IEntityTypeConfiguration<ValueOptionTranslation>
    {
        #region Public_Methods

        public void Configure(EntityTypeBuilder<ValueOptionTranslation> builder)
        {
            builder.ToTable("Scripts_ValueOptionsTranslations");
        }

        #endregion // Public_Methods
    }
}
