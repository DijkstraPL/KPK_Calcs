using Build_IT_Data.Entities.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_DataAccess.Application.EntityConfigurations
{
    internal class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        #region Public_Methods

        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.ToTable("Application_Users");

            builder.Property(p => p.Type)
                .IsRequired();

            builder.Property(p => p.Flags)
                .IsRequired();

            builder.Property(p => p.CreatedDate)
                .IsRequired();

            builder.Property(p => p.LastModifiedDate)
                .IsRequired();
        }

        #endregion // Public_Methods
    }
}
