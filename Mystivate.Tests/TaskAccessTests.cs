using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mystivate.Data;
using Mystivate.Models;
using System.Linq;

namespace Mystivate.Tests
{
    [TestClass]
    public class TaskAccessTests
    {
        [TestMethod]
        public void AddDailyTask_NormalName_True()
        {
            var options = new DbContextOptionsBuilder<Mystivate_dbContext>()
                .UseInMemoryDatabase(databaseName: "AddDailyTask_NormalName_True")
                .Options;

            using (var context = new Mystivate_dbContext(options))
            {
                IAccountAccess accountAccess = new AccountAccess(context);
                string email = "test@test.nl";
                UserTestsMethods.RegisterUser(accountAccess, "test", email, "test123");
                int taskId = AddDailyTask(new TaskAccess(context), UserTestsMethods.GetUserId(accountAccess, email), "Normal task");
                Assert.IsTrue(DailyTaskExists(context, taskId));
            }
        }

        [TestMethod]
        public void AddDailyTask_NonExistantUser_False()
        {
            var options = new DbContextOptionsBuilder<Mystivate_dbContext>()
                .UseInMemoryDatabase(databaseName: "AddDailyTask_NonExistantUser_True")
                .Options;

            using (var context = new Mystivate_dbContext(options))
            {
                int taskId = AddDailyTask(new TaskAccess(context), 0, "Normal task");
                Assert.IsFalse(DailyTaskExists(context, taskId));
            }
        }

        [TestMethod]
        public void AddHabit_NormalName_True()
        {
            var options = new DbContextOptionsBuilder<Mystivate_dbContext>()
                .UseInMemoryDatabase(databaseName: "AddHabit_NormalName_True")
                .Options;

            using (var context = new Mystivate_dbContext(options))
            {
                IAccountAccess accountAccess = new AccountAccess(context);
                string email = "test@test.nl";
                UserTestsMethods.RegisterUser(accountAccess, "test", email, "test123");
                int taskId = AddHabit(new TaskAccess(context), UserTestsMethods.GetUserId(accountAccess, email), "Normal task");
                Assert.IsTrue(HabitExists(context, taskId));
            }
        }

        [TestMethod]
        public void AddTodo_NormalName_True()
        {
            var options = new DbContextOptionsBuilder<Mystivate_dbContext>()
                .UseInMemoryDatabase(databaseName: "AddTodo_NormalName_True")
                .Options;

            using (var context = new Mystivate_dbContext(options))
            {
                IAccountAccess accountAccess = new AccountAccess(context);
                string email = "test@test.nl";
                UserTestsMethods.RegisterUser(accountAccess, "test", email, "test123");
                int taskId = AddTodo(new TaskAccess(context), UserTestsMethods.GetUserId(accountAccess, email), "Normal task");
                Assert.IsTrue(ToDoExists(context, taskId));
            }
        }

        [TestMethod]
        public void CheckTodo_NormalName_False()
        {
            var options = new DbContextOptionsBuilder<Mystivate_dbContext>()
                .UseInMemoryDatabase(databaseName: "CheckTodo_NormalName_False")
                .Options;

            using (var context = new Mystivate_dbContext(options))
            {
                IAccountAccess accountAccess = new AccountAccess(context);
                string email = "test@test.nl";
                UserTestsMethods.RegisterUser(accountAccess, "test", email, "test123");
                ITaskAccess taskAccess = new TaskAccess(context);
                int taskId = AddTodo(taskAccess, UserTestsMethods.GetUserId(accountAccess, email), "Normal task");
                taskAccess.CheckTodo(taskId);
                Assert.IsFalse(ToDoExists(context, taskId));
            }
        }

        private int AddDailyTask(ITaskAccess taskAccess, int userId, string taskName)
        {
            return taskAccess.AddDailyTask(userId, taskName);
        }

        private bool DailyTaskExists(Mystivate_dbContext dbContext, int taskId)
        {
            return dbContext.DailyTasks.SingleOrDefault(t => t.Id == taskId) != null;
        }

        private int AddHabit(ITaskAccess taskAccess, int userId, string taskName)
        {
            return taskAccess.AddHabit(userId, taskName);
        }

        private bool HabitExists(Mystivate_dbContext dbContext, int taskId)
        {
            return dbContext.Habits.SingleOrDefault(t => t.Id == taskId) != null;
        }

        private int AddTodo(ITaskAccess taskAccess, int userId, string taskName)
        {
            return taskAccess.AddTodo(userId, taskName);
        }

        private bool ToDoExists(Mystivate_dbContext dbContext, int taskId)
        {
            return dbContext.ToDos.SingleOrDefault(t => t.Id == taskId) != null;
        }
    }
}
