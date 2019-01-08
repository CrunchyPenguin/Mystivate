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
        private readonly ICharacterManager _characterManager;

        public QuestLogic(IQuestAccess questAccess, ICharacterInfo characterInfo, IInventoryAccess inventoryAccess, ICharacterManager characterManager)
        {
            _questAccess = questAccess;
            _characterInfo = characterInfo;
            _inventoryAccess = inventoryAccess;
            _characterManager = characterManager;
        }

        public QuestModel GetCurrentQuest()
        {
            Quest quest = _questAccess.GetCurrentQuest(_characterInfo.GetCharacterId());
            if(quest != null)
            {
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
            return null;
        }

        public void SelectQuest(int questInventoryId)
        {
            _questAccess.SetQuest(_characterInfo.GetCharacterId(), questInventoryId);
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

        public List<QuestInventory> GetQuestInventory()
        {
            return _questAccess.GetQuestInventory(_characterInfo.GetCharacterId());
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
                    int randomNumber = r.Next(1, 100);
                    for (int i = 0; i < cumulativeList.Count; i++)
                    {
                        if (cumulativeList[i] >= randomNumber)
                        {
                            if (!_inventoryAccess.GetEquipment(characterId).Any(e => e.EquipmentId == equipmentRewards[i].EquipmentId))
                            {
                                _inventoryAccess.AddEquipment(characterId, equipmentRewards[i].EquipmentId);
                                return equipmentRewards[i].Equipment;
                            }
                            else
                            {
                                _characterManager.AddCoins(200);
                                return null;
                            }
                        }
                    }
                }
            }
            _characterManager.AddCoins(200);
            return null;
        }

        public bool QuestCompleted()
        {
            return _questAccess.HasCompletedQuest(_characterInfo.GetCharacterId());
        }

        public void CancelQuest()
        {
            _questAccess.CancelQuest(_characterInfo.GetCharacterId());
        }
    }
}
