using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mystivate.Logic;

namespace Mystivate.Controllers
{
    [Authorize]
    public class TaskController : ControllerBase
    {
        private readonly ITaskManager _taskManager;

        public TaskController(ITaskManager taskManager)
        {
            _taskManager = taskManager;
        }

        [HttpPost]
        public int CheckDaily(int id)
        {
            return _taskManager.CheckDaily(id);
        }

        [HttpPost]
        public int CheckTodo(int id)
        {
            return _taskManager.CheckTodo(id);
        }

        [HttpPost]
        public int PositiveHabit(int id)
        {
            return _taskManager.PositiveHabit(id);
        }


        [HttpPost]
        public int NegativeHabit(int id)
        {
            return _taskManager.NegativeHabit(id);
        }

        [HttpPost]
        public int AddDaily(string name)
        {
            return _taskManager.AddDailyTask(name);
        }

        [HttpPost]
        public int AddHabit(string name)
        {
            return _taskManager.AddHabit(name);
        }

        [HttpPost]
        public int AddTodo(string name)
        {
            return _taskManager.AddTodo(name);
        }
    }
}