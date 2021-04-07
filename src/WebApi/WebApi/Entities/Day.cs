using System;
using System.Collections.Generic;
namespace WebApi.Entities
{
    public class Day: IEntity
    {
        //public int UserId { get; set; }
        public DateTime Date { get; set; }
        public string Notes { get; set; }

        public List<Routine> Routines { get; set; }
        public virtual List<Meal> Meals { get; set; } 

        public virtual User User { get; set; }

    }
}