using System;
using System.Collections.Generic;

namespace Mystivate.Models
{
    public partial class GearQuestReward
    {
        public int Id { get; set; }
        public int QuestId { get; set; }
        public int GearId { get; set; }

        public Gear Gear { get; set; }
        public Quest Quest { get; set; }
    }
}
