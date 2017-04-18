using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Source
{
    public class Enemy: Mobs
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int MDmg { get; set; }
        public int RewardExp { get; set; }
        public int RewardG { get; set; }
        public List<LootItem> RewardItem { get; set; }

        public Enemy(int id, string name, int earnexp, int earngold, int mdmg, int mhp, int chp ): base (mhp, chp)
        {
            ID = id;
            Name = name;
            MDmg = mdmg;
            RewardExp = earnexp;
            RewardG = earngold;
            RewardItem = new List<LootItem>();
        }
    }
}
