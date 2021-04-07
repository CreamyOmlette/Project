using System;

namespace Domain.Entities
{
    public class Day
    {
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public string Notes { get; set; }
    }
}