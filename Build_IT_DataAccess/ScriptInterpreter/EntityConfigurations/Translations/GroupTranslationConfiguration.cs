using Build_IT_Data.Entities.Scripts.Translations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Build_IT_DataAccess.ScriptInterpreter.EntityConfigurations.Translations
{
    internal class GroupTranslationConfiguration : IEntityTypeConfiguration<GroupTranslation>
    {
        #region Public_Methods

        public void Configure(EntityTypeBuilder<GroupTranslation> builder)
        {
            builder.ToTable("Scripts_GroupTranslations");
        }

        #endregion // Public_Methods
    }
}
