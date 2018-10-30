using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mystivate.Logic;

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
        public int CheckDaily(int id)
        {
            return _taskLogic.CheckDaily(id);
        }

        [HttpPost]
        public int CheckTodo(int id)
        {
            return _taskLogic.CheckTodo(id);
        }

        [HttpPost]
        public int PositiveHabit(int id)
        {
            return _taskLogic.PositiveHabit(id);
        }


        [HttpPost]
        public int NegativeHabit(int id)
        {
            return _taskLogic.NegativeHabit(id);
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