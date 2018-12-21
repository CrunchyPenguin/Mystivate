using Microsoft.EntityFrameworkCore;
using Mystivate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mystivate.Data
{
    public class QuestAccess : IQuestAccess
    {
        private readonly Mystivate_dbContext _dbContext;
        public QuestAccess(Mystivate_dbContext db)
        {
            _dbContext = db;
        }

        public void AddDamage(int QuestInventoryId, int damage)
        {
            if (_dbContext.QuestInventory.Any(q => q.Id == QuestInventoryId))
            {
                _dbContext.QuestInventory.SingleOrDefault(q => q.Id == QuestInventoryId).DamageToday += damage;
                _dbContext.SaveChanges();
            }
        }

        public Quest GetCurrentQuest(int characterId)
        {
            return _dbContext.QuestInventory.Where(q => q.CharacterId == characterId).Include(q => q.Quest).SingleOrDefault(q => q.QuestStatus.Status == "ongoing").Quest;
        }

        public int GetDamageToday(int characterId)
        {
            return _dbContext.QuestInventory.Where(q => q.CharacterId == characterId).SingleOrDefault(q => q.QuestStatus.Status == "ongoing").DamageToday;
        }

        public int GetDamage(int characterId)
        {
            return _dbContext.QuestInventory.Where(q => q.CharacterId == characterId).SingleOrDefault(q => q.QuestStatus.Status == "ongoing").DamageDone;
        }

        public int GetQuestHealth(int characterId)
        {
            return _dbContext.QuestInventory.Where(q => q.CharacterId == characterId).Include(q => q.Quest).SingleOrDefault(q => q.QuestStatus.Status == "ongoing").Quest.Health;
        }

        public void DamageTodayToDamageDone()
        {
            List<QuestInventory> allQuestInventories = _dbContext.QuestInventory.ToList();
            foreach(QuestInventory questInventory in allQuestInventories)
            {
                questInventory.DamageDone += questInventory.DamageToday;
                questInventory.DamageToday = 0;
            }
        }
    }
}
