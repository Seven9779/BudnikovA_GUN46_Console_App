using GamePrototype.Combat;
using GamePrototype.Dungeon;
using GamePrototype.Items.EquipItems;
using GamePrototype.Units;
using GamePrototype.Utils;

namespace GamePrototype.Game
{
    public sealed class GameLoop
    {
        private Player _player;
        private DungeonRoom _dungeon;
        private readonly CombatManager _combatManager = new CombatManager();
        
        public void StartGame() 
        {
            Initialize();
            Console.WriteLine("Entering the dungeon");
            StartGameLoop();
        }

        #region Game Loop

        private void Initialize()
        {
            Console.WriteLine("Welcome, player!");
            Console.WriteLine("Enter your name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter your difficulty");
            Console.WriteLine($"Enter difficulty {Difficulty.Easy} or {Difficulty.Hard}");
            string difficulty = Console.ReadLine();
          
            UnitFactory factory;
            DungeonBuilder builder;
            
            switch (difficulty.ToLowerInvariant())
            {
                case "easy":
                    factory = new UnitFactoryEasy();
                    builder = new DungeonBuilderEasy();
                    _player = factory.CreatePlayer(name);
                    factory.CreateGoblinEnemy();
                    _dungeon = builder.BuildDungeon();
                    break;
                case "hard":
                    factory = new UnitFactoryHard();
                    builder = new DungeonBuilderHard();
                    _player = factory.CreatePlayer(name);
                    factory.CreateGoblinEnemy();
                    _dungeon = builder.BuildDungeon();
                    break;
            }
            
           
            Console.WriteLine($"Hello {_player.Name}");
            Console.WriteLine($"Enter Helmet 1. for {GameConstants.DarkHelmet} or 2. for {GameConstants.WhiteHelmet} ");
            string helmet = Console.ReadLine();
            if (UInt32.TryParse(helmet, out uint helmetNumber))
            {
                switch (helmetNumber)
                {
                    case 1:
                        DarkHelmet darkHelmet = new DarkHelmet(10, 10, GameConstants.DarkHelmet);
                        _player.EquipItemMethod(darkHelmet);
                        break;

                    case 2:
                        WhiteHelmet whiteHelmet = new WhiteHelmet(10, 10, GameConstants.WhiteHelmet);
                        _player.EquipItemMethod(whiteHelmet);
                        break;
                        
                }
            }
        }

        private void StartGameLoop()
        {
            var currentRoom = _dungeon;
            
            while (currentRoom.IsFinal == false) 
            {
                StartRoomEncounter(currentRoom, out var success);
                if (!success) 
                {
                    Console.WriteLine("Game over!");
                    return;
                }
                DisplayRouteOptions(currentRoom);
                while (true) 
                {
                    if (Enum.TryParse<Direction>(Console.ReadLine(), out var direction) ) 
                    {
                        currentRoom = currentRoom.Rooms[direction];
                        break;
                    }
                    else 
                    {
                        Console.WriteLine("Wrong direction!");
                    }
                }
            }
            Console.WriteLine($"Congratulations, {_player.Name}");
            Console.WriteLine("Result: ");
            Console.WriteLine(_player.ToString());
        }

        private void StartRoomEncounter(DungeonRoom currentRoom, out bool success)
        {
            success = true;
            if (currentRoom.Loot != null) 
            {
                _player.AddItemToInventory(currentRoom.Loot);
            }
            if (currentRoom.Enemy != null) 
            {
                if (_combatManager.StartCombat(_player, currentRoom.Enemy) == _player)
                {
                    _player.HandleCombatComplete();
                    LootEnemy(currentRoom.Enemy);
                }
                else 
                {
                    success = false;
                }
            }

            void LootEnemy(Unit enemy)
            {
                _player.AddItemsFromUnitToInventory(enemy);
            }
        }

        private void DisplayRouteOptions(DungeonRoom currentRoom)
        {
            Console.WriteLine("Where to go?");
            foreach (var room in currentRoom.Rooms)
            {
                Console.Write($"{room.Key} - {(int) room.Key}\t");
            }
        }

        
        #endregion
    }
}
