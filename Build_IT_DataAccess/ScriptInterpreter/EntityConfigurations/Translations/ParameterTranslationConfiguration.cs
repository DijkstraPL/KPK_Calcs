using Build_IT_Data.Entities.Scripts.Translations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Build_IT_DataAccess.ScriptInterpreter.EntityConfigurations.Translations
{
    public class ParameterTranslationConfiguration : IEntityTypeConfiguration<ParameterTranslation>
    {
        #region Public_Methods

        public void Configure(EntityTypeBuilder<ParameterTranslation> builder)
        {
            builder.ToTable("Scripts_ParametersTranslations");
        }

        #endregion // Public_Methods
    }
}
