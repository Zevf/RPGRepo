using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This will hold info on the loot table. 
namespace RPG_Source
{
    public class LootItem
    {
        public Item Description { get; set; }
        public int DropRate { get; set; }
        public bool IsDefaultItem { get; set; }

        public LootItem(Item description, int dropRate, bool isDefaultItem)
        {
            Description = description;
            DropRate = dropRate;
            IsDefaultItem = isDefaultItem;
        }
    }
}
