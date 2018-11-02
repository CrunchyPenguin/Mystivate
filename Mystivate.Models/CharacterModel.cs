using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mystivate.Models
{
    public class CharacterModel
    {
        public string Name { get; set; }
        public int CurrentLives { get; set; }
        public int MaxLives { get; set; }
        public int Level { get; set; }
        public int Experience { get; set; }
        public int Coins { get; set; }
    }
}
