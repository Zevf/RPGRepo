using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//How am I gonna do damage without a weapon?
namespace RPG_Source
{
    public class Weapon : Item
    {
        public int MaxDmg { get; set; }
        public int MinDmg { get; set; }

        public Weapon(int id, int maxdmg, int mindmg, string name, string names) : base (id,name,names)
        {
            MaxDmg = maxdmg;
            MinDmg = mindmg;
        }
    }
}
