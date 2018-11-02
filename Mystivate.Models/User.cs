using System;
using System.Collections.Generic;

namespace Mystivate.Models
{
    public partial class User
    {
        public User()
        {
            Character = new HashSet<Character>();
            Habit = new HashSet<Habit>();
            Task = new HashSet<DailyTask>();
            ToDo = new HashSet<ToDo>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordKey { get; set; }
        public string PasswordSalt { get; set; }
        public DateTime? LastLogin { get; set; }

        public ICollection<Character> Character { get; set; }
        public ICollection<Habit> Habit { get; set; }
        public ICollection<DailyTask> Task { get; set; }
        public ICollection<ToDo> ToDo { get; set; }
    }
}
