using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseAccess
{
    class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasIndex(e => e.Username)
                .IsUnique();
            builder
                .Property(e => e.RowVersion)
                .IsRequired()
                .IsRowVersion()
                .IsConcurrencyToken();
            builder
                .Property(e => e.Username)
                .HasMaxLength(20);
            builder
                .HasMany(e => e.Days)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId);
        }
    }
}
