using System;
using System.Collections.Generic;

namespace Mystivate.Models
{
    public partial class QuestInventory
    {
        public int Id { get; set; }
        public int CharacterId { get; set; }
        public int QuestId { get; set; }
        public int QuestStatusId { get; set; }
        public int DamageDone { get; set; }
        public int DamageToday { get; set; }

        public Character Character { get; set; }
        public Quest Quest { get; set; }
        public QuestStatus QuestStatus { get; set; }
    }
}
