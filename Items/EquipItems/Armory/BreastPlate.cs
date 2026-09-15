using GamePrototype.Utils;

namespace GamePrototype.Items.EquipItems;

    public class DarkBreastPlate : Armour
    {
        public DarkBreastPlate(uint defence, uint durability, string name) : base(defence, durability, name)
        {
        }

        public override uint Defence { get; set; }
        
        public override EquipSlot Slot => EquipSlot.Armour;
    }