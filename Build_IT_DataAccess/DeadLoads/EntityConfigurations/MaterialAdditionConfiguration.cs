using Build_IT_Data.Entities.DeadLoads;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Build_IT_DataAccess.DeadLoads.EntityConfigurations
{
    internal class MaterialAdditionConfiguration : IEntityTypeConfiguration<MaterialAddition>
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
