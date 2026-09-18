using GamePrototype.Units;
using GamePrototype.Items.EquipItems;

namespace GamePrototype.Utils;

public class UnitFactoryHard : UnitFactory
{
    public override Player CreatePlayer(string name)
    { 
        Player player = new Player(name, 25, 25, 4);
        player.AddItemToInventory(new Sword(5, 10, GameConstants.Sword));
        player.AddItemToInventory(new DarkBreastPlate(7, 10, GameConstants.DarkBreastPlate));
        return player;
    }

    public override Unit CreateGoblinEnemy() => new Goblin(GameConstants.Goblin, 40, 40, 7);
   
}