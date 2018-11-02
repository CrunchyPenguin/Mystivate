using System;
using System.Collections.Generic;

namespace Mystivate.Models
{
    public partial class Gear
    {
        public Gear()
        {
            GearInventory = new HashSet<GearInventory>();
            GearQuestReward = new HashSet<GearQuestReward>();
        }

        public int Id { get; set; }
        public int GearTypeId { get; set; }
        public string Image { get; set; }
        public int? Price { get; set; }

        public GearType GearType { get; set; }
        public ICollection<GearInventory> GearInventory { get; set; }
        public ICollection<GearQuestReward> GearQuestReward { get; set; }
    }
}
