using System.Collections.Generic;
namespace WebApi.Entities
{
    public class Exercise: IEntity
    {
        //public int ExerciseId { get; set; }
        public string Name { get; set; }
        public int Reps { get; set; }
        public int Sets { get; set; }
        public int Intensity { get; set; }
        public int Time { get; set; }
        public virtual List<Routine> Routines { get; set; }
        public virtual List<Muscle> Muscles { get; set; }
    }
}