using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Mystivate.Models;

namespace Mystivate.Data
{
    public class InventoryAccess : IInventoryAccess
    {
        private readonly Mystivate_dbContext _dbContext;
        public InventoryAccess(Mystivate_dbContext db)
        {
            _dbContext = db;
        }

        public void AddEquipment(int characterId, int equipmentId)
        {
            _dbContext.InventorySlots.Add(new InventorySlot
            {
                CharacterId = characterId,
                EquipmentId = equipmentId,
                Left = false,
                Wearing = false
            });
        }

        public List<InventorySlot> GetEquipment(int userId)
        {
            return _dbContext.InventorySlots.Include(i => i.Equipment).Where(i => i.Character.UserId == userId).ToList();
        }

        public List<Equipment> GetQuestRewards(int questId)
        {
            throw new NotImplementedException();
        }

        public List<Quest> GetQuests(int userId)
        {
            throw new NotImplementedException();
        }

        public void WearEquipment(int userId, int equipmentId)
        {
            _dbContext.InventorySlots.SingleOrDefault(i => i.Character.UserId == userId && i.EquipmentId == equipmentId).Wearing = true;
            _dbContext.SaveChanges();
        }
    }
}
