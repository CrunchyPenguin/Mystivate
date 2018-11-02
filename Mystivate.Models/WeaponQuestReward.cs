using System;
using System.Collections.Generic;

namespace Mystivate.Models
{
    public partial class WeaponQuestReward
    {
        public int Id { get; set; }
        public int WeaponId { get; set; }
        public int QuestId { get; set; }

        public Quest Quest { get; set; }
        public Weapon Weapon { get; set; }
    }
}
