using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Domain.Entities;

namespace DatabaseAccess.Dtos
{
    public class UserDto
    {
        [Required]
        [StringLength(25, MinimumLength = 4, ErrorMessage = "Username must contain more than 4 symbols")]
        public string Username { get; set; }

        [Required]
        [Range(10,300, ErrorMessage = "Height is not valid")]
        public int Height { get; set; }
        
        [Required]
        [Range(10,250, ErrorMessage = "Weight is not valid")]
        public int Weight { get; set; }
        
        [Required]
        [MyDate(ErrorMessage = "Date of birth is invalid")]
        public DateTime DoB { get; set; }
        
        public List<Day> Days { get; set; }
    }
    public class MyDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)// Return a boolean value: true == IsValid, false != IsValid
        {
            DateTime d = Convert.ToDateTime(value);
            return d < DateTime.Now; //Dates Less than or equal to today are valid (true)
        }
    }

}