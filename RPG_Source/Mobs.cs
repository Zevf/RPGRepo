using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Source
{
    public class Mobs
    {
        public int MHP { get; set; }
        public int CHP { get; set; }

        public Mobs(int mhp, int chp)
        {
            MHP = mhp;
            CHP = chp;
        }
    }
}
