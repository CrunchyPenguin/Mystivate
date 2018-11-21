using System;
using System.Collections.Generic;
using System.Text;

namespace Mystivate.Models
{
    public class QuestModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int Health { get; set; }
        public int CoinReward { get; set; }
        public int RecLevel { get; set; }
    }
}