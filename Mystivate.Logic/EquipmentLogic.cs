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
        private readonly IEquipmentAccess _equipmentAccess;

        public EquipmentLogic(ICharacterInfo characterInfo, IEquipmentAccess equipmentAccess)
        {
            _characterInfo = characterInfo;
            _equipmentAccess = equipmentAccess;
        }

        public List<Equipment> GetEquipment()
        {
            return _equipmentAccess.GetAllEquipment();
        }

        public List<Equipment> GetEquipment(bool owned)
        {
            return _equipmentAccess.GetAllEquipment().Where(e => e.InventorySlot.Any(i => i.CharacterId == _characterInfo.GetCharacterId()) == owned).ToList();
        }
    }
}
