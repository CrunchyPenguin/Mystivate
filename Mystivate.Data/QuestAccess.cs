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

        public Quest GetCurrentQuest(int characterId)
        {
            List<Quest> quests = _dbContext.QuestInventory.Where(q => q.CharacterId == characterId).Select(q => q.Quest).ToList();
            return _dbContext.QuestInventory.Where(q => q.CharacterId == characterId).SingleOrDefault(q => q.QuestStatus.Status == "ongoing").Quest;
        }
    }
}
