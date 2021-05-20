using System.Collections.Generic;
namespace Domain.Entities
{
    public class Meal: BaseEntity
    {
        public string Name { get; set; }
        public int Calories { get; set; }
        public int Carbohydrates { get; set; }
        public int Fats { get; set; }
        public int Proteins { get; set; }
        public string Description { get; set; }
        public virtual List<Day> Days { get; set; }
    }
}