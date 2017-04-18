using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This holds info on the players inventory
namespace RPG_Source
{
    public class InventoryItem
    {
        public Item Description { get; set; }
        public int Amount { get; set; }

        public InventoryItem(Item description, int amount)
        {
            Description = description;
            Amount = amount;
        }
    }
}
