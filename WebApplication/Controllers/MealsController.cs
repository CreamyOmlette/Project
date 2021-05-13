using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using AutoMapper;
using DatabaseAccess.Dtos;
using DatabaseAccess.Interfaces;
using Domain.Entities;
using DatabaseAccess.Interfaces;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("api/meals")]
    public class MealsController : ControllerBase
    {
        private readonly IGenericRepository<Meal> _repo;
        private readonly ILogger<MealsController> _logger;
        private readonly IMapper _mapper;

        public MealsController(IGenericRepository<Meal> mealRepo, ILogger<MealsController> logger, IMapper mapper)
        {
            _repo = mealRepo;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpPost("")]
        public async Task<IActionResult> CreateMeal(string name, string description, int calories, int proteins, int carbohydrates, int fats, string imgSrc)
        {
            var temp = new Meal
            {
                Name = name,
                Description = description,
                Calories = calories,
                Proteins = proteins,
                Carbohydrates = carbohydrates,
                Fats = fats,
                ImgSrc = imgSrc
            };
            await _repo.Create(temp);
            await _repo.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var meal = await _repo.GetById(id);
            var result = _mapper.Map<MealDto>(meal);
            return Ok(result);
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllUsers()
        {
            var meals = await _repo.GetAll();
            var result = _mapper.Map<List<MealDto>>(meals);
            return Ok(result);
        }
        
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateUser(int id, string description, string imgSrc = null)
        {
            var meal = await _repo.GetById(id);
            meal.Description = description;
            if (!string.IsNullOrEmpty(imgSrc))
            {
                meal.ImgSrc = imgSrc;
            }
            await _repo.Update(meal);
            await _repo.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _repo.Delete(id);
            await _repo.SaveChangesAsync();
            return Ok();
        }
    }
}