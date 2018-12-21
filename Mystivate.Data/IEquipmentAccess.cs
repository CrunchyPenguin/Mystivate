using Mystivate.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mystivate.Data
{
    public interface IEquipmentAccess
    {
        List<Equipment> GetAllEquipment();
    }
}
