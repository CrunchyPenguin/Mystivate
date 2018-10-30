using System;
using System.Collections.Generic;

namespace Mystivate.Models
{
    public partial class DailyTask
    {
        public int Id { get; set; }
        public int UsersId { get; set; }
        public string Name { get; set; }
        public bool? Done { get; set; }

        public User Users { get; set; }
    }
}
