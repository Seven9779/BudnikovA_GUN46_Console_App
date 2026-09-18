using GamePrototype.Dungeon;
using GamePrototype.Items.EconomicItems;

namespace GamePrototype.Utils
{
    public sealed class DungeonBuilderHard : DungeonBuilder
    {
        public DungeonBuilderHard(UnitFactory factory) : base(factory)
        {
        }

        public override DungeonRoom BuildDungeon()
        {
            var enter = new DungeonRoom("Enter");
            var monsterRoom = new DungeonRoom("Monster", _unitFactory.CreateGoblinEnemy());
            var monsterRoom2 = new DungeonRoom("Monster", _unitFactory.CreateGoblinEnemy());
            var emptyRoom = new DungeonRoom("Empty");
            var lootRoom = new DungeonRoom("Loot", new Gold());
            var lootStoneRoom = new DungeonRoom("Loot1", new Grindstone("Stone"));
            var finalRoom = new DungeonRoom("Final", new Grindstone("Stone1"));

            enter.TrySetDirection(Direction.Right, monsterRoom);
            enter.TrySetDirection(Direction.Left, emptyRoom);
            
            monsterRoom.TrySetDirection(Direction.Right, monsterRoom2);
            monsterRoom2.TrySetDirection(Direction.Left, finalRoom);
            
            emptyRoom.TrySetDirection(Direction.Forward, lootRoom);
            lootRoom.TrySetDirection(Direction.Left, finalRoom);
          
            

            return enter;
        }
    }
}