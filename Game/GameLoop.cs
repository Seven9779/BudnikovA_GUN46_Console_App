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
            
          
            UnitFactory factory;
            DungeonBuilder builder;

            while (true)
            {
                Console.WriteLine($"Enter difficulty {Difficulty.Easy} or {Difficulty.Hard}");
                string input = Console.ReadLine();
                if (Enum.TryParse<Difficulty>(input, true, out var difficulty))
                {
                    switch (difficulty)
                    {
                        case Difficulty.Easy:
                            factory = new UnitFactoryEasy();
                            builder = new DungeonBuilderEasy(factory);
                            Console.WriteLine("Difficulty - Easy");
                            break;
                        case Difficulty.Hard:
                            factory = new UnitFactoryHard();
                            builder = new DungeonBuilderHard(factory);
                            Console.WriteLine("Difficulty - Hard");
                            break;
                        default:
                            Console.WriteLine("Please choose right difficulty. Easy or Hard");
                            continue;
                    }

                    _player = factory.CreatePlayer(name);
                    _dungeon = builder.BuildDungeon();

                    break;
                }

                else
                {
                    Console.WriteLine("Please choose right difficulty. Easy or Hard");
                }
            }
            
            Console.WriteLine($"Hello {_player.Name}");
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
                    if (Enum.TryParse<Direction>(Console.ReadLine(), out var direction) && 
                        currentRoom.Rooms.ContainsKey(direction)) 
                    {
                        currentRoom = currentRoom.Rooms[direction];
                        break;
                    }
                    else 
                    {
                        Console.WriteLine("Wrong direction! ");
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
