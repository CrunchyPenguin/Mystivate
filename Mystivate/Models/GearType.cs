using System;
using System.Collections.Generic;

namespace Mystivate.Models
{
    public partial class GearType
    {
        public GearType()
        {
            Gear = new HashSet<Gear>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Gear> Gear { get; set; }
    }
}
