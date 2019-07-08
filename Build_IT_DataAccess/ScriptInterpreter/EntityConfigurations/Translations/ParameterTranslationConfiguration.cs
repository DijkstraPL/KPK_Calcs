using Build_IT_DataAccess.ScriptInterpreter.Models;
using Build_IT_DataAccess.ScriptInterpreter.Models.Translations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

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
