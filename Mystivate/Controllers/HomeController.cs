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
        private readonly ITaskInfo _taskInfo;
        private readonly IUserInfo _userInfo;
        private readonly ICharacterInfo _characterInfo;

        public HomeController(ITaskInfo taskInfo, IUserInfo userInfo, ICharacterInfo characterInfo)
        {
            _taskInfo = taskInfo;
            _userInfo = userInfo;
            _characterInfo = characterInfo;
        }

        [Authorize]
        public IActionResult Index()
        {
            CharacterInfoViewModel model = new CharacterInfoViewModel()
            {
                DailyTasks = _taskInfo.GetDailyTaskList(),
                Habits = _taskInfo.GetHabitList(),
                ToDos = _taskInfo.GetTodoList(),
                Character = _characterInfo.GetCharacterInfo()
            };
            return View(model);
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
