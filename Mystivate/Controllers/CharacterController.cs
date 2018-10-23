using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mystivate.Code.Logic;

namespace Mystivate.Controllers
{
    public class CharacterController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ICharacterLogic _characterLogic;

        public CharacterController(IUserService userService, ICharacterLogic characterLogic)
        {
            _userService = userService;
            _characterLogic = characterLogic;
        }

        public int GetCurrentExperience()
        {
            return _characterLogic.GetExperience();
        }

        public int GetNextLvlExp()
        {
            return _characterLogic.GetExperienceNextLevel();
        }
    }
}