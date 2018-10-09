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
        void AddDailyTask(int userid, DailyTask task);
        void AddHabit(int userId, DailyTask habit);
        void AddTodo(int userId, DailyTask todo);
    }
}
