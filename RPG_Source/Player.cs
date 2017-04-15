using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Source
{
    public class Player: Mobs
    {
        public int Gold { get; set; }
        public int Exp { get; set; }
        public int Lvl { get; set; }

        public Player(int mhp, int chp, int gold, int exp, int lvl): base(mhp,chp)
        {
            Gold = gold;
            Exp = exp;
            Lvl = lvl;
        }
    }
}
