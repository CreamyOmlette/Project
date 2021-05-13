using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseAccess;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
namespace WebApplication.Seeds
{
    public partial class Seed
    {
        public async Task MealSeed(ApplicationContext context)
        {
            if (!context.Meals.Any())
            {
                var meals = new List<Meal>
                {
                    new Meal(){
                        Name = "Spaghetti Carbonara",
                        Calories = 413,
                        Carbohydrates = 34,
                        Fats = 46,
                        Proteins = 20,
                        Description = "Carbonara is an Italian pasta dish from Rome made with egg, hard cheese, cured pork, and black pepper. The dish arrived at its modern form, with its current name, in the middle of the 20th century.",
                        Id = 1,
                        Mass = 400
                    },
                    new Meal(){
                        Name = "Dumplings",
                        Calories = 510,
                        Carbohydrates = 39,
                        Fats = 39,
                        Proteins = 22,
                        Description = "",
                        Id = 2
                    },
                    new Meal(){
                        Name = "",
                        Calories = 0,
                        Carbohydrates = 0,
                        Fats = 0,
                        Proteins = 0,
                        Description = "",
                        Id = 1
                    },
                    new Meal(){
                        Name = "",
                        Calories = 0,
                        Carbohydrates = 0,
                        Fats = 0,
                        Proteins = 0,
                        Description = "",
                        Id = 1
                    },
                    new Meal(){
                        Name = "",
                        Calories = 0,
                        Carbohydrates = 0,
                        Fats = 0,
                        Proteins = 0,
                        Description = "",
                        Id = 1
                    },
                    new Meal(){
                        Name = "",
                        Calories = 0,
                        Carbohydrates = 0,
                        Fats = 0,
                        Proteins = 0,
                        Description = "",
                        Id = 1
                    },
                    new Meal(){
                        Name = "",
                        Calories = 0,
                        Carbohydrates = 0,
                        Fats = 0,
                        Proteins = 0,
                        Description = "",
                        Id = 1
                    },
                    new Meal(){
                        Name = "",
                        Calories = 0,
                        Carbohydrates = 0,
                        Fats = 0,
                        Proteins = 0,
                        Description = "",
                        Id = 1
                    },
                };
            }
        }
    }
}