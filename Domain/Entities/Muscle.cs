﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Muscle: BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<Exercise> Exercises { get; set; }
    }
}
