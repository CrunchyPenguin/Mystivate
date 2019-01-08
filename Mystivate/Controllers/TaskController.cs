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
        
        public ITaskReturn CheckDaily(int id)
        {
            return _taskManager.CheckDaily(id);
        }
        
        public ITaskReturn CheckTodo(int id)
        {
            return _taskManager.CheckTodo(id);
        }
        
        public ITaskReturn PositiveHabit(int id)
        {
            return _taskManager.PositiveHabit(id);
        }
        
        public ITaskReturn NegativeHabit(int id)
        {
            return _taskManager.NegativeHabit(id);
        }
        
        public int AddDaily(string name)
        {
            return _taskManager.AddDailyTask(name);
        }

        public int AddHabit(string name)
        {
            return _taskManager.AddHabit(name);
        }
        
        public int AddTodo(string name)
        {
            return _taskManager.AddTodo(name);
        }
        
        public void DeleteTask(int id, string type)
        {
            _taskManager.DeleteTask(type, id);
        }
    }
}