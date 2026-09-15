using GamePrototype.Utils;

namespace GamePrototype.Items.EquipItems
{
    public abstract class Armour : EquipItem
    {
        public Armour(uint defence, uint durability, string name) : base(durability, name) => Defence = defence;

        public abstract uint Defence { get; set; }

        public override EquipSlot Slot => EquipSlot.Armour;
    }
}
