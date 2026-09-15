namespace GamePrototype.Items.EquipItems;

public class Bow : Weapon
{
    public Bow(uint damage, uint durability, string name) : base(damage, durability, name)
    {
    }

    public override uint Damage { get; set; }
}