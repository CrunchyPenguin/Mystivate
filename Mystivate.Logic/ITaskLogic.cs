using Mystivate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mystivate.Logic
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
        int CheckDaily(int dailyId);
        int PositiveHabit(int habitId);
        int NegativeHabit(int habitId);
        int CheckTodo(int todoId);
    }
}
