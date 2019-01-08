using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mystivate.Controllers;
using Mystivate.Data;
using Mystivate.Logic;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Threading.Tasks;

namespace Mystivate.IntegrationTests
{
    [TestClass]
    public class HomeControllerTests
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
        public async Task CheckHomeInfo()
        {
            string request = "/Home/Info";

            var response = await client.GetAsync(request);

            response.EnsureSuccessStatusCode();

            Assert.IsTrue(true);
        }
    }
}
