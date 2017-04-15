using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Source
{
    public class Item
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Amount { get; set; }
        
        public Item(int id, string name, string amount)
        {
            ID = id;
            Name = name;
            Amount = amount;
        }
    }
}
