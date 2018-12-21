using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;

namespace Mystivate.Models
{
    public partial class WeaponType
    {
        public WeaponType()
        {
            Equipment = new HashSet<Equipment>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Equipment> Equipment { get; set; }
    }
}
