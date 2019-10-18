using Build_IT_Data.Entities.Scripts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Build_IT_DataAccess.ScriptInterpreter.EntityConfigurations
{
    internal class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        #region Public_Methods

        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.ToTable("Scripts_Groups");

            builder.Property(g => g.Name)
                .IsRequired();

            builder.HasMany<Parameter>(g => g.Parameters)
                .WithOne(p => p.Group)
                .HasForeignKey(p => p.GroupId);
        }

        #endregion // Public_Methods
    }
}
