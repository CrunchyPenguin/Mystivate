using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mystivate.Logic;

namespace Mystivate.Controllers
{
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterInfo _characterInfo;
        private readonly ICharacterManager _characterManager;

        public CharacterController(ICharacterInfo characterInfo, ICharacterManager characterManager)
        {
            _characterInfo = characterInfo;
            _characterManager = characterManager;
        }

        public int GetCurrentExp()
        {
            return _characterInfo.GetExperience();
        }

        public int GetNextLvlExp()
        {
            return _characterInfo.GetExperienceNextLevel();
        }

        public int GetCurrentLevel()
        {
            return _characterInfo.GetLevel();
        }

        public int GetMaxHealth()
        {
            return _characterInfo.GetMaxHealth();
        }

        public int GetCurrentHealth()
        {
            return _characterInfo.GetCurrentHealth();
        }
    }
}