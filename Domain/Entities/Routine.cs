using System.Collections.Generic;
using System;
namespace Domain.Entities
{
    public class Routine: BaseEntity
    {
        public string Name { get; set; }
        public int Difficulty { get; set; }
        public string Description { get; set; }
        public virtual List<Exercise> Exercises { get; set; }
        public virtual List<Day> Days { get; set; }

    }

    public class CardioRoutine: Routine
    {
        public TimeSpan Duration { get; set; }
        public int Intensity { get; set; }

    }

    public class GymRoutine: Routine
    {
        public int Reps { get; set; }
        public int Sets { get; set; }
    }
}