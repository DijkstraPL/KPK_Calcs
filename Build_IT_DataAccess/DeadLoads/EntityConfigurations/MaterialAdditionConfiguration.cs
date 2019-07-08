using Build_IT_DataAccess.DeadLoads.Models;
using Build_IT_DataAccess.ScriptInterpreter.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_DataAccess.DeadLoads.EntityConfigurations
{
    public class MaterialAdditionConfiguration : IEntityTypeConfiguration<MaterialAddition>
    {
        #region Public_Methods

        public void Configure(EntityTypeBuilder<MaterialAddition> builder)
        {
            builder.ToTable("DeadLoads_MaterialAdditions");

            builder.HasKey(ma
                => new { ma.MaterialId, ma.AdditionId });
        }

        #endregion // Public_Methods
    }
}
