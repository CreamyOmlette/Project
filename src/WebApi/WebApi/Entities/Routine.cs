using System.Collections.Generic;

namespace WebApi.Entities
{
    public class Routine: IEntity
    {
        //public int RoutineId { get; set; }
        public string Name { get; set; }
        public int Difficulty { get; set; }
        public string Description { get; set; }
        public virtual List<Exercise> Exercises { get; set; }
        public virtual List<Day> Days { get; set; }

    }
}