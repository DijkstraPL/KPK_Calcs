using Build_IT_DataAccess.ScriptInterpreter.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_DataAccess.ScriptInterpreter.EntityConfigurations
{
    public class ParameterPhotoConfiguration : IEntityTypeConfiguration<ParameterPhoto>
    {
        #region Public_Methods
        
        public void Configure(EntityTypeBuilder<ParameterPhoto> builder)
        {
            builder.ToTable("ParameterPhotos");

            builder.HasKey(st
                => new { st.ParameterId, st.PhotoId });
        }

        #endregion // Public_Methods
    }
}
