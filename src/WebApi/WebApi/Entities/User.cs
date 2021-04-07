using System;
using System.Collections.Generic;
namespace WebApi.Entities
{
    public class User: IEntity
    {
        //public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public DateTime DoB { get; set; }
        public virtual List<Day> Days { get; set; }
    } 
}