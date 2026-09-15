using GamePrototype.Units;
using GamePrototype.Items.EquipItems;

namespace GamePrototype.Utils;

public class UnitFactoryHard : UnitFactory
{
    public override Player CreatePlayer(string name)
    { 
        Player player = new Player(name, 25, 25, 4);
        player.AddItemToInventory(new Sword(5, 10, "Sword"));
        player.AddItemToInventory(new DarkBreastPlate(7, 10, "DarkBreastPlate"));
        return player;
    }

    public override Unit CreateGoblinEnemy() => new Goblin(GameConstants.Goblin, 30, 30, 5);
   
}