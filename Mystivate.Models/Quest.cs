using System;
using System.Collections.Generic;

namespace Mystivate.Models
{
    public partial class Quest
    {
        public Quest()
        {
            QuestEquipmentRewards = new HashSet<QuestEquipmentReward>();
            QuestInventory = new HashSet<QuestInventory>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string BossImage { get; set; }
        public int Health { get; set; }
        public int CoinRewards { get; set; }
        public int? RecLevel { get; set; }

        public ICollection<QuestEquipmentReward> QuestEquipmentRewards { get; set; }
        public ICollection<QuestInventory> QuestInventory { get; set; }
    }
}
