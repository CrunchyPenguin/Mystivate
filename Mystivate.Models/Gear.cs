using System;
using System.Collections.Generic;

namespace Mystivate.Models
{
    public partial class Gear
    {
        public Gear()
        {
            CharactersArmor = new HashSet<Character>();
            CharactersHeadgear = new HashSet<Character>();
            CharactersLeftWeapon = new HashSet<Character>();
            CharactersRightWeapon = new HashSet<Character>();
            GearInventory = new HashSet<GearInventory>();
            QuestRewards = new HashSet<QuestReward>();
        }

        public int Id { get; set; }
        public int GearTypeId { get; set; }
        public string Image { get; set; }
        public int Price { get; set; }

        public GearType GearType { get; set; }
        public ICollection<Character> CharactersArmor { get; set; }
        public ICollection<Character> CharactersHeadgear { get; set; }
        public ICollection<Character> CharactersLeftWeapon { get; set; }
        public ICollection<Character> CharactersRightWeapon { get; set; }
        public ICollection<GearInventory> GearInventory { get; set; }
        public ICollection<QuestReward> QuestRewards { get; set; }
    }
}
