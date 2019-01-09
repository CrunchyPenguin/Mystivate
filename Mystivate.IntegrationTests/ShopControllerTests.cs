using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mystivate.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Mystivate.IntegrationTests
{
    [TestClass]
    public class ShopControllerTests
    {
        private HttpClient client;
        private Mystivate_dbContext dbContext;

        [TestInitialize]
        public void Initialize()
        {
            var host = new WebHostBuilder()
               .UseEnvironment("Development")
               .UseContentRoot(Directory.GetCurrentDirectory())
               .UseStartup<TestStartup>();

            TestServer server = new TestServer(host);

            dbContext = (Mystivate_dbContext)server.Host.Services.GetService(typeof(Mystivate_dbContext));

            client = server.CreateClient();
        }

        [TestMethod]
        public async Task BuyItem()
        {
            await RegisterUser();

            dbContext.Characters.Add(new Character
            {
                Name = "Test",
                Coins = 10000,
                CurrentHealth = 100,
                MaxHealth = 100,
                Experience = 0,
                UserId = 1
            });

            dbContext.WeaponTypes.Add(new WeaponType
            {
                Name = "Sword"
            });

            dbContext.Equipment.Add(new Weapon
            {
                Damage = 1,
                Image = "weapon",
                Name = "weapon",
                Price = 10,
                WeaponTypeId = 1
            });

            dbContext.SaveChanges();

            await LoginUser();
            
            string request = "/Inventory/Index";

            var response = await client.GetAsync(request);

            int i = 0;
        }

        public async Task RegisterUser()
        {
            var stringContent = new StringContent("Username=Test&Email=test@test.nl&Password=test123&ConfirmPassword=test123", Encoding.UTF8, "application/x-www-form-urlencoded");

            string request = "/Account/Register";

            var response = await client.PostAsync(request, stringContent);

            Assert.AreEqual(HttpStatusCode.Redirect, response.StatusCode);
            Assert.AreEqual("/Home/Info", response.Headers.Location.OriginalString);
        }

        public async Task LoginUser()
        {
            var stringContent = new StringContent("Email=test@test.nl&Password=test123", Encoding.UTF8, "application/x-www-form-urlencoded");

            string request = "/Account/Login";

            var response = await client.PostAsync(request, stringContent);

            Assert.AreEqual(HttpStatusCode.Redirect, response.StatusCode);
            Assert.AreEqual("/", response.Headers.Location.OriginalString);
        }
    }
}
