using Mystivate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mystivate.Logic
{
    public interface ITaskManager
    {
        /// <summary>
        /// Returns new task id
        /// </summary>
        /// <param name="taskname"></param>
        /// <returns></returns>
        int AddDailyTask(string taskname);
        /// <summary>
        /// Returns new task id
        /// </summary>
        /// <param name="habitname"></param>
        /// <returns></returns>
        int AddHabit(string habitname);
        /// <summary>
        /// Returns new task id
        /// </summary>
        /// <param name="todoname"></param>
        /// <returns></returns>
        int AddTodo(string todoname);
        ITaskReturn CheckDaily(int dailyId);
        ITaskReturn PositiveHabit(int habitId);
        ITaskReturn NegativeHabit(int habitId);
        ITaskReturn CheckTodo(int todoId);
        void UncheckDailies();
        void ResetHabits();
        void DeleteTask(string type, int id);
    }

    public interface ITaskReturn
    {
        int XP { get; }
        int Damage { get; }
    }
}
