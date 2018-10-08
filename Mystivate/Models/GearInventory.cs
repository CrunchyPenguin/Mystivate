using System;
using System.Collections.Generic;

namespace Mystivate.Models
{
    public partial class GearInventory
    {
        public int Id { get; set; }
        public int GearId { get; set; }
        public int CharacterId { get; set; }

        public Character Character { get; set; }
        public Gear Gear { get; set; }
    }
}
