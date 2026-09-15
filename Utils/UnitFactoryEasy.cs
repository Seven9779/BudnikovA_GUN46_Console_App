using GamePrototype.Units;
using GamePrototype.Items.EconomicItems;
using GamePrototype.Items.EquipItems;

namespace GamePrototype.Utils;

public class UnitFactoryEasy : UnitFactory
{
    public override Player CreatePlayer(string name)
    { 
        Player player = new Player(name, 30, 30, 4);
        player.AddItemToInventory(new Sword(10, 20, "Sword"));
        player.AddItemToInventory(new DarkBreastPlate(20, 20, "DarkBreastPlate"));
        player.AddItemToInventory(new HealthPotion("Potion"));
        player.AddItemToInventory(new Grindstone("Grindstone"));
        return player;
    }

    public override Unit CreateGoblinEnemy() => new Goblin(GameConstants.Goblin, 30, 30, 5);
   
}