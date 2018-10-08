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
        }

        public int Id { get; set; }
        public int UsersId { get; set; }
        public int? ArmorId { get; set; }
        public int? HeadgearId { get; set; }
        public int? RightWeaponId { get; set; }
        public int? LeftWeaponId { get; set; }
        public string Name { get; set; }
        public int? Coins { get; set; }
        public int? Level { get; set; }
        public int? Experience { get; set; }
        public int Lives { get; set; }

        public Gear Armor { get; set; }
        public Gear Headgear { get; set; }
        public Gear LeftWeapon { get; set; }
        public Gear RightWeapon { get; set; }
        public User Users { get; set; }
        public ICollection<GearInventory> GearInventory { get; set; }
        public ICollection<QuestInventory> QuestInventory { get; set; }
    }
}
