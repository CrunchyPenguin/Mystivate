using Mystivate.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mystivate.Logic
{
    public interface IEquipmentLogic
    {
        List<Equipment> GetEquipment();
        List<Equipment> GetEquipment(bool owned);
        int BuyEquipment(int equipmentId);
    }
}
