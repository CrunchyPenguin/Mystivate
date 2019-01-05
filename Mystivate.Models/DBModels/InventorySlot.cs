using System;
using System.Collections.Generic;

namespace Mystivate.Models
{
    public partial class InventorySlot
    {
        public int Id { get; set; }
        public int CharacterId { get; set; }
        public int EquipmentId { get; set; }
        public bool Wearing { get; set; }
        public bool Left { get; set; }

        public Character Character { get; set; }
        public Equipment Equipment { get; set; }
    }
}
