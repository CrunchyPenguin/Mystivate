using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mystivate.Data;
using Mystivate.Models;

namespace Mystivate.Logic
{
    public class EquipmentLogic : IEquipmentLogic
    {
        private readonly ICharacterInfo _characterInfo;
        private readonly ICharacterManager _characterManager;
        private readonly IEquipmentAccess _equipmentAccess;
        private readonly IInventoryLogic _inventoryLogic;

        public EquipmentLogic(ICharacterInfo characterInfo, IEquipmentAccess equipmentAccess, IInventoryLogic inventoryLogic, ICharacterManager characterManager)
        {
            _characterInfo = characterInfo;
            _equipmentAccess = equipmentAccess;
            _inventoryLogic = inventoryLogic;
            _characterManager = characterManager;
        }

        public List<Equipment> GetEquipment()
        {
            return _equipmentAccess.GetAllEquipment().Where(e => e.Price.HasValue).ToList();
        }

        public List<Equipment> GetEquipment(bool owned)
        {
            return _equipmentAccess.GetAllEquipment().Where(e => e.InventorySlot.Any(i => i.CharacterId == _characterInfo.GetCharacterId()) == owned && e.Price.HasValue).ToList();
        }

        public int BuyEquipment(int equipmentId)
        {
            int characterCoins = _characterInfo.GetCoins();
            int? price = _equipmentAccess.GetEquipmentById(equipmentId).Price;
            if (price.HasValue)
            {
                if (_characterInfo.GetCoins() < _equipmentAccess.GetEquipmentById(equipmentId).Price)
                {
                    return price.Value - characterCoins;
                }
                else
                {
                    _inventoryLogic.AddEquipment(equipmentId);
                    _characterManager.RemoveCoins(price.Value);
                    return 0;
                }
            }
            else
            {
                return -1;
            }
        }
    }
}
