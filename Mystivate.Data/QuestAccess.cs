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
            _dbContext.QuestInventory.Where(q => q.CharacterId == characterId).Include(q => q.Quest).SingleOrDefault(q => q.QuestStatus.Status == "complete").QuestStatusId = _dbContext.QuestStatus.SingleOrDefault(s => s.Status == "rewarded").Id;
            _dbContext.SaveChanges();
        }

        public bool HasCompletedQuest(int characterId)
        {
            return _dbContext.QuestInventory.Where(q => q.CharacterId == characterId).Include(q => q.Quest).Any(q => q.QuestStatus.Status == "complete");
        }
    }
}
