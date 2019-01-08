using Mystivate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mystivate.Logic
{
    public interface ICharacterManager
    {
        void AddExperience(int amount);
        void AddHealth(int amount);
        void RemoveCoins(int amount);
        void AddCoins(int amount);
    }
}
