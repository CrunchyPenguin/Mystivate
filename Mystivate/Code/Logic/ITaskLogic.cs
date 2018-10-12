using Mystivate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mystivate.Code.Logic
{
    public interface ITaskLogic
    {
        List<DailyTask> GetDailyTaskList();
        List<Habit> GetHabitList();
        List<ToDo> GetTodoList();
        AllTasksViewModel GetAllTasks();
        int AddDailyTask(string taskname);
        int AddHabit(string habitname);
        int AddTodo(string todoname);
        void CheckDaily(int dailyId);
        void PositiveHabit(int habitId);
        void NegativeHabit(int negativeId);
        void CheckTodo(int todoId);
    }
}
