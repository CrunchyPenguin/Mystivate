using System;
using System.Collections.Generic;

namespace Mystivate.Models
{
    public partial class Quest
    {
        public Quest()
        {
            QuestInventory = new HashSet<QuestInventory>();
            QuestRewards = new HashSet<QuestReward>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string BossImage { get; set; }
        public int Lives { get; set; }
        public int CoinRewards { get; set; }
        public int? RecLevel { get; set; }

        public ICollection<QuestInventory> QuestInventory { get; set; }
        public ICollection<QuestReward> QuestRewards { get; set; }
    }
}
