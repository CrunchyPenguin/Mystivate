using System;
using System.Collections.Generic;

namespace Mystivate.Models
{
    public partial class WeaponInventory
    {
        public int Id { get; set; }
        public int WeaponId { get; set; }
        public int CharacterId { get; set; }
        public bool? WeaponLeft { get; set; }
        public bool? WeaponRight { get; set; }

        public Character Character { get; set; }
        public Weapon Weapon { get; set; }
    }
}
