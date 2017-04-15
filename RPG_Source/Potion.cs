using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Source
{
    public class Potion : Item
    {
        public int Heal { get; set; }

        public Potion(int id, string name, string amount, int heal) : base(id,name,amount)
        {
            Heal = heal;
        }
    }
}
