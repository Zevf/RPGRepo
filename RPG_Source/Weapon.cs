using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Source
{
    public class Weapon : Item
    {
        public int MaxDmg { get; set; }
        public int MinDmg { get; set; }

        public Weapon(int id, int maxdmg, int mindmg, string name, string amount) : base (id,name,amount)
        {
            MaxDmg = maxdmg;
            MinDmg = mindmg;
        }
    }
}
