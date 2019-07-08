using Build_IT_DataAccess.ScriptInterpreter.Models;
using Build_IT_DataAccess.ScriptInterpreter.Models.Translations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_DataAccess.ScriptInterpreter.EntityConfigurations.Translations
{
    public class ScriptTranslationConfiguration : IEntityTypeConfiguration<ScriptTranslation>
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
