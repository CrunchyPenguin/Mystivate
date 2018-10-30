using System;
using System.Collections.Generic;

namespace Mystivate.Models
{
    public partial class User
    {
        public User()
        {
            Characters = new HashSet<Character>();
            Habits = new HashSet<Habit>();
            Tasks = new HashSet<DailyTask>();
            ToDos = new HashSet<ToDo>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordKey { get; set; }
        public string PasswordSalt { get; set; }
        public DateTime? LastLogin { get; set; }

        public ICollection<Character> Characters { get; set; }
        public ICollection<Habit> Habits { get; set; }
        public ICollection<DailyTask> Tasks { get; set; }
        public ICollection<ToDo> ToDos { get; set; }
    }
}
