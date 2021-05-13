using System.ComponentModel.DataAnnotations;

namespace DatabaseAccess.Dtos
{
    public class MealDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        
        public string Description { get; set; }
        [Required]
        public string ImgSrc { get; set; }
        
        public int Mass { get; set; }
        
        public int Proteins { get; set; }
        
        public int Carbohydrates { get; set; }
        
        public int Fats { get; set; }
        
        public int Calories { get; set; }
    }
}