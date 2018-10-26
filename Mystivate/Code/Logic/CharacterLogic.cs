using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mystivate.Code.Database;
using Mystivate.Models;

namespace Mystivate.Code.Logic
{
    public class CharacterLogic : ICharacterLogic
    {
        private readonly ICharacterAccess _characterAccess;
        private readonly IUserService _userService;

        public CharacterLogic(ICharacterAccess characterAccess, IUserService userService)
        {
            _characterAccess = characterAccess;
            _userService = userService;
        }

        public void AddExperience(int amount)
        {
            _characterAccess.AddExperience(_userService.GetUserId(), amount);
        }

        public CharacterModel GetCharacterInfo()
        {
            throw new NotImplementedException();
        }

        public int GetCoins()
        {
            throw new NotImplementedException();
        }

        public int GetExperience()
        {
            return CalculateCurrentExp(_characterAccess.GetExperience(_userService.GetUserId()));
        }

        public int GetExperienceNextLevel()
        {
            return CalculateNextLevelExp(_characterAccess.GetExperience(_userService.GetUserId()));
        }

        public int GetLevel()
        {
            return CalculateLevel(_characterAccess.GetExperience(_userService.GetUserId()));
        }

        public int GetLives()
        {
            throw new NotImplementedException();
        }

        private int CalculateExperience(int level)
        {
            return (int)((level * 50) * (level * 1.618));
        }

        private int CalculateLevel(int experience)
        {
            //experience = (level x 50) x (level x 1.618(Phi))
            return (int)Math.Sqrt(experience / 80.9); // 1.618(variable) x 50
        }


        private int CalculateCurrentExp(int experience)
        {
            return experience - CalculateExperience(CalculateLevel(experience));

        }

        private int CalculateNextLevelExp(int experience)
        {
            int currentLevel = CalculateLevel(experience);
            int nextLevel = currentLevel + 1;
            return CalculateExperience(nextLevel) - CalculateExperience(currentLevel);

        }
    }
}
