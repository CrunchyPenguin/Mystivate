﻿using Mystivate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mystivate.Logic
{
    public interface ICharacterInfo
    {
        int GetLevel();
        int GetExperience();
        int GetCoins();
        CharacterModel GetCharacterInfo();
        Character GetCharacterInfo(bool includeInventory);
        int GetExperienceNextLevel();
        int GetMaxHealth();
        int GetCurrentHealth();
        int GetCharacterId();
    }
}
