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

            _player = new Player(12, 12, 20, 0);
            MoveTo(World.LocationByID(World.LOCATION_ID_HOME));
            _player.Inventory.Add(new InventoryItem(World.ItemByID(World.ITEM_ID_WOODEN_SWORD), 1));

            HPlabel.Text = _player.CHP.ToString();
            Goldlabel.Text = _player.Gold.ToString();
            EXPlabel.Text = _player.Exp.ToString();
            LevelLable.Text = _player.Lvl.ToString();
        }

        private void buttonUseWeapon_Click(object sender, EventArgs e)
        {
            // Get the currently selected weapon from the cboWeapons ComboBox
            Weapon currentWeapon = (Weapon)comboBoxWeapons.SelectedItem;

            // Determine the amount of damage to do to the monster
            int damageToEnemy = RNG.NumberBetween(currentWeapon.MinDmg, currentWeapon.MaxDmg);

            // Apply the damage to the monster's CurrentHitPoints
            _currentEnemy.CHP -= damageToEnemy;

            // Display message
            richTextBoxMessage.Text += "You hit the " + _currentEnemy.Name + " for " + damageToEnemy.ToString() + " points." + Environment.NewLine;

            // Check if the monster is dead
            if (_currentEnemy.CHP <= 0)
            {
                // Monster is dead
                richTextBoxMessage.Text += Environment.NewLine;
                richTextBoxMessage.Text += "You defeated the " + _currentEnemy.Name + Environment.NewLine;

                // Give player experience points for killing the monster
                _player.LevelUp( _currentEnemy.RewardExp);
                richTextBoxMessage.Text += "You receive " + _currentEnemy.RewardExp.ToString() + " experience points" + Environment.NewLine;

                // Give player gold for killing the monster 
                _player.Gold += _currentEnemy.RewardG;
                richTextBoxMessage.Text += "You receive " + _currentEnemy.RewardG.ToString() + " gold" + Environment.NewLine;

                // Get random loot items from the monster
                List<InventoryItem> lootedItems = new List<InventoryItem>();

                // Add items to the lootedItems list, comparing a random number to the drop percentage
                foreach (LootItem lootItem in _currentEnemy.RewardItem)
                {
                    if (RNG.NumberBetween(1, 100) <= lootItem.DropRate)
                    {
                        lootedItems.Add(new InventoryItem(lootItem.Description, 1));
                    }
                }

                // If no items were randomly selected, then add the default loot item(s).
                if (lootedItems.Count == 0)
                {
                    foreach (LootItem lootItem in _currentEnemy.RewardItem)
                    {
                        if (lootItem.IsDefaultItem)
                        {
                            lootedItems.Add(new InventoryItem(lootItem.Description, 1));
                        }
                    }
                }

                // Add the looted items to the player's inventory
                foreach (InventoryItem inventoryItem in lootedItems)
                {
                    _player.AddItemToInventory(inventoryItem.Description);

                    if (inventoryItem.Amount == 1)
                    {
                        richTextBoxMessage.Text += "You loot " + inventoryItem.Amount.ToString() + " " + inventoryItem.Description.Name + Environment.NewLine;
                    }
                    else
                    {
                        richTextBoxMessage.Text += "You loot " + inventoryItem.Amount.ToString() + " " + inventoryItem.Description.Names + Environment.NewLine;
                    }
                }

                // Refresh player information and inventory controls
                HPlabel.Text = _player.CHP.ToString();
                Goldlabel.Text = _player.Gold.ToString();
                EXPlabel.Text = _player.Exp.ToString();
                LevelLable.Text = _player.Lvl.ToString();

                UpdateInventoryListInUI();
                UpdateWeaponListInUI();
                UpdatePotionListInUI();

                // Add a blank line to the messages box, just for appearance.
                richTextBoxMessage.Text += Environment.NewLine;

                // Move player to current location (to heal player and create a new monster to fight)
                MoveTo(_player.CurrentLocal);
            }
            else
            {
                // Monster is still alive

                // Determine the amount of damage the monster does to the player
                int damageToPlayer = RNG.NumberBetween(0, _currentEnemy.MDmg);

                // Display message
                richTextBoxMessage.Text += "The " + _currentEnemy.Name + " did " + damageToPlayer.ToString() + " points of damage." + Environment.NewLine;

                // Subtract damage from player
                _player.CHP -= damageToPlayer;

                // Refresh player data in UI
                HPlabel.Text = _player.CHP.ToString();

                if (_player.CHP <= 0)
                {
                    // Display message
                    richTextBoxMessage.Text += "The " + _currentEnemy.Name + " killed you." + Environment.NewLine;

                    // Move player to "Home"
                    MoveTo(World.LocationByID(World.LOCATION_ID_HOME));
                }
            }
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
            // Get the currently selected potion from the combobox
            Potion potion = (Potion)comboBoxPotions.SelectedItem;

            // Add healing amount to the player's current hit points
            _player.CHP = (_player.CHP + potion.Heal);

            // CurrentHitPoints cannot exceed player's MaximumHitPoints
            if (_player.CHP > _player.MHP)
            {
                _player.CHP = _player.MHP;
            }

            // Remove the potion from the player's inventory
            foreach (InventoryItem ii in _player.Inventory)
            {
                if (ii.Description.ID == potion.ID)
                {
                    ii.Amount--;
                    break;
                }
            }

            // Display message
            richTextBoxMessage.Text += "You drink a " + potion.Name + Environment.NewLine;

            // Monster gets their turn to attack

            // Determine the amount of damage the monster does to the player
            int damageToPlayer = RNG.NumberBetween(0, _currentEnemy.MDmg);

            // Display message
            richTextBoxMessage.Text += "The " + _currentEnemy.Name + " did " + damageToPlayer.ToString() + " points of damage." + Environment.NewLine;

            // Subtract damage from player
            _player.CHP -= damageToPlayer;

            if (_player.CHP <= 0)
            {
                // Display message
                richTextBoxMessage.Text += "The " + _currentEnemy.Name + " killed you." + Environment.NewLine;

                // Move player to "Home"
                MoveTo(World.LocationByID(World.LOCATION_ID_HOME));
            }

            // Refresh player data in UI
            HPlabel.Text = _player.CHP.ToString();
            UpdateInventoryListInUI();
            UpdatePotionListInUI();
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

                            _player.LevelUp(newLocation.GetQuest.ExpReward);
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

        private void richTextBoxMessage_TextChanged(object sender, EventArgs e)
        {
            richTextBoxMessage.SelectionStart = richTextBoxMessage.Text.Length;
            richTextBoxMessage.ScrollToCaret();
        }
    }
}
