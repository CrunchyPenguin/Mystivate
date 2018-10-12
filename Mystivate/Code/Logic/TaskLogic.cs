using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mystivate.Code.Database;
using Mystivate.Models;

namespace Mystivate.Code.Logic
{
    public class TaskLogic : ITaskLogic
    {
        private readonly ITaskAccess _taskAccess;
        private readonly IUserService _userService;

        public TaskLogic(ITaskAccess taskAccess, IUserService userService)
        {
            _taskAccess = taskAccess;
            _userService = userService;
        }


        public int AddDailyTask(string taskname)
        {
            return _taskAccess.AddDailyTask(_userService.GetUserId(), taskname);
        }

        public int AddHabit(string habitname)
        {
            return _taskAccess.AddHabit(_userService.GetUserId(), habitname);
        }

        public int AddTodo(string todoname)
        {
            return _taskAccess.AddTodo(_userService.GetUserId(), todoname);
        }

        public void CheckDaily(int dailyId)
        {
            _taskAccess.CheckDaily(dailyId);
        }

        public void CheckTodo(int todoId)
        {
            _taskAccess.CheckTodo(todoId);
        }

        public AllTasksViewModel GetAllTasks()
        {
            AllTasksViewModel tasks = new AllTasksViewModel
            {
                DailyTasks = _taskAccess.GetDailyTasks(_userService.GetUserId()),
                Habits = _taskAccess.GetHabits(_userService.GetUserId()),
                ToDos = _taskAccess.GetTodos(_userService.GetUserId())
            };
            return tasks;
        }

        public List<DailyTask> GetDailyTaskList()
        {
            return _taskAccess.GetDailyTasks(_userService.GetUserId());
        }

        public List<Habit> GetHabitList()
        {
            throw new NotImplementedException();
        }

        public List<ToDo> GetTodoList()
        {
            throw new NotImplementedException();
        }

        public void NegativeHabit(int negativeId)
        {
            throw new NotImplementedException();
        }

        public void PositiveHabit(int habitId)
        {
            throw new NotImplementedException();
        }
    }
}
