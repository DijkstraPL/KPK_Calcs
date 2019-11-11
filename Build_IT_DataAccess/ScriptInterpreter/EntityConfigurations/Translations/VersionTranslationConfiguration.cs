using Build_IT_Data.Entities.Scripts.Translations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_DataAccess.ScriptInterpreter.EntityConfigurations.Translations
{
    public class VersionTranslationConfiguration : IEntityTypeConfiguration<VersionTranslation>
    {
        #region Public_Methods

        public void Configure(EntityTypeBuilder<VersionTranslation> builder)
        {
            builder.ToTable("Scripts_VersionsTranslations");

            builder.Property(s => s.Description)
                .HasMaxLength(255);
        }

        #endregion // Public_Methods
    }
}
