using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
namespace DatabaseAccess
{
    public class ApplicationContext : DbContext
    {
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=Test;Trusted_Connection=True;", b => b.MigrationsAssembly("WebApplication"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Day>()
                .HasKey(e => new { e.UserId, e.Date });
            modelBuilder.Entity<User>()
                .HasIndex(e => e.Username)
                .IsUnique();
            modelBuilder.Entity<User>()
                .Property(e => e.Id)
                .UseIdentityColumn(1, 1);
            modelBuilder.Entity<User>()
                .Property(e => e.Version)
                .IsRowVersion();
           // modelBuilder.Entity<CardioRoutine>()
                //.ToTable("CardioRoutines");
           // modelBuilder.Entity<GymRoutine>()
                //.ToTable("GymRoutines");
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Day> Days { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Routine> Routines { get; set; }
        public DbSet<CardioRoutine> CardioRoutines { get; set; }
        public DbSet<GymRoutine> GymRoutines { get; set; }
    }
}
