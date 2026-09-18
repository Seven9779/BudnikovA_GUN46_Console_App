using GamePrototype.Dungeon;
using GamePrototype.Items.EconomicItems;
using GamePrototype.Items.EquipItems;

namespace GamePrototype.Utils
{
    public sealed class DungeonBuilderEasy : DungeonBuilder
    {
        public DungeonBuilderEasy(UnitFactory factory) : base(factory)
        {
        }

        public override DungeonRoom BuildDungeon()
        {
            var enter = new DungeonRoom("Enter");
            var monsterRoom = new DungeonRoom("Monster", _unitFactory.CreateGoblinEnemy());
            var emptyRoom = new DungeonRoom("Empty");
            var lootRoom = new DungeonRoom("LootGold", new Gold());
            var lootHelmet = new DungeonRoom("LootHelmet", new WhiteHelmet(20,20, "WhiteHelmet"));
            var lootStoneRoom = new DungeonRoom("LootStone", new Grindstone("Stone"));
            var finalRoom = new DungeonRoom("Final", new Grindstone("Stone2"));

            enter.TrySetDirection(Direction.Right, monsterRoom);
            enter.TrySetDirection(Direction.Left, lootRoom);

            monsterRoom.TrySetDirection(Direction.Forward, lootStoneRoom);
            lootRoom.TrySetDirection(Direction.Right, lootHelmet);
            lootRoom.TrySetDirection(Direction.Left, lootHelmet);

            lootHelmet.TrySetDirection(Direction.Left, finalRoom);
            lootStoneRoom.TrySetDirection(Direction.Forward, finalRoom);
            return enter;
        }
    }
}