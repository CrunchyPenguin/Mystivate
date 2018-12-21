using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mystivate.Data;
using Mystivate.Models;

namespace Mystivate.Logic
{
    public class InventoryLogic : IInventoryLogic
    {
        private readonly IInventoryAccess _inventoryAccess;
        private readonly IUserInfo _userInfo;

        public InventoryLogic(IInventoryAccess inventoryAccess, IUserInfo userInfo)
        {
            _inventoryAccess = inventoryAccess;
            _userInfo = userInfo;
        }

        public void AddQuest(int questInventoryId)
        {
            throw new NotImplementedException();
        }

        public List<Equipment> GetInventory()
        {
            return _inventoryAccess.GetEquipment(_userInfo.GetUserId()).Select(i => i.Equipment).ToList();
        }

        public List<Equipment> GetInventory(bool isWearing)
        {
            return _inventoryAccess.GetEquipment(_userInfo.GetUserId()).Where(i => i.Wearing == isWearing).Select(i => i.Equipment).ToList();
        }

        public List<Quest> GetQuestInventory()
        {
            throw new NotImplementedException();
        }

        public List<Equipment> GetQuestRewards(int questId)
        {
            throw new NotImplementedException();
        }

        public void SetEquipment(int equipmentId)
        {
            _inventoryAccess.WearEquipment(_userInfo.GetUserId(), equipmentId);
        }
    }
}
