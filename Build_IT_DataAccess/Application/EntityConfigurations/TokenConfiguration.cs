using Build_IT_Data.Entities.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_DataAccess.Application.EntityConfigurations
{
    internal class TokenConfiguration : IEntityTypeConfiguration<Token>
    {
        #region Public_Methods

        public void Configure(EntityTypeBuilder<Token> builder)
        {
            builder.ToTable("Application_Tokens");

            builder.Property(p => p.Id)
                .IsRequired();

            builder.Property(p => p.ClientId)
                .IsRequired();

            builder.Property(p => p.Value)
                .IsRequired();

            builder.Property(p => p.ApplicationUserId)
                .IsRequired();

            builder.Property(p => p.CreatedDate)
                .IsRequired();

            builder.Property(p => p.LastModifiedDate)
                .IsRequired();
        }

        #endregion // Public_Methods
    }
}
