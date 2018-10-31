using Mystivate.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mystivate.Logic
{
    public interface ITaskInfo
    {
        List<DailyTask> GetDailyTaskList();
        List<Habit> GetHabitList();
        List<ToDo> GetTodoList();
        AllTasksViewModel GetAllTasks();
    }
}
