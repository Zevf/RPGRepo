using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Lets the program use the RPG_Source files. 
using RPG_Source;
namespace RPGSKELETON
{
    public partial class UI : Form
    {
        private Player _player;
        private Enemy _currentEnemy;



        public UI()
        {
            InitializeComponent();

            _player = new Player(10, 10, 20, 0, 1);
            MoveTo(World.LocationByID(World.LOCATION_ID_HOME));
            _player.Inventory.Add(new InventoryItem(World.ItemByID(World.ITEM_ID_WOODEN_SWORD), 1));

            HPlabel.Text = _player.CHP.ToString();
            Goldlabel.Text = _player.Gold.ToString();
            EXPlabel.Text = _player.Exp.ToString();
            LevelLable.Text = _player.Lvl.ToString();
        }

        private void buttonUseWeapon_Click(object sender, EventArgs e)
        {

        }

        private void buttonNorth_Click(object sender, EventArgs e)
        {
            MoveTo(_player.CurrentLocal.ToNorth);
        }

        private void buttonWest_Click(object sender, EventArgs e)
        {
            MoveTo(_player.CurrentLocal.ToWest);
        }

        private void buttonSouth_Click(object sender, EventArgs e)
        {
            MoveTo(_player.CurrentLocal.ToSouth);
        }

        private void buttonEast_Click(object sender, EventArgs e)
        {
            MoveTo(_player.CurrentLocal.ToEast);
        }

        private void buttonUsePotion_Click(object sender, EventArgs e)
        {

        }

        private void MoveTo(Location newLocation)
        {
            //Does the location have any required items
            if (!_player.HasKeyItem(newLocation))
            {
                richTextBoxMessage.Text += "You must have a " + newLocation.KeyItem.Name + " to enter this location." + Environment.NewLine;
                return;
            }
            
            // Update the player's current location
            _player.CurrentLocal = newLocation;

            // Show/hide available movement buttons
            buttonNorth.Visible = (newLocation.ToNorth != null);
            buttonEast.Visible = (newLocation.ToEast != null);
            buttonSouth.Visible = (newLocation.ToSouth != null);
            buttonWest.Visible = (newLocation.ToWest != null);

            // Display current location name and description
            richTextBoxLocal.Text = newLocation.Name + Environment.NewLine;
            richTextBoxLocal.Text += newLocation.Description + Environment.NewLine;

            // Completely heal the player
            _player.CHP = _player.MHP;

            // Update Hit Points in UI
            HPlabel.Text = _player.CHP.ToString();

            // Does the location have a quest?
            if (newLocation.GetQuest != null)
            {
                // See if the player already has the quest, and if they've completed it
                bool playerAlreadyHasQuest = _player.HasThisQuest(newLocation.GetQuest);
                bool playerAlreadyCompletedQuest = _player.CompletedThisQuest(newLocation.GetQuest);

                // See if the player already has the quest
                if (playerAlreadyHasQuest)
                {
                    // If the player has not completed the quest yet
                    if (!playerAlreadyCompletedQuest)
                    {

                        // See if the player has all the items needed to complete the quest
                        bool playerHasAllItemsToCompleteQuest = _player.HasAllQuestCompletionItems(newLocation.GetQuest);

                        // The player has all items required to complete the quest
                        if (playerHasAllItemsToCompleteQuest)
                        {
                            // Display message
                            richTextBoxMessage.Text += Environment.NewLine;
                            richTextBoxMessage.Text += "You complete the '" + newLocation.GetQuest.Name + "' quest." + Environment.NewLine;

                            // Remove quest items from inventory
                            _player.RemoveQuestCompletionItems(newLocation.GetQuest);

                            // Give quest rewards
                            richTextBoxMessage.Text += "You receive: " + Environment.NewLine;
                            richTextBoxMessage.Text += newLocation.GetQuest.ExpReward.ToString() + " experience points" + Environment.NewLine;
                            richTextBoxMessage.Text += newLocation.GetQuest.GoldReward.ToString() + " gold" + Environment.NewLine;
                            richTextBoxMessage.Text += newLocation.GetQuest.ItemReward.Name + Environment.NewLine;
                            richTextBoxMessage.Text += Environment.NewLine;

                            _player.Exp += newLocation.GetQuest.ExpReward;
                            _player.Gold += newLocation.GetQuest.GoldReward;

                            // Add the reward item to the player's inventory
                            _player.AddItemToInventory(newLocation.GetQuest.ItemReward);

                            // Mark the quest as completed
                            _player.MarkQuestCompleted(newLocation.GetQuest);
                        }
                    }
                }

                else
                {
                    // The player does not already have the quest
                    richTextBoxMessage.Text += "You receive the " + newLocation.GetQuest.Name + " quest." + Environment.NewLine;
                    richTextBoxMessage.Text += newLocation.GetQuest.Description + Environment.NewLine;
                    richTextBoxMessage.Text += "To complete it, return with:" + Environment.NewLine;

                    foreach (QuestCompleteItem qci in newLocation.GetQuest.QuestFinishedItem)
                    {
                        if (qci.Amount == 1)
                        {
                            richTextBoxMessage.Text += qci.Amount.ToString() + " " + qci.Description.Name + Environment.NewLine;
                        }

                        else
                        {
                            richTextBoxMessage.Text += qci.Amount.ToString() + " " + qci.Description.Names + Environment.NewLine;
                        }
                    }

                    richTextBoxMessage.Text += Environment.NewLine;
                    
                    // Add the quest to the player's quest list
                    _player.QuestLog.Add(new PlayerQuest(newLocation.GetQuest));
                }
            }
            
            // Does the location have a enemy?
            if (newLocation.GetEnemy != null)
            {
                richTextBoxMessage.Text += "You see a " + newLocation.GetEnemy.Name + Environment.NewLine;
               
                // Make a new enemy, using the values from the standard enemy in the World.Monster list
                Enemy standardEnemy = World.EnemyByID(newLocation.GetEnemy.ID);
                _currentEnemy = new Enemy(standardEnemy.ID, standardEnemy.Name, standardEnemy.RewardExp,
                    standardEnemy.RewardG, standardEnemy.MDmg, standardEnemy.MHP, standardEnemy.CHP);

                foreach (LootItem lootItem in standardEnemy.RewardItem)
                {
                    _currentEnemy.RewardItem.Add(lootItem);
                }

                comboBoxWeapons.Visible = true;
                comboBoxPotions.Visible = true;
                buttonUseWeapon.Visible = true;         
                buttonUsePotion.Visible = true;
            }

            else
            {
                _currentEnemy = null;
                comboBoxWeapons.Visible = false;
                comboBoxPotions.Visible = false;
                buttonUseWeapon.Visible = false;
                buttonUsePotion.Visible = false;
            }

            // Refresh player's inventory list
            UpdateInventoryListInUI();

            // Refresh player's quest list
            UpdateQuestListInUI();

            // Refresh player's weapons combobox
            UpdateWeaponListInUI();
            
            // Refresh player's potions combobox
            UpdatePotionListInUI();
        }

