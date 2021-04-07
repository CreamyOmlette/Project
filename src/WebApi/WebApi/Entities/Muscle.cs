using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Entities
{
    public class Muscle: IEntity
    {
        //public int MuscleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<Exercise> Exercises { get; set; }
    }
}
