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
                .Property(e => e.Id)
                .UseIdentityColumn(1, 1);
            builder
                 .HasIndex(e => e.Username)
                 .IsUnique();
            builder
                .Property(e => e.Version)
                .IsRowVersion();
            builder
                .Property(e => e.Username)
                .HasMaxLength(20);
            builder
                .HasMany(e => e.Days)
                .WithOne(e => e.User);
        }
    }
}
