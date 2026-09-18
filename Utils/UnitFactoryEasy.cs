using GamePrototype.Units;
using GamePrototype.Items.EconomicItems;
using GamePrototype.Items.EquipItems;

namespace GamePrototype.Utils;

public class UnitFactoryEasy : UnitFactory
{
    public override Player CreatePlayer(string name)
    { 
        Player player = new Player(name, 30, 30, 4);
        player.AddItemToInventory(new Sword(10, 20, GameConstants.Sword));
        player.AddItemToInventory(new DarkBreastPlate(20, 20, GameConstants.DarkBreastPlate));
        player.AddItemToInventory(new DarkHelmet(20, 20, GameConstants.DarkHelmet));
        player.AddItemToInventory(new Bow(20, 20, GameConstants.Bow));
        player.AddItemToInventory(new HealthPotion(GameConstants.HealthPotion));
        player.AddItemToInventory(new Grindstone(GameConstants.Grindstone));
        return player;
    }

    public override Unit CreateGoblinEnemy() => new Goblin(GameConstants.Goblin, 30, 30, 5);
   
}