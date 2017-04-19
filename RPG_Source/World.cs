using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Populates the world! This took way too long to understand. I shouldn't have made an RPG
namespace RPG_Source
{
    public static class World
    {
        //Makes lists to be filled by the constants bellow
        public static readonly List<Item> Items = new List<Item>();
        public static readonly List<Enemy> Enemies = new List<Enemy>();
        public static readonly List<Quest> Quests = new List<Quest>();
        public static readonly List<Location> Locations = new List<Location>();

        //Items are listed here.
        public const int ITEM_ID_WOODEN_SWORD = 1;
        public const int ITEM_ID_CLUB = 2;
        public const int ITEM_ID_SWORD = 3;
        public const int ITEM_ID_RTAIL = 4;
        public const int ITEM_ID_FUR = 5;
        public const int ITEM_ID_SNAKE_FANG = 6;
        public const int ITEM_ID_SNAKESKIN = 7;
        public const int ITEM_ID_SPIDER_FANG = 8;
        public const int ITEM_ID_SPIDER_SILK = 9;
        public const int ITEM_ID_POTION = 10;
        public const int ITEM_ID_PASS = 11;

        //Enemies are listed here
        public const int ENEMY_ID_RAT = 1;
        public const int ENEMY_ID_SNAKE = 2;
        public const int ENEMY_ID_GSPIDER = 3;

        //Quests are listed here
        public const int QUEST_ID_CLEAR_ALCHEMIST_GARDEN = 1;
        public const int QUEST_ID_CLEAR_FARMERS_FIELD = 2;

        //The world is listed here. You know like your house or the town?
        public const int LOCATION_ID_HOME = 1;
        public const int LOCATION_ID_TOWN_SQUARE = 2;
        public const int LOCATION_ID_GUARD_POST = 3;
        public const int LOCATION_ID_ALCHEMIST_HUT = 4;
        public const int LOCATION_ID_ALCHEMISTS_GARDEN = 5;
        public const int LOCATION_ID_FARMHOUSE = 6;
        public const int LOCATION_ID_FARM_FIELD = 7;
        public const int LOCATION_ID_BRIDGE = 8;
        public const int LOCATION_ID_SPIDER_FIELD = 9;

        //constructor that populates the word
        static World()
        {
            PopulateItems();
            PopulateEnemies();
            PopulateQuests();
            PopulateLocations();
        }

        //methods that are being used to populate the world, each named after items, Enemies, Quests, and Locals.
        private static void PopulateItems()
        {
            Items.Add(new Weapon(ITEM_ID_WOODEN_SWORD, 5, 0, "Wooden sword", "Wooden swords"));
            Items.Add(new Weapon(ITEM_ID_CLUB, 10, 3, "Club", "Clubs"));
            Items.Add(new Weapon(ITEM_ID_SWORD, 15, 10, "Steel Sword", "Steel Swords"));
            Items.Add(new Item(ITEM_ID_RTAIL, "Rat tail", "Rat tails"));
            Items.Add(new Item(ITEM_ID_FUR, "Piece of fur", "Clumps of fur"));
            Items.Add(new Item(ITEM_ID_SNAKE_FANG, "Snake fang", "Snake fangs"));
            Items.Add(new Item(ITEM_ID_SNAKESKIN, "Snakeskin", "Snakeskins"));
            Items.Add(new Potion(ITEM_ID_POTION, "Healing potion", "Healing potions", 5));
            Items.Add(new Item(ITEM_ID_SPIDER_FANG, "Spider fang", "Spider fangs"));
            Items.Add(new Item(ITEM_ID_SPIDER_SILK, "Spider silk", "Spider silks"));
            Items.Add(new Item(ITEM_ID_PASS, "Adventurer's pass", "Adventurer's passes"));
        }

        private static void PopulateEnemies()
        {
            Enemy rat = new Enemy(ENEMY_ID_RAT, "Rat", 3, 10, 5, 3, 3);
            rat.RewardItem.Add(new LootItem(ItemByID(ITEM_ID_RTAIL), 75, false));
            rat.RewardItem.Add(new LootItem(ItemByID(ITEM_ID_FUR), 75, true));

            Enemy snake = new Enemy(ENEMY_ID_SNAKE, "Snake", 3, 10, 5, 8, 8);
            snake.RewardItem.Add(new LootItem(ItemByID(ITEM_ID_SNAKE_FANG), 75, false));
            snake.RewardItem.Add(new LootItem(ItemByID(ITEM_ID_SNAKESKIN), 75, true));
            snake.RewardItem.Add(new LootItem(ItemByID(ITEM_ID_CLUB), 25, false));

            Enemy gSpider = new Enemy(ENEMY_ID_GSPIDER, "Giant spider", 5, 40, 20, 10, 10);
            gSpider.RewardItem.Add(new LootItem(ItemByID(ITEM_ID_SPIDER_FANG), 75, true));
            gSpider.RewardItem.Add(new LootItem(ItemByID(ITEM_ID_SPIDER_SILK), 25, false));

            Enemies.Add(rat);
            Enemies.Add(snake);
            Enemies.Add(gSpider);
        }

