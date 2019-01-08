using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mystivate.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;

namespace Mystivate.IntegrationTests
{
    [TestClass]
    public class AccountControllerTests
    {
        private HttpClient client;

        [TestInitialize]
        public void Initialize()
        {
            var host = new WebHostBuilder()
               .UseEnvironment("Development")
               .UseContentRoot(Directory.GetCurrentDirectory())
               .UseStartup<TestStartup>();

            TestServer server = new TestServer(host);
            
            client = server.CreateClient();
        }

        [TestMethod]
        public async Task RegisterLoginUser()
        {
            await RegisterUser();

            await LoginUser();
        }

        [TestMethod]
        public async Task LoginLogoutUser()
        {
            await RegisterUser();

            await LoginUser();

            await LogoutUser();
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

        public async Task LogoutUser()
        {
            var stringContent = new StringContent("", Encoding.UTF8, "application/x-www-form-urlencoded");

            string request = "/Account/Logout";

            var response = await client.PostAsync(request, stringContent);

            Assert.AreEqual(HttpStatusCode.Redirect, response.StatusCode);
            Assert.AreEqual("/Home/Info", response.Headers.Location.OriginalString);
        }
    }
}
