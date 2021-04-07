using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entities;
namespace WebApi
{
    public class ApplicationContext : DbContext
    {
        private string _connectionString;
        public ApplicationContext(DbContextOptions<ApplicationContext> options): base(options)
        {

        }
        public ApplicationContext(string connection)
        {
            _connectionString = connection;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Day>()
                .HasKey(obj => new { obj.Id, obj.Date });
            builder.Entity<User>()
                .HasKey(x => x.Id);
            builder.Entity<User>()
                .HasIndex(x => x.Username)
                .IsUnique();
            builder.Entity<User>()
                .HasMany(x => x.Days)
                .WithOne(x => x.User)
                .OnDelete(DeleteBehavior.Cascade);
                
            builder.Entity<Day>()
                .HasMany(x => x.Routines)
                .WithMany(x => x.Days);
            builder.Entity<Meal>()
                .HasMany(x => x.Days)
                .WithMany(x => x.Meals);
            builder.Entity<Exercise>()
                .HasMany(x => x.Routines)
                .WithMany(x => x.Exercises);
            builder.Entity<Muscle>()
                .HasMany(x => x.Exercises)
                .WithMany(x => x.Muscles);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Day> Days { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Routine> Routines { get; set; }

    }
}
