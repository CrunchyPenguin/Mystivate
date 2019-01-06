using Mystivate.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mystivate.Logic
{
    public interface IInventoryLogic
    {
        List<Equipment> GetInventory();
        List<Equipment> GetInventory(bool isWearing);
        List<Quest> GetQuestInventory();
        List<Equipment> GetQuestRewards(int questId);
        void AddQuest(int questInventoryId);
        void WearEquipment(int equipmentId);
        void AddEquipment(int equipmentId);
    }
}
