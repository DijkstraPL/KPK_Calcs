using Build_IT_DataAccess.ScriptInterpreter.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_DataAccess.ScriptInterpreter.EntityConfigurations
{
    public class ScriptTagConfiguration : IEntityTypeConfiguration<ScriptTag>
    {
        #region Public_Methods
        
        public void Configure(EntityTypeBuilder<ScriptTag> builder)
        {
            builder.ToTable("ScriptTags");

            builder.HasKey(st
                => new { st.ScriptId, st.TagId });
        }

        #endregion // Public_Methods
    }
}
