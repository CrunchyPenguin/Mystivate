using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mystivate.Models
{
    public class Gear : Equipment
    {
        
        public int? Armor { get; set; }
        public int? GearTypeId { get; set; }

        public GearType GearType { get; set; }
    }
}
