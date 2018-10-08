using System;
using System.Collections.Generic;

namespace Mystivate.Models
{
    public partial class ToDo
    {
        public int Id { get; set; }
        public int UsersId { get; set; }
        public int? Name { get; set; }

        public User Users { get; set; }
    }
}
