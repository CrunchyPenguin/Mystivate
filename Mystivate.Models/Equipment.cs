using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;

namespace Mystivate.Models
{
    public abstract partial class Equipment
    {
        public Equipment()
        {
            InventorySlot = new HashSet<InventorySlot>();
            QuestEquipmentRewards = new HashSet<QuestEquipmentReward>();
        }
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int Price { get; set; }

        public ICollection<InventorySlot> InventorySlot { get; set; }
        public ICollection<QuestEquipmentReward> QuestEquipmentRewards { get; set; }
    }
}
