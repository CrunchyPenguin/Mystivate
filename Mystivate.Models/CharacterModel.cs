using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mystivate.Models
{
    public class CharacterModel
    {
        public string Name { get; set; }
        public int Lives { get; set; }
        public int Level { get; set; }
        public int Experience { get; set; }
        public int Coins { get; set; }
        public Gear Armor { get; set; }
        public Gear Headgear { get; set; }
        public Gear LeftWeapon { get; set; }
        public Gear RightWeapon { get; set; }
    }
}
