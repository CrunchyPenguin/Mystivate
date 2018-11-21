using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mystivate.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public ITaskReturn CheckDaily(int id)
        {
            return _taskManager.CheckDaily(id);
        }

        [HttpPost]
        public ITaskReturn CheckTodo(int id)
        {
            return _taskManager.CheckTodo(id);
        }

        [HttpPost]
        public ITaskReturn PositiveHabit(int id)
        {
            return _taskManager.PositiveHabit(id);
        }


        [HttpPost]
        public ITaskReturn NegativeHabit(int id)
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

        [HttpPost]
        public void DeleteTask(int id, string type)
        {
            _taskManager.DeleteTask(type, id);
        }
    }
}