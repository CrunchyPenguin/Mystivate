using System;
using System.Collections.Generic;
using System.Text;
using Mystivate.Data;
using Mystivate.Models;

namespace Mystivate.Logic
{
    public class QuestLogic : IQuestLogic
    {
        private readonly IQuestAccess _questAccess;
        private readonly ICharacterInfo _characterInfo;

        public QuestLogic(IQuestAccess questAccess, ICharacterInfo characterInfo)
        {
            _questAccess = questAccess;
            _characterInfo = characterInfo;
        }

        public QuestModel GetCurrentQuest()
        {
            Quest quest = _questAccess.GetCurrentQuest(_characterInfo.GetCharacterId());
            return new QuestModel
            {
                Id = quest.Id,
                Name = quest.Name,
                Image = quest.BossImage,
                Health = quest.Health,
                RecLevel = quest.RecLevel.Value,
                CoinReward = quest.CoinRewards
            };
        }

        public void SelectQuest()
        {
            throw new NotImplementedException();
        }

        public int GetCurrentHealth()
        {
            return _questAccess.GetQuestHealth(_characterInfo.GetCharacterId()) - _questAccess.GetDamage(_characterInfo.GetCharacterId());
        }

        public int GetDamageDoneToday()
        {
            return _questAccess.GetDamageToday(_characterInfo.GetCharacterId());
        }

        public void AddDamage(int damage)
        {
            _questAccess.AddDamage(_characterInfo.GetCharacterId(), damage);
        }

        public void Attack()
        {
            throw new NotImplementedException();
        }
    }
}
