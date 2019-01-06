using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mystivate.Models;

namespace Mystivate.Data
{
    public class CharacterAccess : ICharacterAccess
    {
        private readonly Mystivate_dbContext _dbContext;
        public CharacterAccess(Mystivate_dbContext db)
        {
            _dbContext = db;
        }

        public int AddExperience(int userId, int amount)
        {
            //Character c = (from s in _dbContext.Characters where s.UsersId == userId select s).FirstOrDefault();
            Character character = _dbContext.Characters.SingleOrDefault(c => c.UserId == userId);
            character.Experience += amount;
            if(character.Experience < 0)
            {
                character.Experience = 0;
            }
            _dbContext.SaveChanges();
            return character.Experience;
        }

        public int AddHealth(int userId, int amount)
        {
            Character character = _dbContext.Characters.SingleOrDefault(c => c.UserId == userId);
            character.CurrentHealth += amount;
            if(character.CurrentHealth < 0)
            {
                character.CurrentHealth = 0;
            }
            _dbContext.SaveChanges();
            return character.CurrentHealth;
        }

        public Character GetCharacter(int userId)
        {
            return _dbContext.Characters.SingleOrDefault(c => c.UserId == userId);
        }

        public int GetCharacterId(int userId)
        {
            return _dbContext.Characters.SingleOrDefault(c => c.UserId == userId).Id;
        }

        public int GetCoins(int userId)
        {
            throw new NotImplementedException();
        }

        public int GetExperience(int userId)
        {
            Character character = _dbContext.Characters.SingleOrDefault(c => c.UserId == userId);
            return character.Experience;
        }

        public int GetCurrentHealth(int userId)
        {
            return _dbContext.Characters.SingleOrDefault(c => c.UserId == userId).CurrentHealth;
        }

        public int GetMaxHealth(int userId)
        {
            return _dbContext.Characters.SingleOrDefault(c => c.UserId == userId).MaxHealth;
        }

        public Character GetCharacterWithInventory(int userId)
        {
            return _dbContext.Characters.Include(c => c.InventorySlot).ThenInclude(c => c.Equipment).ThenInclude(e => (e as Weapon).WeaponType).Include(c => c.InventorySlot).ThenInclude(c => c.Equipment).ThenInclude(e => (e as Gear).GearType).SingleOrDefault(c => c.UserId == userId);
        }

        public void RemoveCoins(int amount, int characterId)
        {
            _dbContext.Characters.SingleOrDefault(c => c.Id == characterId).Coins -= amount;
            _dbContext.SaveChanges();
        }
    }
}
