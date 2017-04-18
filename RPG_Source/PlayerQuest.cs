using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Holds info of Quests the players has completed
namespace RPG_Source
{
    public class PlayerQuest
    {
        public Quest Description { get; set; }
        public bool IsComplete { get; set; }

        public PlayerQuest(Quest description)
        {
            Description = description;
            IsComplete = false;
        }
    }
}
