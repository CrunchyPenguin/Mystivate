using Mystivate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mystivate.Code.Logic
{
    public interface ICharacterLogic
    {
        int GetLives();
        int GetLevel();
        int GetExperience();
        int GetCoins();
        CharacterModel GetCharacterInfo();
        void AddExperience(int amount);
        int GetExperienceNextLevel();
    }
}
