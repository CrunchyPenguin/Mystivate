using System;
using System.Collections.Generic;

namespace Mystivate.Models
{
    public partial class Habit
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public int? Positive { get; set; }
        public int? Negative { get; set; }

        public User User { get; set; }
    }
}
