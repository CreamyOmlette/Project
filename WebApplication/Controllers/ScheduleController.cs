using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DatabaseAccess.Dtos;
using DatabaseAccess.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("api/schedules")]
    public class SchedulesController : ControllerBase
    {
        private readonly IGenericRepository<User> _userRepo;
        private readonly IGenericRepository<Meal> _mealRepo;
        private readonly IGenericRepository<Day> _dayRepo;
        private readonly ILogger<SchedulesController> _logger;
        private readonly IMapper _mapper;

        public SchedulesController(IGenericRepository<User> userRepo, IGenericRepository<Meal> mealRepo, IGenericRepository<Day> dayRepo, ILogger<SchedulesController> logger, IMapper mapper)
        {
            _userRepo = userRepo;
            _mealRepo = mealRepo;
            _dayRepo = dayRepo;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("meal/{userId}")]
        public async Task<IActionResult> GetScheduledMeals(int userId)
        {
            var days = (await _dayRepo.GetAll()).Where(obj => obj.UserId == userId);

            return Ok(days);
        }
        [HttpPost("meal/{userId}")]
        public async Task<IActionResult> CreateScheduledMeal(int userId, int mealId, string dateStr)
        {
            var date = DateTime.ParseExact(dateStr, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            var user = await _userRepo.GetById(userId);
            if (user != null)
            {
                if (user.Days == null)
                {
                    user.Days = new List<Day>
                    {
                        new Day
                        {
                            Date = date,
                            Meals = new List<Meal> {await _mealRepo.GetById(mealId)}
                        }
                    };
                }
                else
                {
                    var day = user.Days.Find(obj => obj.Date.Equals(date.Date));
                    day?.Meals.Add(await _mealRepo.GetById(mealId));
                }
                await _userRepo.SaveChangesAsync();
                return Ok();
            }
            return NotFound();
        }

    }

            
}

