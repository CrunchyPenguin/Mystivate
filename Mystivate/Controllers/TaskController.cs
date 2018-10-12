using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mystivate.Code.Logic;

namespace Mystivate.Controllers
{
    public class TaskController : ControllerBase
    {
        private readonly ITaskLogic _taskLogic;

        public TaskController(ITaskLogic taskLogic)
        {
            _taskLogic = taskLogic;
        }

        [HttpPost]
        public void CheckDaily(int id)
        {
            _taskLogic.CheckDaily(id);
        }

        [HttpPost]
        public void CheckTodo(int id)
        {
            _taskLogic.CheckTodo(id);
        }

        [HttpPost]
        public int AddDaily(string name)
        {
            return _taskLogic.AddDailyTask(name);
        }

        [HttpPost]
        public int AddHabit(string name)
        {
            return _taskLogic.AddHabit(name);
        }

        [HttpPost]
        public int AddTodo(string name)
        {
            return _taskLogic.AddTodo(name);
        }
    }
}