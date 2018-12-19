using Mystivate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            if (_dbContext.Users.Any(u => u.Id == userId))
            {
                _dbContext.DailyTasks.Add(new DailyTask
                {
                    Name = task,
                    UserId = userId
                });
                _dbContext.SaveChanges();
                return _dbContext.DailyTasks.Where(d => d.UserId == userId).Last().Id;
            }
            else
            {
                return -1;
            }
        }

        public int AddHabit(int userId, string habit)
        {
            if (_dbContext.Users.Any(u => u.Id == userId))
            {
                _dbContext.Habits.Add(new Habit
                {
                    Name = habit,
                    UserId = userId,
                    Positive = 0,
                    Negative = 0
                });
                _dbContext.SaveChanges();
                return _dbContext.Habits.Where(d => d.UserId == userId).Last().Id;
            }
            else
            {
                return -1;
            }
        }

        public int AddTodo(int userId, string todo)
        {
            if (_dbContext.Users.Any(u => u.Id == userId))
            {
                _dbContext.ToDos.Add(new ToDo
                {
                    Name = todo,
                    UserId = userId
                });
                _dbContext.SaveChanges();
                return _dbContext.ToDos.Where(d => d.UserId == userId).Last().Id;
            }
            else
            {
                return -1;
            }
        }

        public void CheckDaily(int dailyId)
        {
            if (_dbContext.DailyTasks.Any(d => d.Id == dailyId))
            {
                _dbContext.DailyTasks.SingleOrDefault(d => d.Id == dailyId).Done = true;
                _dbContext.SaveChanges();
            }
        }

        public void CheckTodo(int todoId)
        {
            if (_dbContext.ToDos.Any(t => t.Id == todoId))
            {
                _dbContext.ToDos.Remove(_dbContext.ToDos.SingleOrDefault(t => t.Id == todoId));
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
                _dbContext.Habits.SingleOrDefault(h => h.Id == habitId).Positive++;
                _dbContext.SaveChanges();
            }
        }

        public void NegativeHabit(int habitId)
        {
            if (_dbContext.Habits.Any(h => h.Id == habitId))
            {
                _dbContext.Habits.SingleOrDefault(h => h.Id == habitId).Negative++;
                _dbContext.SaveChanges();
            }
        }

        public void UncheckDailyTasks()
        {
            List<DailyTask> allDailyTasks = _dbContext.DailyTasks.ToList();
            foreach (DailyTask dailyTask in allDailyTasks)
            {
                dailyTask.DoneYesterday = dailyTask.Done.Value;
                dailyTask.Done = false;
            }
            _dbContext.SaveChanges();
        }

        public void UncheckDailyTasks(int userId)
        {
            foreach (DailyTask dailyTask in _dbContext.DailyTasks.Where(d => d.UserId == userId))
            {
                dailyTask.DoneYesterday = dailyTask.Done.Value;
                dailyTask.Done = false;
            }
            _dbContext.SaveChanges();
        }

        public void ResetHabits()
        {
            List<Habit> allHabits = _dbContext.Habits.ToList();
            foreach (Habit habit in allHabits)
            {
                habit.Positive = 0;
                habit.Negative = 0;
            }
            _dbContext.SaveChanges();
        }

        public void ResetHabits(int userId)
        {
            foreach (Habit habit in _dbContext.Habits.Where(h => h.UserId == userId))
            {
                habit.Positive = 0;
                habit.Negative = 0;
            }
            _dbContext.SaveChanges();
        }

        public void DeleteDaily(int dailyId, int userId)
        {
            if (_dbContext.DailyTasks.Any(d => d.UserId == userId && d.Id == dailyId))
            {
                _dbContext.DailyTasks.Remove(_dbContext.DailyTasks.SingleOrDefault(d => d.Id == dailyId));
                _dbContext.SaveChanges();
            }
        }

        public void DeleteHabit(int habitId, int userId)
        {
            if (_dbContext.Habits.Any(h => h.UserId == userId && h.Id == habitId))
            {
                _dbContext.Habits.Remove(_dbContext.Habits.SingleOrDefault(h => h.Id == habitId));
                _dbContext.SaveChanges();
            }
        }

        public void DeleteTodo(int todoId, int userId)
        {
            if (_dbContext.ToDos.Any(t => t.UserId == userId && t.Id == todoId))
            {
                _dbContext.ToDos.Remove(_dbContext.ToDos.SingleOrDefault(t => t.Id == todoId));
                _dbContext.SaveChanges();
            }
        }
    }
}
