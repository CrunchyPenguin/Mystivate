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

        public void AddDamage(int characterId, int damage)
        {
            if (_dbContext.QuestInventory.Any(q => q.CharacterId == characterId && q.QuestStatus.Status == "active"))
            {
                _dbContext.QuestInventory.Where(q => q.CharacterId == characterId).Include(q => q.Quest).SingleOrDefault(q => q.QuestStatus.Status == "active").DamageToday += damage;
                _dbContext.SaveChanges();
            }
        }

        public Quest GetCurrentQuest(int characterId)
        {
            return _dbContext.QuestInventory.Where(q => q.CharacterId == characterId).Include(q => q.Quest).SingleOrDefault(q => q.QuestStatus.Status == "active" || q.QuestStatus.Status == "complete")?.Quest;
        }

        public int GetDamageToday(int characterId)
        {
            return _dbContext.QuestInventory.Where(q => q.CharacterId == characterId).SingleOrDefault(q => q.QuestStatus.Status == "active" || q.QuestStatus.Status == "complete").DamageToday;
        }

        public int GetDamage(int characterId)
        {
            return _dbContext.QuestInventory.Where(q => q.CharacterId == characterId).SingleOrDefault(q => q.QuestStatus.Status == "active" || q.QuestStatus.Status == "complete").DamageDone;
        }

        public int GetQuestHealth(int characterId)
        {
            return _dbContext.QuestInventory.Where(q => q.CharacterId == characterId).Include(q => q.Quest).SingleOrDefault(q => q.QuestStatus.Status == "active" || q.QuestStatus.Status == "complete").Quest.Health;
        }

        public List<QuestEquipmentReward> GetQuestEquipmentRewards(int characterId)
        {
            int? questCompleteId = _dbContext.QuestInventory.Where(q => q.CharacterId == characterId).Include(q => q.Quest).SingleOrDefault(q => q.QuestStatus.Status == "complete")?.QuestId;

            if (questCompleteId.HasValue)
                return _dbContext.QuestEquipmentRewards.Where(q => q.QuestId == questCompleteId).Include(q => q.Equipment).ToList();
            else
                return null;
        }

        public void SetQuestRewarded(int characterId)
        {
            _dbContext.QuestInventory.Where(q => q.CharacterId == characterId).SingleOrDefault(q => q.QuestStatus.Status == "complete").QuestStatusId = _dbContext.QuestStatus.SingleOrDefault(s => s.Status == "rewarded").Id;
            _dbContext.SaveChanges();
        }

        public bool HasCompletedQuest(int characterId)
        {
            return _dbContext.QuestInventory.Where(q => q.CharacterId == characterId).Include(q => q.Quest).Any(q => q.QuestStatus.Status == "complete");
        }

        public List<QuestInventory> GetQuestInventory(int characterId)
        {
            return _dbContext.QuestInventory.Where(q => q.CharacterId == characterId).Include(q => q.Quest).Include(q => q.QuestStatus).ToList();
        }

        public void CancelQuest(int characterId)
        {
            QuestInventory questInventory = _dbContext.QuestInventory.Where(q => q.CharacterId == characterId).SingleOrDefault(q => q.QuestStatus.Status == "active");
            questInventory.DamageDone = 0;
            questInventory.DamageToday = 0;
            questInventory.QuestStatusId = _dbContext.QuestStatus.SingleOrDefault(s => s.Status == "owned").Id;
            _dbContext.SaveChanges();
        }

        public void SetQuest(int characterId, int questInventoryId)
        {
            if(_dbContext.QuestInventory.Where(q => q.CharacterId == characterId).Any(q => q.Id == questInventoryId))
            {
                QuestInventory questInventory = _dbContext.QuestInventory.SingleOrDefault(q => q.Id == questInventoryId);
                questInventory.QuestStatusId = _dbContext.QuestStatus.SingleOrDefault(s => s.Status == "active").Id;
                _dbContext.SaveChanges();
            }
        }
    }
}
