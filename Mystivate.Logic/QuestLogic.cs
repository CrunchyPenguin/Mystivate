using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mystivate.Data;
using Mystivate.Models;

namespace Mystivate.Logic
{
    public class QuestLogic : IQuestLogic
    {
        private readonly IQuestAccess _questAccess;
        private readonly IInventoryAccess _inventoryAccess;
        private readonly ICharacterInfo _characterInfo;

        public QuestLogic(IQuestAccess questAccess, ICharacterInfo characterInfo, IInventoryAccess inventoryAccess)
        {
            _questAccess = questAccess;
            _characterInfo = characterInfo;
            _inventoryAccess = inventoryAccess;
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
                CoinReward = quest.CoinReward,
                ExperienceReward = quest.ExperienceReward
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

        public QuestInventory GetQuestInventory()
        {
            throw new NotImplementedException();
        }

        public Equipment GetQuestRewards()
        {
            int characterId = _characterInfo.GetCharacterId();
            List<QuestEquipmentReward> equipmentRewards = _questAccess.GetQuestEquipmentRewards(characterId);
            if(equipmentRewards != null)
            {
                _questAccess.SetQuestRewarded(characterId);
                if (equipmentRewards.Count > 0)
                {
                    List<int> cumulativeList = new List<int>();
                    cumulativeList.Add(equipmentRewards[0].Chance);
                    for (int i = 1; i < equipmentRewards.Count; i++)
                    {
                        cumulativeList.Add(equipmentRewards[i].Chance + cumulativeList[i - 1]);
                    }
                    Random r = new Random();
                    int randomNumber = r.Next(1, cumulativeList.Last());
                    for (int i = 0; i < cumulativeList.Count; i++)
                    {
                        if (cumulativeList[i] >= randomNumber)
                        {
                            _inventoryAccess.AddEquipment(characterId, equipmentRewards[i].EquipmentId);
                            return equipmentRewards[i].Equipment;
                        }
                    }
                }
            }
            return null;
        }

        public bool QuestCompleted()
        {
            return _questAccess.HasCompletedQuest(_characterInfo.GetCharacterId());
        }
    }
}
