using Mystivate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mystivate.Data
{
    public interface ICharacterAccess
    {
        /// <summary>
        /// Returns total experience.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        int AddExperience(int userId, int amount);
        int AddHealth(int userId, int amount);
        int GetCurrentHealth(int userId);
        int GetMaxHealth(int userId);
        int GetExperience(int userId);
        int GetCoins(int userId);
        Character GetCharacter(int userId);
        int GetCharacterId(int userId);
        Character GetCharacterWithInventory(int userId);
        void RemoveCoins(int amount, int characterId);
        void AddCoins(int amount, int characterId);
    }
}
