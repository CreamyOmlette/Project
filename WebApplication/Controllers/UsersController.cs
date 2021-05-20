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
using System.Linq;
using DatabaseAccess;
using Microsoft.EntityFrameworkCore;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IGenericRepository<User> _userRepo;

        private readonly ILogger<UsersController> _logger;

        private readonly IMapper _mapper;

        public UsersController(IGenericRepository<User> userRepo, ILogger<UsersController> logger, IMapper mapper)
        {
            _userRepo = userRepo;
            _logger = logger;
            _mapper = mapper;
        }


        [HttpPost]
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userRepo.GetById(id);
            var result = _mapper.Map<UserDto>(user);
            return Ok(user);
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userRepo.GetAll();
            var result = _mapper.Map<List<UserDto>>(users);
            return Ok(result);
        }
        
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateUser(int id, string password)
        {
            var user = await _userRepo.GetById(id);
            user.Password = password;
            await _userRepo.Update(user);
            await _userRepo.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
             await _userRepo.Delete(id);
             await _userRepo.SaveChangesAsync();
             return Ok();
        }
    }
}
