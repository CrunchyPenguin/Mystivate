using System;
using System.Collections.Generic;

namespace Mystivate.Models
{
    public partial class Quest
    {
        public Quest()
        {
            GearQuestReward = new HashSet<GearQuestReward>();
            QuestInventory = new HashSet<QuestInventory>();
            WeaponQuestReward = new HashSet<WeaponQuestReward>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string BossImage { get; set; }
        public int Lives { get; set; }
        public int CoinRewards { get; set; }
        public int? RecLevel { get; set; }

        public ICollection<GearQuestReward> GearQuestReward { get; set; }
        public ICollection<QuestInventory> QuestInventory { get; set; }
        public ICollection<WeaponQuestReward> WeaponQuestReward { get; set; }
    }
}
