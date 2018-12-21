﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mystivate.Logic;
using Mystivate.Models;

namespace Mystivate.Controllers
{
    public class ShopController : Controller
    {
        private readonly IEquipmentLogic _equipmentLogic;

        public ShopController(IEquipmentLogic equipmentLogic)
        {
            _equipmentLogic = equipmentLogic;
        }

        public IActionResult Index()
        {
            List<Equipment> equipment = _equipmentLogic.GetEquipment(false);
            return View(equipment);
        }
    }
}