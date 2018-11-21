using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mystivate.Logic;
using Mystivate.Models;

namespace Mystivate.Controllers
{
    public class QuestController : Controller
    {
        private readonly IQuestLogic _questLogic;

        public QuestController(IQuestLogic questLogic)
        {
            _questLogic = questLogic;
        }

        public IActionResult Index()
        {
            QuestModel quest = _questLogic.GetCurrentQuest();
            return View(quest);
        }

        public int GetCurrentHealth()
        {
            return _questLogic.GetCurrentHealth();
        }

        public int GetMaxHealth()
        {
            QuestModel quest = _questLogic.GetCurrentQuest();
            return quest.Health;
        }

        public int GetDamageDone()
        {
            return _questLogic.GetDamageDoneToday();
        }
    }
}