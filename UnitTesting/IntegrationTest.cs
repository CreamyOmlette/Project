using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DatabaseAccess.Dtos;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using WebApplication;

namespace UnitTesting
{
    public static class ContentHelper
    {
        public static StringContent GetStringContent(object obj)
        {
            return new StringContent(JsonConvert.SerializeObject(obj), Encoding.Default, "application/json");
        }
    }
    [TestClass]
    public class IntegrationTest
    {
        private readonly HttpClient _client;
        
        public IntegrationTest()
        {
            
            var server = new TestServer(new WebHostBuilder()
                .UseKestrel()
                .ConfigureLogging(builder => builder
                    .AddConsole()
                    .AddFilter(level => level >= LogLevel.Trace))
                .UseEnvironment("Development")
                .UseConfiguration(new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")
                    .Build()
                )
                .UseStartup<Startup>());
            _client = server.CreateClient();
        }

        [TestMethod]
        public async Task ShouldAccessUserById()
        {
            // Arrange
            var request = "/api/EfCore/users/1";
            
            // Act
            var response = (await _client.GetAsync(request));
            
            // Assert
            response.EnsureSuccessStatusCode();
            var jsonFromPostResponse = await response.Content.ReadAsStringAsync();
            var obj = JsonConvert.DeserializeObject<UserDto>(jsonFromPostResponse);
            Assert.IsTrue(obj.Username.Equals("CreamyOmlette"));
        }
        
        [TestMethod]
        public async Task ShouldAccessUserList()
        {
            // Arrange
            var request = "/api/EfCore/users";
            
            // Act
            var response = (await _client.GetAsync(request));
            
            // Assert
            response.EnsureSuccessStatusCode();
            var jsonFromPostResponse = await response.Content.ReadAsStringAsync();
            var obj = JsonConvert.DeserializeObject<List<UserDto>>(jsonFromPostResponse);
            Assert.IsTrue(obj.Count > 1);
        }
        
        
        
        
    }
}