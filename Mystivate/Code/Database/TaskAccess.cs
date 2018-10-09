using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mystivate.Models;

namespace Mystivate.Code.Database
{
    public class TaskAccess : ITaskAccess
    {
        private readonly Mystivate_dbContext _db;
        public TaskAccess(Mystivate_dbContext db)
        {
            _db = db;
        }

        public void AddDailyTask(int userid, DailyTask task)
        {
            throw new NotImplementedException();
        }

        public void AddHabit(int userId, DailyTask habit)
        {
            throw new NotImplementedException();
        }

        public void AddTodo(int userId, DailyTask todo)
        {
            throw new NotImplementedException();
        }

        public List<DailyTask> GetDailyTasks(int userId)
        {
            return _db.DailyTasks.Where(t => t.UsersId == userId).ToList();
        }

        public List<Habit> GetHabits(int userId)
        {
            return _db.Habits.Where(t => t.UsersId == userId).ToList();
        }

        public List<ToDo> GetTodos(int userId)
        {
            return _db.ToDos.Where(t => t.UsersId == userId).ToList();
        }
    }
}
