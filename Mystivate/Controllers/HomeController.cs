using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mystivate.Code.Database;
using Mystivate.Code.Logic;
using Mystivate.Models;

namespace Mystivate.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITaskAccess _taskAccess;
        private readonly IUserService _userService;

        public HomeController(ITaskAccess taskAccess, IUserService userService)
        {
            _taskAccess = taskAccess;
            _userService = userService;
        }

        [Authorize]
        public IActionResult Index()
        {
            AllTasksViewModel tasks = new AllTasksViewModel
            {
                DailyTasks = _taskAccess.GetDailyTasks(_userService.GetUserId()),
                Habits = _taskAccess.GetHabits(_userService.GetUserId()),
                ToDos = _taskAccess.GetTodos(_userService.GetUserId())
            };
            return View(tasks);
        }
        
        public IActionResult Info(bool register = false)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index");
            }
            ViewData["register"] = register;
            return View();
        }

        [Authorize]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        [Authorize]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
