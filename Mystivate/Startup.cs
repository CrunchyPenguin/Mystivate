using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Mystivate.Data;
using Mystivate.Logic;
using Mystivate.Models;

namespace Mystivate
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
            services.AddHttpContextAccessor();

            services.AddTransient<ISignInService, SignInService>();
            services.AddTransient<IRegisterService, SignInService>();
            services.AddTransient<IUserInfo, UserService>();

            services.AddTransient<ICharacterInfo, CharacterLogic>();
            services.AddTransient<ICharacterManager, CharacterLogic>();
            services.AddTransient<ITaskManager, TaskLogic>();
            services.AddTransient<ITaskInfo, TaskLogic>();
            services.AddTransient<IQuestLogic, QuestLogic>();
            services.AddTransient<IInventoryLogic, InventoryLogic>();

            services.AddTransient<IAccountAccess, AccountAccess>();
            services.AddTransient<ITaskAccess, TaskAccess>();
            services.AddTransient<ICharacterAccess, CharacterAccess>();
            services.AddTransient<IQuestAccess, QuestAccess>();
            services.AddTransient<IInventoryAccess, InventoryAccess>();

            services.AddDbContext<Mystivate_dbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
