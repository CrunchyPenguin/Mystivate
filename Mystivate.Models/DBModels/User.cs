using System;
using System.Collections.Generic;

namespace Mystivate.Models
{
    public partial class User
    {
        public User()
        {
            Character = new HashSet<Character>();
            DailyTask = new HashSet<DailyTask>();
            Habit = new HashSet<Habit>();
            ToDo = new HashSet<ToDo>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordKey { get; set; }
        public string PasswordSalt { get; set; }
        public DateTime? LastLogin { get; set; }

        public ICollection<Character> Character { get; set; }
        public ICollection<DailyTask> DailyTask { get; set; }
        public ICollection<Habit> Habit { get; set; }
        public ICollection<ToDo> ToDo { get; set; }
    }
}
