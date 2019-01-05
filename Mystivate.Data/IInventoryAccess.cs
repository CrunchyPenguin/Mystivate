using Mystivate.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mystivate.Data
{
    public interface IInventoryAccess
    {
        List<InventorySlot> GetEquipment(int userId);
        List<Quest> GetQuests(int userId);
        List<Equipment> GetQuestRewards(int questId);
        void WearEquipment(int userId, int equipmentId);
        void AddEquipment(int characterId, int equipmentId);
    }
}
