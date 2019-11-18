using Build_IT_Data.Entities.DeadLoads;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Build_IT_DataAccess.DeadLoads.EntityConfigurations
{
    internal class MaterialConfiguration : IEntityTypeConfiguration<Material>
    {
        #region Public_Methods

        public void Configure(EntityTypeBuilder<Material> builder)
        {
            builder.ToTable("DeadLoads_Materials");

            builder.Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(m => m.MinimumDensity)
                .IsRequired();

            builder.Property(m => m.MaximumDensity)
                .IsRequired();

            builder.Property(m => m.Unit)
                .IsRequired();
        }

        #endregion // Public_Methods
    }
}
