using System.Collections.Generic;
namespace WebApi.Entities
{
    public class Meal: IEntity
    {
        //public int MealId { get; set; }
        public string Name { get; set; }
        public int Calories { get; set; }
        public int Carbohydrates { get; set; }
        public int Fats { get; set; }
        public int Proteins { get; set; }
        public string Description { get; set; }
        public virtual List<Day> Days { get; set; }
    }
}