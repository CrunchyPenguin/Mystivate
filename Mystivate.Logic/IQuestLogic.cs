using Mystivate.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mystivate.Logic
{
    public interface IQuestLogic
    {
        void SelectQuest(int questInventoryId);
        QuestModel GetCurrentQuest();
        int GetDamageDoneToday();
        int GetCurrentHealth();
        void AddDamage(int damage);
        List<QuestInventory> GetQuestInventory();
        Equipment GetQuestRewards();
        bool QuestCompleted();
        void CancelQuest();
    }
}
