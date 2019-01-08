using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mystivate.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mystivate.IntegrationTests
{
    public class TestStartup : Startup
    {
        public TestStartup(IConfiguration configuration) : base(configuration)
        {
        }

        public override void ConfigureDatabase(IServiceCollection services)
        {
            services.AddDbContext<Mystivate_dbContext>(options =>
                options.UseInMemoryDatabase("Test_db"));

        }
    }
}
