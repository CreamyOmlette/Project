using NUnit.Framework;
using DatabaseAccess;
using DatabaseAccess.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace UnitTesting
{
    [TestFixture]
    public class ContextTest
    {
        private readonly IGenericRepository<User> _users;
        
        [SetUp]
        public void Setup()
        {
            var mock = new Mock<DbContext>();
            mock.Setup();
            var controller = new HomeController(mock.Object);
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}