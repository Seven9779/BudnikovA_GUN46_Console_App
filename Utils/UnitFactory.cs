namespace GamePrototype.Utils;
using GamePrototype.Units;

public abstract class UnitFactory
{
    public abstract Player CreatePlayer(string name);
    public abstract Unit CreateGoblinEnemy();
}