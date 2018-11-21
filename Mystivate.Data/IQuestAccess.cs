using Mystivate.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mystivate.Data
{
    public interface IQuestAccess
    {
        Quest GetCurrentQuest(int characterId);
        void AddDamage(int QuestInventoryId, int damage);
        int GetDamage(int characterId);
        int GetDamageToday(int characterId);
        int GetQuestHealth(int characterId);
        void DamageTodayToDamageDone();
    }
}
