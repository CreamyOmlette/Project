using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseAccess;
using Domain.Entities;

namespace WebApplication.Seeds
{
    public partial class Seed
    {
        public static async Task SeedUsers(ApplicationContext context)
        {
            if (!context.Users.Any())
            {
                var routines = context.Routines.ToList();
                var meals = context.Meals.ToList();
                var user = new User
                {
                    Username = "CreamyOmlette",
                    Height = 186,
                    Weight = 83,
                    Password = "022746598$Aa",
                    DoB = new DateTime(1999,6,18),
                    Days = new List<Day>{new Day
                    {
                        Date = DateTime.Now.Date,
                        Routines = new List<Routine>{routines[0]},
                        Meals = new List<Meal>{meals[0]}
                    }}
                };
                await context.Users.AddAsync(user);
                await context.SaveChangesAsync();
            }
        }
    }
}