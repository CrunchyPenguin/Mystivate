using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mystivate.Models;

namespace Mystivate.Data
{
    public class TaskAccess : ITaskAccess
    {
        private readonly Mystivate_dbContext _dbContext;
        public TaskAccess(Mystivate_dbContext db)
        {
            _dbContext = db;
        }

        public int AddDailyTask(int userId, string task)
        {
            _dbContext.DailyTasks.Add(new DailyTask
            {
                Name = task,
                UserId = userId
            });
            _dbContext.SaveChanges();
            return _dbContext.DailyTasks.Where(d => d.UserId == userId).Last().Id;
        }

        public int AddHabit(int userId, string habit)
        {
            _dbContext.Habits.Add(new Habit
            {
                Name = habit,
                UserId = userId
            });
            _dbContext.SaveChanges();
            return _dbContext.Habits.Where(d => d.UserId == userId).Last().Id;
        }

        public int AddTodo(int userId, string todo)
        {
            _dbContext.ToDos.Add(new ToDo
            {
                Name = todo,
                UserId = userId
            });
            _dbContext.SaveChanges();
            return _dbContext.ToDos.Where(d => d.UserId == userId).Last().Id;
        }

        public void CheckDaily(int dailyId)
        {
            if (_dbContext.DailyTasks.Any(d => d.Id == dailyId))
            {
                _dbContext.DailyTasks.Where(d => d.Id == dailyId).First().Done = true;
                _dbContext.SaveChanges();
            }
        }

        public void CheckTodo(int todoId)
        {
            if (_dbContext.ToDos.Any(t => t.Id == todoId))
            {
                _dbContext.ToDos.Remove(_dbContext.ToDos.Where(t => t.Id == todoId).First());
                _dbContext.SaveChanges();
            }
        }

        public List<DailyTask> GetDailyTasks(int userId)
        {
            return _dbContext.DailyTasks.Where(t => t.UserId == userId).ToList();
        }

        public List<Habit> GetHabits(int userId)
        {
            return _dbContext.Habits.Where(t => t.UserId == userId).ToList();
        }

        public List<ToDo> GetTodos(int userId)
        {
            return _dbContext.ToDos.Where(t => t.UserId == userId).ToList();
        }

        public void PositiveHabit(int habitId)
        {
            if (_dbContext.Habits.Any(h => h.Id == habitId))
            {
                _dbContext.Habits.Where(h => h.Id == habitId).First().Positive++;
                _dbContext.SaveChanges();
            }
        }

        public void NegativeHabit(int habitId)
        {
            if (_dbContext.Habits.Any(h => h.Id == habitId))
            {
                _dbContext.Habits.Where(h => h.Id == habitId).First().Negative++;
                _dbContext.SaveChanges();
            }
        }

        public void UncheckDailyTasks(int userId)
        {
            foreach(DailyTask dailyTask in _dbContext.DailyTasks.Where(d => d.UserId == userId))
            {
                dailyTask.Done = false;
            }
        }
    }
}
