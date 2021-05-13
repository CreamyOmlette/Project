using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
namespace DatabaseAccess
{
    public class ApplicationContext : DbContext
    {

        public ApplicationContext(DbContextOptions options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public DbSet<User> Users { get; set; }
        
        public DbSet<Day> Days { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Routine> Routines { get; set; }
        public DbSet<Muscle> Muscles { get; set; }
    }
}
