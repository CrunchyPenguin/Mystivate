using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mystivate.Data;
using Mystivate.Logic;
using Mystivate.Models;

namespace Mystivate.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITaskLogic _taskLogic;
        private readonly IUserService _userService;

        public HomeController(ITaskLogic taskLogic, IUserService userService)
        {
            _taskLogic = taskLogic;
            _userService = userService;
        }

        [Authorize]
        public IActionResult Index()
        {
            AllTasksViewModel tasks = _taskLogic.GetAllTasks();
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
