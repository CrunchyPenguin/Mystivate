using System;
using System.Collections.Generic;

namespace Mystivate.Models
{
    public partial class Character
    {
        public Character()
        {
            InventorySlot = new HashSet<InventorySlot>();
            QuestInventory = new HashSet<QuestInventory>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public int Coins { get; set; }
        public int Experience { get; set; }
        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }

        public User User { get; set; }
        public ICollection<InventorySlot> InventorySlot { get; set; }
        public ICollection<QuestInventory> QuestInventory { get; set; }
    }
}
