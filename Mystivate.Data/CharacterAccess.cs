using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            Character character = _dbContext.Characters.Where(c => c.UserId == userId).First();
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
            Character character = _dbContext.Characters.Where(c => c.UserId == userId).First();
            character.CurrentLives += amount;
            if(character.CurrentLives < 0)
            {
                character.CurrentLives = 0;
            }
            _dbContext.SaveChanges();
            return character.CurrentLives;
        }

        public Character GetCharacter(int userId)
        {
            return _dbContext.Characters.Where(c => c.UserId == userId).First();
        }

        public int GetCoins(int userId)
        {
            throw new NotImplementedException();
        }

        public int GetExperience(int userId)
        {
            Character character = _dbContext.Characters.Where(c => c.UserId == userId).First();
            return character.Experience;
        }

        public int GetCurrentHealth(int userId)
        {
            return _dbContext.Characters.Where(c => c.UserId == userId).First().CurrentLives;
        }

        public int GetMaxHealth(int userId)
        {
            return _dbContext.Characters.Where(c => c.UserId == userId).First().MaxLives;
        }
    }
}
