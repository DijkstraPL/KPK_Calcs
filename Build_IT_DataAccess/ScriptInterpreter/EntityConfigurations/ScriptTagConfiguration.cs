using Build_IT_Data.Entities.Scripts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Build_IT_DataAccess.ScriptInterpreter.EntityConfigurations
{
    public class ScriptTagConfiguration : IEntityTypeConfiguration<ScriptTag>
    {
        #region Public_Methods
        
        public void Configure(EntityTypeBuilder<ScriptTag> builder)
        {
            builder.ToTable("Scripts_ScriptTags");

            builder.HasKey(st
                => new { st.ScriptId, st.TagId });
        }

        #endregion // Public_Methods
    }
}
