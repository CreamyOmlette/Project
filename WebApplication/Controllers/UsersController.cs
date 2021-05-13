using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DatabaseAccess;
using DatabaseAccess.Dtos;
using DatabaseAccess.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IGenericRepository<User> _userRepo;

        private readonly ILogger<UserController> _logger;

        private readonly IMapper _mapper;

        public UserController(IGenericRepository<User> userRepo, ILogger<UserController> logger, IMapper mapper)
        {
            _userRepo = userRepo;
            _logger = logger;
            _mapper = mapper;
        }


        [HttpPost("users")]

        public async Task<IActionResult> CreateUser(string username, string password, int height, int weight, string dob)
        {
            
            var temp = new User
            {
                Username = username,
                Password = password,
                Height = height,
                Weight = weight,
                DoB = DateTime.ParseExact(dob, "dd/MM/yyyy", CultureInfo.InvariantCulture)
            };
            await _userRepo.Create(temp);
            await _userRepo.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("users/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userRepo.GetById(id);
            var result = _mapper.Map<UserDto>(user);
            return Ok(result);
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userRepo.GetAll();
            var result = _mapper.Map<List<UserDto>>(users);
            return Ok(result);
        }
        
        [HttpPatch("users/{id}")]
        public async Task<IActionResult> UpdateUser(int id, string password)
        {
            var user = await _userRepo.GetById(id);
            user.Password = password;
            await _userRepo.Update(user);
            await _userRepo.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("users/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
             await _userRepo.Delete(id);
             await _userRepo.SaveChangesAsync();
             return Ok();
        }
        
        
    }
}
