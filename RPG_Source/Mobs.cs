using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This is used to understand Inheritance by delcaring Max HP and Current HP in this class and calling it to both the Player and Enemy
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
