using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseAccess;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EfCoreController : ControllerBase
    {
        GenericRepository<User> repo = new GenericRepository<User>(new ApplicationContext());

        private readonly ILogger<EfCoreController> _logger;

        public EfCoreController(ILogger<EfCoreController> logger)
        {
            _logger = logger;
        }


        [HttpPost("CreateUser")]
        public async void CreateUser(string username, string password)
        {
            
            var temp = new User
            {
                Username = username,
                Password = password
            };
            await repo.Create(temp);
        }

        [HttpGet("GetById")]
        public async Task<User> GetById(int id)
        {
            
            return await repo.GetById(id);
        }

        [HttpPost("UpdateUser")]
        public async void UpdateUser(int id, string password)
        {
            var user = await repo.GetById(id);
            user.Password = password;
            await repo.Update(user);
        }

        [HttpPost("DeleteUser")]
        public async void Delete(int id)
        {
             await repo.Delete(id);
        }

        [HttpPost("Concurrency")]
        public async void Concurrency()
        {
            try
            {
                var anotherRepo = new GenericRepository<User>(new ApplicationContext());
                var user = await repo.GetById(5);
                var sameUser = await repo.GetById(5);
                user.Password = "1234";
                user.Password = "12345";
                await repo.Update(user);
                await anotherRepo.Update(user);
            } catch(DbUpdateConcurrencyException e)
            {
               
            }

            
        }
    }
}
