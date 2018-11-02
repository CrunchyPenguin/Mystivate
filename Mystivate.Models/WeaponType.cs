using System;
using System.Collections.Generic;

namespace Mystivate.Models
{
    public partial class WeaponType
    {
        public WeaponType()
        {
            Weapon = new HashSet<Weapon>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Weapon> Weapon { get; set; }
    }
}
