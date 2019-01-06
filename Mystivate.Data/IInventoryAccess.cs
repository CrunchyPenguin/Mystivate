using Mystivate.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mystivate.Data
{
    public interface IInventoryAccess
    {
        List<InventorySlot> GetEquipment(int characterId);
        List<Quest> GetQuests(int characterId);
        List<Equipment> GetQuestRewards(int questId);
        void WearEquipment(int characterId, int equipmentId);
        void AddEquipment(int characterId, int equipmentId);
    }
}
