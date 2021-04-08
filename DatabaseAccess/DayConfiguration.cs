using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace DatabaseAccess
{
    class DayConfiguration : IEntityTypeConfiguration<Day>
    {
        public void Configure(EntityTypeBuilder<Day> builder)
        {
            builder
                .HasKey(e => new { e.UserId, e.Date });
            builder
                .HasMany(e => e.Routines)
                .WithMany(e => e.Days);
            builder
                .HasMany(e => e.Meals)
                .WithMany(e => e.Days);
        }
    }
}
