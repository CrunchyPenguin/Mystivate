using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mystivate.Logic;
using Mystivate.Models;

namespace Mystivate.Controllers
{
    [Authorize]
    public class ShopController : Controller
    {
        private readonly IEquipmentLogic _equipmentLogic;
        private readonly ICharacterInfo _characterInfo;

        public ShopController(IEquipmentLogic equipmentLogic, ICharacterInfo characterInfo)
        {
            _equipmentLogic = equipmentLogic;
            _characterInfo = characterInfo;
        }

        public IActionResult Index()
        {
            List<Equipment> equipment = _equipmentLogic.GetEquipment(false);
            return View(new Tuple<List<Equipment>, int>(equipment, GetCoins()));
        }

        public int BuyItem(int equipmentId)
        {
            return _equipmentLogic.BuyEquipment(equipmentId);
        }

        public int GetCoins()
        {
            return _characterInfo.GetCoins();
        }
    }
}