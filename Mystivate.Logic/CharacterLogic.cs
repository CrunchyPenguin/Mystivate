using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Mystivate.Data;
using Mystivate.Models;

namespace Mystivate.Logic
{
    public class CharacterLogic : ICharacterInfo, ICharacterManager
    {
        private readonly ICharacterAccess _characterAccess;
        private readonly IUserInfo _userInfo;

        public CharacterLogic(ICharacterAccess characterAccess, IUserInfo userInfo)
        {
            _characterAccess = characterAccess;
            _userInfo = userInfo;
        }

        public void AddExperience(int amount)
        {
            _characterAccess.AddExperience(_userInfo.GetUserId(), amount);
        }

        public CharacterModel GetCharacterInfo()
        {
            Character character = _characterAccess.GetCharacter(_userInfo.GetUserId());
            CharacterModel model = new CharacterModel()
            {
                Name = character.Name,
                CurrentLives = character.CurrentLives,
                MaxLives = character.MaxLives,
                Level = GetLevel(),
                Experience = GetExperience(),
                Coins = character.Coins
            };
            return model;
        }

        public int GetCoins()
        {
            throw new NotImplementedException();
        }

        public int GetExperience()
        {
            return CalculateCurrentExp(_characterAccess.GetExperience(_userInfo.GetUserId()));
        }

        public int GetExperienceNextLevel()
        {
            return CalculateNextLevelExp(_characterAccess.GetExperience(_userInfo.GetUserId()));
        }

        public int GetLevel()
        {
            return CalculateLevel(_characterAccess.GetExperience(_userInfo.GetUserId()));
        }

        public int GetCurrentHealth()
        {
            return _characterAccess.GetCurrentHealth(_userInfo.GetUserId());
            // if health is 0 do something
        }

        public int GetMaxHealth()
        {
            return _characterAccess.GetMaxHealth(_userInfo.GetUserId());
        }

        private int CalculateExperience(int level)
        {
            return (int)((level * 50) * (level * 1.618));
        }

        private int CalculateLevel(int experience)
        {
            //experience = (level x 50) x (level x 1.618(Phi))
            return (int)Math.Sqrt((experience + 1) / 80.9); // 1.618(variable) x 50
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

        public void AddHealth(int amount)
        {
            _characterAccess.AddHealth(_userInfo.GetUserId(), amount);
        }

        public int GetCharacterId()
        {
            return _characterAccess.GetCharacterId(_userInfo.GetUserId());
        }
    }
}
