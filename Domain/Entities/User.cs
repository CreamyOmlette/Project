using System;
using System.Collections.Generic;
namespace Domain.Entities
{
    public class User: BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int? Height { get; set; }
        public int? Weight { get; set; }
        public DateTime? DoB { get; set; }
        public virtual List<Day> Days { get; set; }
        public byte[] Version { get; set; }
    } 
}