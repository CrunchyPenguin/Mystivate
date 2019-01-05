using System;
using System.Collections.Generic;

namespace Mystivate.Models
{
    public partial class ToDo
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }

        public User User { get; set; }
    }
}
