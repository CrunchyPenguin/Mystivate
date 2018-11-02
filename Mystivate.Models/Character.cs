using System;
using System.Collections.Generic;

namespace Mystivate.Models
{
    public partial class Character
    {
        public Character()
        {
            GearInventory = new HashSet<GearInventory>();
            QuestInventory = new HashSet<QuestInventory>();
            WeaponInventory = new HashSet<WeaponInventory>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public int Coins { get; set; }
        public int Experience { get; set; }
        public int MaxLives { get; set; }
        public int CurrentLives { get; set; }

        public User User { get; set; }
        public ICollection<GearInventory> GearInventory { get; set; }
        public ICollection<QuestInventory> QuestInventory { get; set; }
        public ICollection<WeaponInventory> WeaponInventory { get; set; }
    }
}
