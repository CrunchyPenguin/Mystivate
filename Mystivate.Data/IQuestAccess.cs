using Mystivate.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mystivate.Data
{
    public interface IQuestAccess
    {
        Quest GetCurrentQuest(int characterId);
        void AddDamage(int characterId, int damage);
        int GetDamage(int characterId);
        int GetDamageToday(int characterId);
        int GetQuestHealth(int characterId);
        List<QuestEquipmentReward> GetQuestEquipmentRewards(int characterId);
        void SetQuestRewarded(int characterId);
        bool HasCompletedQuest(int characterId);
        List<QuestInventory> GetQuestInventory(int characterId);
        void CancelQuest(int characterId);
        void SetQuest(int characterId, int questInventoryId);
    }
}
