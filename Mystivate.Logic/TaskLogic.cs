using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mystivate.Data;
using Mystivate.Models;

namespace Mystivate.Logic
{
    public class TaskLogic : ITaskManager, ITaskInfo
    {
        private readonly ITaskAccess _taskAccess;
        private readonly IUserInfo _userInfo;
        private readonly ICharacterManager _characterManager;

        public TaskLogic(ITaskAccess taskAccess, IUserInfo userInfo, ICharacterManager characterManager)
        {
            _taskAccess = taskAccess;
            _userInfo = userInfo;
            _characterManager = characterManager;
        }


        public int AddDailyTask(string taskname)
        {
            if (taskname != null && taskname != "")
            {
                return _taskAccess.AddDailyTask(_userInfo.GetUserId(), taskname);
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
                return _taskAccess.AddHabit(_userInfo.GetUserId(), habitname);
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
                return _taskAccess.AddTodo(_userInfo.GetUserId(), todoname);
            }
            else
            {
                return -1;
            }
        }

        public int CheckDaily(int dailyId)
        {
            _taskAccess.CheckDaily(dailyId);
            int xp = 40;
            _characterManager.AddExperience(xp);
            return xp;

        }

        public int CheckTodo(int todoId)
        {
            _taskAccess.CheckTodo(todoId);
            int xp = 60;
            _characterManager.AddExperience(xp);
            return xp;
        }

        //public CharacterInfoViewModel GetAllTasks()
        //{
        //    CharacterInfoViewModel tasks = new CharacterInfoViewModel
        //    {
        //        DailyTasks = _taskAccess.GetDailyTasks(_userInfo.GetUserId()),
        //        Habits = _taskAccess.GetHabits(_userInfo.GetUserId()),
        //        ToDos = _taskAccess.GetTodos(_userInfo.GetUserId())
        //    };
        //    return tasks;
        //}

        public List<DailyTask> GetDailyTaskList()
        {
            return _taskAccess.GetDailyTasks(_userInfo.GetUserId());
        }

        public List<Habit> GetHabitList()
        {
            return _taskAccess.GetHabits(_userInfo.GetUserId());
        }

        public List<ToDo> GetTodoList()
        {
            return _taskAccess.GetTodos(_userInfo.GetUserId());
        }

        public int NegativeHabit(int habitId)
        {
            _taskAccess.NegativeHabit(habitId);
            int xp = -10;
            _characterManager.AddExperience(xp);
            _characterManager.AddHealth(-4);
            return xp;
        }

        public int PositiveHabit(int habitId)
        {
            _taskAccess.PositiveHabit(habitId);
            int xp = 10;
            _characterManager.AddExperience(xp);
            return xp;
        }

        public void UncheckDailies()
        {
            _taskAccess.UncheckDailyTasks(_userInfo.GetUserId());
        }
    }
}
