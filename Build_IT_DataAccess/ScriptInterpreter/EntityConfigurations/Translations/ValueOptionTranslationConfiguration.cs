using Build_IT_DataAccess.ScriptInterpreter.Models;
using Build_IT_DataAccess.ScriptInterpreter.Models.Translations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_DataAccess.ScriptInterpreter.EntityConfigurations.Translations
{
    public class ValueOptionTranslationConfiguration : IEntityTypeConfiguration<ValueOptionTranslation>
    {
        #region Public_Methods

        public void Configure(EntityTypeBuilder<ValueOptionTranslation> builder)
        {
            builder.ToTable("ValueOptionsTranslations");
        }

        #endregion // Public_Methods
    }
}