        private void UpdateInventoryListInUI()
        {
            dataGridViewInventory.RowHeadersVisible = false;

            dataGridViewInventory.ColumnCount = 2;
            dataGridViewInventory.Columns[0].Name = "Name";
            dataGridViewInventory.Columns[0].Width = 197;
            dataGridViewInventory.Columns[1].Name = "Amount";

            dataGridViewInventory.Rows.Clear();

            foreach (InventoryItem inventoryItem in _player.Inventory)
            {
                if (inventoryItem.Amount > 0)
                {
                    dataGridViewInventory.Rows.Add(new[] { inventoryItem.Description.Name, inventoryItem.Amount.ToString() });
                }
            }
        }

        private void UpdateQuestListInUI()
        {
            dataGridViewQuest.RowHeadersVisible = false;

            dataGridViewQuest.ColumnCount = 2;
            dataGridViewQuest.Columns[0].Name = "Name";
            dataGridViewQuest.Columns[0].Width = 197;
            dataGridViewQuest.Columns[1].Name = "Done?";

            dataGridViewQuest.Rows.Clear();

            foreach (PlayerQuest playerQuest in _player.QuestLog)
            {
                dataGridViewQuest.Rows.Add(new[] { playerQuest.Description.Name, playerQuest.IsComplete.ToString() });
            }
        }

        private void UpdateWeaponListInUI()
        {
            List<Weapon> weapons = new List<Weapon>();

            foreach (InventoryItem inventoryItem in _player.Inventory)
            {
                if (inventoryItem.Description is Weapon)
                {
                    if (inventoryItem.Amount > 0)
                    {
                        weapons.Add((Weapon)inventoryItem.Description);
                    }
                }
            }

            if (weapons.Count == 0)
            {
                // The player doesn't have any weapons, so hide the weapon combobox and "Use" button
                comboBoxWeapons.Visible = false;
                buttonUseWeapon.Visible = false;
            }
            else
            {
                comboBoxWeapons.DataSource = weapons;
                comboBoxWeapons.DisplayMember = "Name";
                comboBoxWeapons.ValueMember = "ID";

                comboBoxWeapons.SelectedIndex = 0;
            }
        }

        private void UpdatePotionListInUI()
        {
            List<Potion> healingPotions = new List<Potion>();

            foreach (InventoryItem inventoryItem in _player.Inventory)
            {
                if (inventoryItem.Description is Potion)
                {
                    if (inventoryItem.Amount > 0)
                    {
                        healingPotions.Add((Potion)inventoryItem.Description);
                    }
                }
            }

            if (healingPotions.Count == 0)
            {
                // The player doesn't have any potions, so hide the potion combobox and "Use" button
                comboBoxPotions.Visible = false;
                buttonUsePotion.Visible = false;
            }
            else
            {
                comboBoxPotions.DataSource = healingPotions;
                comboBoxPotions.DisplayMember = "Name";
                comboBoxPotions.ValueMember = "ID";

                comboBoxPotions.SelectedIndex = 0;
            }
        }
    }
}
