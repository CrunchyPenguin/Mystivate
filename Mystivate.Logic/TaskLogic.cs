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
        private readonly IQuestLogic _questLogic;

        public TaskLogic(ITaskAccess taskAccess, IUserInfo userInfo, ICharacterManager characterManager, IQuestLogic questLogic)
        {
            _taskAccess = taskAccess;
            _userInfo = userInfo;
            _characterManager = characterManager;
            _questLogic = questLogic;
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

        public ITaskReturn CheckDaily(int dailyId)
        {
            _taskAccess.CheckDaily(dailyId);
            int xp = 40;
            _characterManager.AddExperience(xp);
            int damage = 0;
            if (_questLogic.GetCurrentQuest() != null)
            {
                damage = 60;
                _questLogic.AddDamage(damage);
            }
            return new TaskReturn(xp, damage);

        }

        public ITaskReturn CheckTodo(int todoId)
        {
            _taskAccess.CheckTodo(todoId);
            int xp = 60;
            _characterManager.AddExperience(xp);
            int damage = 0;
            if (_questLogic.GetCurrentQuest() != null)
            {
                damage = 100;
                _questLogic.AddDamage(damage);
            }
            return new TaskReturn(xp, damage);
        }

        public void DeleteTask(string type, int id)
        {
            if (type == "daily")
                _taskAccess.DeleteDaily(id, _userInfo.GetUserId());
            if (type == "habit")
                _taskAccess.DeleteHabit(id, _userInfo.GetUserId());
            if (type == "todo")
                _taskAccess.DeleteTodo(id, _userInfo.GetUserId());
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

        public ITaskReturn NegativeHabit(int habitId)
        {
            _taskAccess.NegativeHabit(habitId);
            int xp = -10;
            _characterManager.AddExperience(xp);
            _characterManager.AddHealth(-4);
            return new TaskReturn(xp, 0);
        }

        public ITaskReturn PositiveHabit(int habitId)
        {
            _taskAccess.PositiveHabit(habitId);
            int xp = 10;
            _characterManager.AddExperience(xp);
            int damage = 0;
            if (_questLogic.GetCurrentQuest() != null)
            {
                damage = 20;
                _questLogic.AddDamage(damage);
            }
            return new TaskReturn(xp, damage);
        }

        public void ResetHabits()
        {
            _taskAccess.ResetHabits(_userInfo.GetUserId());
        }

        public void UncheckDailies()
        {
            _taskAccess.UncheckDailyTasks(_userInfo.GetUserId());
        }
    }

    public class TaskReturn : ITaskReturn
    {
        public TaskReturn(int xp, int damage)
        {
            XP = xp;
            Damage = damage;
        }

        public int XP { get; private set; }
        public int Damage { get; private set; }
    }
}
