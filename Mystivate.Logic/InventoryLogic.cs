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
        private readonly ICharacterInfo _characterInfo;

        public InventoryLogic(IInventoryAccess inventoryAccess, ICharacterInfo characterInfo)
        {
            _inventoryAccess = inventoryAccess;
            _characterInfo = characterInfo;
        }

        public void AddEquipment(int equipmentId)
        {
            _inventoryAccess.AddEquipment(_characterInfo.GetCharacterId(), equipmentId);
        }

        public void AddQuest(int questInventoryId)
        {
            throw new NotImplementedException();
        }

        public List<Equipment> GetInventory()
        {
            return _inventoryAccess.GetEquipment(_characterInfo.GetCharacterId()).Select(i => i.Equipment).ToList();
        }

        public List<Equipment> GetInventory(bool isWearing)
        {
            return _inventoryAccess.GetEquipment(_characterInfo.GetCharacterId()).Where(i => i.Wearing == isWearing).Select(i => i.Equipment).ToList();
        }

        public List<Quest> GetQuestInventory()
        {
            throw new NotImplementedException();
        }

        public List<Equipment> GetQuestRewards(int questId)
        {
            throw new NotImplementedException();
        }

        public void WearEquipment(int equipmentId)
        {
            _inventoryAccess.WearEquipment(_characterInfo.GetCharacterId(), equipmentId);
        }
    }
}
