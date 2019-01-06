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
            _dbContext.SaveChanges();
        }

        public List<InventorySlot> GetEquipment(int characterId)
        {
            return _dbContext.InventorySlots.Include(i => i.Equipment).Where(i => i.CharacterId == characterId).ToList();
        }

        public List<Equipment> GetQuestRewards(int questId)
        {
            throw new NotImplementedException();
        }

        public List<Quest> GetQuests(int characterId)
        {
            throw new NotImplementedException();
        }

        public void WearEquipment(int characterId, int equipmentId)
        {
            bool wearing = _dbContext.InventorySlots.First(i => i.CharacterId == characterId && i.EquipmentId == equipmentId).Wearing;
            _dbContext.InventorySlots.First(i => i.CharacterId == characterId && i.EquipmentId == equipmentId).Wearing = !wearing;
            _dbContext.SaveChanges();
        }
    }
}
