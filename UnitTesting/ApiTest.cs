 using System;
 using System.Collections.Generic;
 using System.Linq;
 using System.Net;
 using System.Threading.Tasks;
 using AutoMapper;
 using DatabaseAccess.Interfaces;
 using Microsoft.VisualStudio.TestTools.UnitTesting;
 using Moq;
 using Domain.Entities;
 using Microsoft.AspNetCore.Mvc;
 using Microsoft.Extensions.Logging;
 using WebApplication.Controllers;

 namespace UnitTesting
 {
     [TestClass]
     public class ApiTest
     {
         private readonly Mock<IGenericRepository<User>> _usersRepo = new Mock<IGenericRepository<User>>();
         private readonly Mock<IMapper> _mapper = new Mock<IMapper>();
         private readonly Mock<ILogger<UsersController>> _logger = new Mock<ILogger<UsersController>>(); 
         private readonly UsersController _controller;
         
         public ApiTest()
         {
             _controller = new UsersController(_usersRepo.Object, _logger.Object, _mapper.Object);
         }

         [TestMethod]
         public async Task ShouldGetAllRepoContent()
         {
             // Arrange
             _usersRepo.Setup(x => x.GetAll()).ReturnsAsync(GetUserList());
             
             // Act
             var userList = await _usersRepo.Object.GetAll();
             var len = userList.ToList().Count;
             // Assert
             Assert.AreEqual(len, 2); 
         }
         
         [TestMethod]
         public async Task ShouldGetElementById()
         {
             // Arrange
             _usersRepo.Setup(x => x.GetById(It.IsAny<int>())).ReturnsAsync(GetUserList()[0]);
             
             // Act
             var user = (_controller.GetById(1)).Result;
             var okResult = user as OkObjectResult;
             // Assert
             Assert.IsNotNull(okResult);
             Assert.AreEqual(200,okResult.StatusCode);
         }
         
         public List<User> GetUserList()
         {
             return new List<User>
             {
                 new User
                 {
                     Id = 1,
                     Username = "CreamyOmlette",
                     Password = "12345",
                     DoB = new DateTime(2000,1,1),
                     Height = 186,
                     Weight = 84
                 },
                 new User
                 {
                     Id = 2,
                     Username = "Test",
                     Password = "1*5&3rJ",
                     DoB = new DateTime(1999, 6,18),
                     Height = 182,
                     Weight = 76
                 }
             };
         }
     }
}