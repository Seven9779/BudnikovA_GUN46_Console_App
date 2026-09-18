using GamePrototype.Items.EconomicItems;
using GamePrototype.Items.EquipItems;
using GamePrototype.Utils;
using System.Text;

namespace GamePrototype.Units
{
    public sealed class Player : Unit
    {
        private readonly Dictionary<EquipSlot, EquipItem> _equipment = new();

        public Player(string name, uint health, uint maxHealth, uint baseDamage) : base(name, health, maxHealth,
            baseDamage)
        {
        }

        public void TryEquip(EquipItem item)
        {
            if (_equipment.TryGetValue(item.Slot, out var oldItem) && oldItem.Name != item.Name)
            {
                Console.WriteLine($"Do you replace {oldItem.Name} on {item.Name}?\nyes/no");
                while (true)
                {
                    string input = Console.ReadLine();
                    switch (input.ToLowerInvariant())
                    {
                        case "yes":
                            Console.WriteLine($"Equipment replaced: {oldItem.Name} on {item.Name}");
                            _equipment[item.Slot] = item;
                            Inventory.TryAdd(oldItem);
                            return;
                        case "no":
                            Console.WriteLine($"Equipment wasn't replaced");
                            return;
                        default:
                            Console.WriteLine($"{input} is not right command");
                            break;
                    }
                }

                
                return;
            }
            else
            {
                Console.WriteLine($"Already Equipped: {item.Name}");
                return;
            }
        }

        public override uint GetUnitDamage()
        {
            if (_equipment.TryGetValue(EquipSlot.Weapon, out var item) && item is Weapon weapon)
            {
                weapon.ReduceDurability(1);
                return BaseDamage + weapon.Damage;
            }

            return BaseDamage;
        }

        public override void HandleCombatComplete()
        {
            var items = Inventory.Items;
            for (int i = items.Count - 1; i >= 0; i--)
            {
                if (items[i] is EconomicItem economicItem)
                {
                    UseEconomicItem(economicItem);
                    Inventory.TryRemove(items[i]);
                }
            }
        }

        public override void AddItemToInventory(Item item)
        {
            if (item is EquipItem equipItem)
            {
                if (!_equipment.TryGetValue(equipItem.Slot, out var oldItem))
                {
                    _equipment.Add(equipItem.Slot, equipItem);
                    Console.WriteLine($"{item.Name} was equipped");
                    return;
                }

                TryEquip(equipItem);
                return;
            }

            base.AddItemToInventory(item);
        }

        private void UseEconomicItem(EconomicItem economicItem)
        {
            if (economicItem is HealthPotion healthPotion)
            {
                if (Health + healthPotion.HealthRestore >= MaxHealth)
                {
                    Health = MaxHealth;
                }

                else
                {
                    Health += healthPotion.HealthRestore;
                }
            }

            if (economicItem is Grindstone)
            {
                if (_equipment.TryGetValue(EquipSlot.Weapon, out var item) && item is Weapon weapon)
                {
                    weapon.Repair(1);
                }
            }
        }

        protected override uint CalculateAppliedDamage(uint damage)
        {
            if (_equipment.TryGetValue(EquipSlot.Armour, out var item1) && item1 is Armour armour)
            {
                damage -= (uint)(damage * (armour.Defence / 100f));
                armour.ReduceDurability(1);
            }
            
            
            if (_equipment.TryGetValue(EquipSlot.Helmet, out var item2) && item2 is Helmet helmet)
            {
                damage -= (uint)(damage * (helmet.Defence / 100f));
                helmet.ReduceDurability(1);
            }

            return damage;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine(Name);
            builder.AppendLine($"Health {Health}/{MaxHealth}");
            builder.AppendLine("Loot:");
            var items = Inventory.Items;
            for (int i = 0; i < items.Count; i++)
            {
                builder.AppendLine($"[{items[i].Name}] : {items[i].Amount}");
            }

            return builder.ToString();
        }
    }
}