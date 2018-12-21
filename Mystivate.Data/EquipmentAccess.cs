using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Mystivate.Models;

namespace Mystivate.Data
{
    public class EquipmentAccess : IEquipmentAccess
    {
        private readonly Mystivate_dbContext _dbContext;
        public EquipmentAccess(Mystivate_dbContext db)
        {
            _dbContext = db;
        }

        public List<Equipment> GetAllEquipment()
        {
            return _dbContext.Equipment.Include(e => e.InventorySlot).ToList();
        }
    }
}
