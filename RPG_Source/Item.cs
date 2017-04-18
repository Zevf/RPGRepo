using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Item details
namespace RPG_Source
{
    public class Item
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Names { get; set; }
        
        public Item(int id, string name, string names)
        {
            ID = id;
            Name = name;
            Names = names;
        }
    }
}
