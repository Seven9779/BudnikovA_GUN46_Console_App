using GamePrototype.Dungeon;
using GamePrototype.Items.EconomicItems;
namespace GamePrototype.Utils;

public abstract class DungeonBuilder
{
    public UnitFactory _unitFactory;
    public DungeonBuilder(UnitFactory factory)
    {
        _unitFactory = factory;
    }
    public abstract DungeonRoom BuildDungeon();
}