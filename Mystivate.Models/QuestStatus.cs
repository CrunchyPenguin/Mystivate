using System;
using System.Collections.Generic;

namespace Mystivate.Models
{
    public partial class QuestStatus
    {
        public QuestStatus()
        {
            QuestInventory = new HashSet<QuestInventory>();
        }

        public int Id { get; set; }
        public string Status { get; set; }

        public ICollection<QuestInventory> QuestInventory { get; set; }
    }
}
