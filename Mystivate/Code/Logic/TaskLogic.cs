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
            if (taskname != null && taskname != "")
            {
                return _taskAccess.AddDailyTask(_userService.GetUserId(), taskname);
            }
            else
            {
                return -1;
            }
        }

        public int AddHabit(string habitname)
        {
            if (habitname != null && habitname != "")
            {
                return _taskAccess.AddHabit(_userService.GetUserId(), habitname);
            }
            else
            {
                return -1;
            }
        }

        public int AddTodo(string todoname)
        {
            if (todoname != null && todoname != "")
            {
                return _taskAccess.AddTodo(_userService.GetUserId(), todoname);
            }
            else
            {
                return -1;
            }
        }

        public int CheckDaily(int dailyId)
        {
            _taskAccess.CheckDaily(dailyId);
            return 40;
        }

        public int CheckTodo(int todoId)
        {
            _taskAccess.CheckTodo(todoId);
            return 50;
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

        public int NegativeHabit(int habitId)
        {
            _taskAccess.NegativeHabit(habitId);
            return -10;
        }

        public int PositiveHabit(int habitId)
        {
            _taskAccess.PositiveHabit(habitId);
            return 10;
        }
    }
}
