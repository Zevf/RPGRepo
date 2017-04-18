using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This holds the item the player will get for a quest.
namespace RPG_Source
{
    public class QuestCompleteItem
    {
        public Item Description { get; set; }
        public int Amount { get; set; }

        public QuestCompleteItem(Item description, int amount)
        {
            Description = description;
            Amount = amount;
        }
    }
}
