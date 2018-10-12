using Mystivate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mystivate.Code.Database
{
    public interface ITaskAccess
    {
        List<DailyTask> GetDailyTasks(int userId);
        List<Habit> GetHabits(int userId);
        List<ToDo> GetTodos(int userId);
        int AddDailyTask(int userId, string task);
        int AddHabit(int userId, string habit);
        int AddTodo(int userId, string todo);
        void CheckDaily(int dailyId);
        void PositiveHabit(int habitId);
        void NegativeHabit(int negativeId);
        void CheckTodo(int todoId);
    }
}
