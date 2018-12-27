using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mystivate.Models
{
    public class CharacterInfoViewModel
    {
        public List<DailyTask> DailyTasks { get; set; }
        public List<Habit> Habits { get; set; }
        public List<ToDo> ToDos { get; set; }
        public Character Character { get; set; }
    }
}
