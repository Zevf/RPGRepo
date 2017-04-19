using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//The player's stuff. Would be hard to keep track of everything if this wasn't here.
namespace RPG_Source
{
    public class Player: Mobs
    {
        public int Gold { get; set; }
        public int Exp { get; private set; }
        public int Lvl
        {
           get { return ((Exp / 10) + 1); }
        }
        public List<InventoryItem> Inventory { get; set; }
        public List<PlayerQuest> QuestLog { get; set; }
        public Location CurrentLocal { get; set; }

        //contructor for player
        public Player(int mhp, int chp, int gold, int exp): base(mhp,chp)
        {
            Gold = gold;
            Exp = exp;
            Inventory = new List<InventoryItem>();
            QuestLog = new List<PlayerQuest>();
        }

        //level up stuff is here
        public void LevelUp(int levelUp)
        {
            Exp += levelUp;
            MHP = ((Lvl * 2)+ 10);
        }
        //function for checking if player has key items for entering restricted locations
        public bool HasKeyItem(Location location)
        {
            if (location.KeyItem == null)
            {
                return true;
            }

            foreach (InventoryItem i in Inventory)
            {
                if (i.Description.ID == location.KeyItem.ID)
                {
                    return true;
                }
            }

            return false;
        }

        //Chects if player has a quest in the location
        public bool HasThisQuest(Quest quest)
        {
            foreach (PlayerQuest playerQuest in QuestLog)
            {
                if (playerQuest.Description.ID == quest.ID)
                {
                    return true;
                }
            }

            return false;
        }

        //checks if quest is completed
        public bool CompletedThisQuest(Quest quest)
        {
            foreach (PlayerQuest playerQuest in QuestLog)
            {
                if (playerQuest.Description.ID == quest.ID)
                {
                    return playerQuest.IsComplete;
                }
            }

            return false;
        }

        public bool HasAllQuestCompletionItems(Quest quest)
        {
            // See if the player has all the items needed to complete the quest here
            foreach (QuestCompleteItem qci in quest.QuestFinishedItem)
            {
                bool foundItemInPlayersInventory = false;

                // Check each item in the player's inventory, to see if they have it, and enough of it
                foreach (InventoryItem i in Inventory)
                {
                    if (i.Description.ID == qci.Description.ID) 
                    {
                        foundItemInPlayersInventory = true;

                        if (i.Amount < qci.Amount) 
                        {
                            return false;
                        }
                    }
                }

                // The player does not have any of this quest completion item in their inventory
                if (!foundItemInPlayersInventory)
                {
                    return false;
                }
            }
            return true;
        }

        public void RemoveQuestCompletionItems(Quest quest)
        {
            foreach (QuestCompleteItem qci in quest.QuestFinishedItem)
            {
                foreach (InventoryItem i in Inventory)
                {
                    if (i.Description.ID == qci.Description.ID)
                    {
                        // Subtract the quantity from the player's inventory that was needed to complete the quest
                        i.Amount -= qci.Amount;
                        break;
                    }
                }
            }
        }

        public void AddItemToInventory(Item itemToAdd)
        {
            foreach (InventoryItem i in Inventory)
            {
                if (i.Description.ID == itemToAdd.ID)
                {
                    // They have the item in their inventory, so increase the quantity by one
                    i.Amount++;

                    return; // We added the item, and are done, so get out of this function
                }
            }

            // They didn't have the item, so add it to their inventory, with a quantity of 1
            Inventory.Add(new InventoryItem(itemToAdd, 1));
        }

        public void MarkQuestCompleted(Quest quest)
        {
            // Find the quest in the player's quest list
            foreach (PlayerQuest pq in QuestLog)
            {
                if (pq.Description.ID == quest.ID)
                {
                    pq.IsComplete = true;
                    return; 
                }
            }
        }
    }
}
