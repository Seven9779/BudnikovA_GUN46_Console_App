namespace GamePrototype.Items.EquipItems;

public class Dart : Weapon
{
    public Dart(uint damage, uint durability, string name) : base(damage, durability, name)
    {
    }

    public override uint Damage { get; set; }
}