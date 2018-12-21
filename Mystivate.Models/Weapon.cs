using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Mystivate.Models
{
    public class Weapon : Equipment
    {
        public int? Damage { get; set; }
        public int? WeaponTypeId { get; set; }

        public WeaponType WeaponType { get; set; }
    }
}
