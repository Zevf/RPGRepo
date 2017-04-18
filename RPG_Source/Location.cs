using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Source
{
    public class Location
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Item KeyItem { get; set; }
        public Quest GetQuest { get; set; }
        public Enemy GetEnemy { get; set; }
        public Location ToNorth { get; set; }
        public Location ToEast { get; set; }
        public Location ToSouth { get; set; }
        public Location ToWest { get; set; }


        public Location(int id, string name, string description, Item keyItem = null, Quest getQuest = null, Enemy getEnemy = null)
        {
            ID = id;
            Name = name;
            Description = description;
            KeyItem = keyItem;
            GetEnemy = getEnemy;
            GetQuest = getQuest;
        }
    }
}
