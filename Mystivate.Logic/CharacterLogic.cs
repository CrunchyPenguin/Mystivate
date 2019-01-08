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
            CheckHealth();
        }

        public CharacterModel GetCharacterInfo()
        {
            CheckHealth();
            Character character = _characterAccess.GetCharacter(_userInfo.GetUserId());
            CharacterModel model = new CharacterModel()
            {
                Name = character.Name,
                CurrentHealth = character.CurrentHealth,
                MaxHealth = character.MaxHealth,
                Level = GetLevel(),
                Experience = GetExperience(),
                Coins = character.Coins
            };
            return model;
        }

        public int GetCoins()
        {
            CheckHealth();
            return GetCharacterInfo().Coins;
        }

        public int GetExperience()
        {
            CheckHealth();
            return CalculateCurrentExp(_characterAccess.GetExperience(_userInfo.GetUserId()));
        }

        public int GetExperienceNextLevel()
        {
            CheckHealth();
            return CalculateNextLevelExp(_characterAccess.GetExperience(_userInfo.GetUserId()));
        }

        public int GetLevel()
        {
            CheckHealth();
            return CalculateLevel(_characterAccess.GetExperience(_userInfo.GetUserId()));
        }

        public int GetCurrentHealth()
        {
            CheckHealth();
            return _characterAccess.GetCurrentHealth(_userInfo.GetUserId());
            // if health is 0 do something
        }

        public int GetMaxHealth()
        {
            CheckHealth();
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
            CheckHealth();
            _characterAccess.AddHealth(_userInfo.GetUserId(), amount);
        }

        public int GetCharacterId()
        {
            return _characterAccess.GetCharacterId(_userInfo.GetUserId());
        }

        public Character GetCharacterInfo(bool includeInventory)
        {
            CheckHealth();
            return _characterAccess.GetCharacterWithInventory(_userInfo.GetUserId());
        }

        public void RemoveCoins(int amount)
        {
            CheckHealth();
            _characterAccess.RemoveCoins(amount, GetCharacterId());
        }

        public void AddCoins(int amount)
        {
            CheckHealth();
            _characterAccess.AddCoins(amount, GetCharacterId());
        }

        private void CheckHealth(int health = -1)
        {
            if(health < 0)
            {
                health = _characterAccess.GetCurrentHealth(_userInfo.GetUserId());
            }

            if(health == 0)
            {
                int characterId = GetCharacterId();
                int level = CalculateLevel(_characterAccess.GetExperience(_userInfo.GetUserId()));
                int experienceToSet = CalculateExperience(level - 1);
                _characterAccess.SetExperience(experienceToSet, characterId);
                _characterAccess.HealthToMax(characterId);
            }
        }
        
    }
}
