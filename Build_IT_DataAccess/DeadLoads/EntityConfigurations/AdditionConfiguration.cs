using Build_IT_Data.Entities.DeadLoads;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Build_IT_DataAccess.DeadLoads.EntityConfigurations
{
    public class AdditionConfiguration : IEntityTypeConfiguration<Addition>
    {
        #region Public_Methods

        public void Configure(EntityTypeBuilder<Addition> builder)
        {
            builder.ToTable("DeadLoads_Additions");

            builder.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(124);

            builder.Property(a => a.Value)
                .IsRequired();
        }

        #endregion // Public_Methods
    }
}
