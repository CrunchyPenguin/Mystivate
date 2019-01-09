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
        private readonly ITaskManager _taskManager;
        private readonly IUserInfo _userInfo;
        private readonly ICharacterInfo _characterInfo;
        private readonly IQuestLogic _questLogic;

        public HomeController(ITaskInfo taskInfo, IUserInfo userInfo, ICharacterInfo characterInfo, ITaskManager taskManager, IQuestLogic questLogic)
        {
            _taskInfo = taskInfo;
            _taskManager = taskManager;
            _userInfo = userInfo;
            _characterInfo = characterInfo;
            _questLogic = questLogic;
        }

        [Authorize]
        public IActionResult Index()
        {
            CharacterInfoViewModel model = new CharacterInfoViewModel()
            {
                DailyTasks = _taskInfo.GetDailyTaskList(),
                Habits = _taskInfo.GetHabitList(),
                ToDos = _taskInfo.GetTodoList(),
                Character = _characterInfo.GetCharacterInfo(true)
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
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
