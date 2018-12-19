using System;
using System.Collections.Generic;

namespace Mystivate.Models
{
    public partial class Weapon
    {
        public Weapon()
        {
            WeaponInventory = new HashSet<WeaponInventory>();
            WeaponQuestReward = new HashSet<WeaponQuestReward>();
        }

        public int Id { get; set; }
        public int WeaponTypeId { get; set; }
        public string Name { get; set; }
        public int? Price { get; set; }

        public WeaponType WeaponType { get; set; }
        public ICollection<WeaponInventory> WeaponInventory { get; set; }
        public ICollection<WeaponQuestReward> WeaponQuestReward { get; set; }
    }
}