        private static void PopulateQuests()
        {
            Quest clearAlchemistGarden =
                new Quest(
                    QUEST_ID_CLEAR_ALCHEMIST_GARDEN,
                    "Clear the alchemist's garden",
                    "Kill rats in the alchemist's garden and bring back 3 rat tails. You will receive a healing potion and 10 gold pieces.", 20, 10);

            clearAlchemistGarden.QuestFinishedItem.Add(new QuestCompleteItem(ItemByID(ITEM_ID_RTAIL), 3));

            clearAlchemistGarden.ItemReward = ItemByID(ITEM_ID_POTION);

            Quest clearFarmersField =
                new Quest(
                    QUEST_ID_CLEAR_FARMERS_FIELD,
                    "Clear the farmer's field",
                    "Kill snakes in the farmer's field and bring back 3 snake fangs. You will receive an adventurer's pass and 20 gold pieces.", 20, 20);

            clearFarmersField.QuestFinishedItem.Add(new QuestCompleteItem(ItemByID(ITEM_ID_SNAKE_FANG), 3));

            clearFarmersField.ItemReward = ItemByID(ITEM_ID_PASS);

            Quests.Add(clearAlchemistGarden);
            Quests.Add(clearFarmersField);
        }

        private static void PopulateLocations()
        {
            // Create each location
            Location home = new Location(LOCATION_ID_HOME, "Home", "Your house. You really need to clean up the place.");

            Location townSquare = new Location(LOCATION_ID_TOWN_SQUARE, "Town square", "You see a fountain.");

            Location alchemistHut = new Location(LOCATION_ID_ALCHEMIST_HUT, "Alchemist's hut", "There are many strange plants on the shelves.");
            alchemistHut.GetQuest = QuestByID(QUEST_ID_CLEAR_ALCHEMIST_GARDEN);

            Location alchemistsGarden = new Location(LOCATION_ID_ALCHEMISTS_GARDEN, "Alchemist's garden", "Many plants are growing here.");
            alchemistsGarden.GetEnemy = EnemyByID(ENEMY_ID_RAT);

            Location farmhouse = new Location(LOCATION_ID_FARMHOUSE, "Farmhouse", "There is a small farmhouse, with a farmer in front.");
            farmhouse.GetQuest = QuestByID(QUEST_ID_CLEAR_FARMERS_FIELD);

            Location farmersField = new Location(LOCATION_ID_FARM_FIELD, "Farmer's field", "You see rows of vegetables growing here.");
            farmersField.GetEnemy = EnemyByID(ENEMY_ID_SNAKE);

            Location guardPost = new Location(LOCATION_ID_GUARD_POST, "Guard post", "There is a large, tough-looking guard here.", ItemByID(ITEM_ID_PASS));

            Location bridge = new Location(LOCATION_ID_BRIDGE, "Bridge", "A stone bridge crosses a wide river.");

            Location spiderField = new Location(LOCATION_ID_SPIDER_FIELD, "Forest", "You see spider webs covering covering the trees in this forest.");
            spiderField.GetEnemy = EnemyByID(ENEMY_ID_GSPIDER);

            // Links the locations together
            home.ToNorth = townSquare;

            townSquare.ToNorth = alchemistHut;
            townSquare.ToSouth = home;
            townSquare.ToEast = guardPost;
            townSquare.ToWest = farmhouse;

            farmhouse.ToEast = townSquare;
            farmhouse.ToWest = farmersField;

            farmersField.ToEast = farmhouse;

            alchemistHut.ToSouth = townSquare;
            alchemistHut.ToNorth = alchemistsGarden;

            alchemistsGarden.ToSouth = alchemistHut;

            guardPost.ToEast = spiderField;
            guardPost.ToWest = townSquare;

            bridge.ToWest = guardPost;
            bridge.ToEast = spiderField;

            spiderField.ToWest = guardPost;

            Locations.Add(home);
            Locations.Add(townSquare);
            Locations.Add(guardPost);
            Locations.Add(alchemistHut);
            Locations.Add(alchemistsGarden);
            Locations.Add(farmhouse);
            Locations.Add(farmersField);
            Locations.Add(bridge);
            Locations.Add(spiderField);
        }

        //function to return ids when called
        public static Item ItemByID(int id)
        {
            foreach (Item item in Items)
            {
                if (item.ID == id)
                {
                    return item;
                }
            }

            return null;
        }

        public static Enemy EnemyByID(int id)
        {
            foreach (Enemy enemy in Enemies)
            {
                if (enemy.ID == id)
                {
                    return enemy;
                }
            }

            return null;
        }

        public static Quest QuestByID(int id)
        {
            foreach (Quest quest in Quests)
            {
                if (quest.ID == id)
                {
                    return quest;
                }
            }

            return null;
        }

        public static Location LocationByID(int id)
        {
            foreach (Location location in Locations)
            {
                if (location.ID == id)
                {
                    return location;
                }
            }

            return null;
        }
    }
}
