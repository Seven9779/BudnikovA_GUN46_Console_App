using GamePrototype.Utils;


namespace GamePrototype.Items.EquipItems;

public class DarkHelmet : Armour
{
    public DarkHelmet(uint defence, uint durability, string name) : base(defence, durability, name)
    {
    }

    public override uint Defence { get; set; }
    
    public override EquipSlot Slot => EquipSlot.Helmet;

}