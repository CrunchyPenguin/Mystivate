using Mystivate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mystivate.Code.Logic
{
    interface ICharacterLogic
    {
        int GetLives();
        int GetLevel();
        int GetExperience();
        int GetCoins();
        CharacterModel GetCharacterInfo();
    }
}
