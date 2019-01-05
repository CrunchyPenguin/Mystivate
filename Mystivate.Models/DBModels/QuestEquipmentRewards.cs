using System;
using System.Collections.Generic;

namespace Mystivate.Models
{
    public partial class QuestEquipmentReward
    {
        public int Id { get; set; }
        public int QuestId { get; set; }
        public int EquipmentId { get; set; }
        public int Chance { get; set; }

        public Equipment Equipment { get; set; }
        public Quest Quest { get; set; }
    }
}
