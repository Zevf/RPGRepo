﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Source
{
    public class Quest
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } 
        public int GoldReward { get; set; }
        public int ExpReward { get; set; }

        public Quest(int id, string name, string description, int earngold, int earmexp )
        {
            ID = id;
            Name = name;
            Description = description;
            GoldReward = earngold;
            ExpReward = earmexp;
        }
    }
}
