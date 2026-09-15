using GamePrototype.Utils;

namespace GamePrototype.Items.EquipItems
{
    public abstract class Weapon : EquipItem
    {
        public Weapon(uint damage, uint durability, string name) : base(durability, name) => Damage = damage;

        public abstract uint Damage { get;  set; }

        public override EquipSlot Slot => EquipSlot.Weapon;

        public override void Repair(uint delta)
        {
          base.Repair(delta);
        }
    }
}
