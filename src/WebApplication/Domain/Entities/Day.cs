using System;
using System.Collections.Generic;
namespace Domain.Entities
{
    public class Day: BaseEntity
    {
        public DateTime Date { get; set; }
        public string Notes { get; set; }

        public List<Routine> Routines { get; set; }
        public virtual List<Meal> Meals { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }

    }
}