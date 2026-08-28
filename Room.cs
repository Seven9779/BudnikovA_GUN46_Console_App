using Units;
using Weapons;

namespace Rooms
{
    public struct Room
    {
        public Unit unit;
        public Weapon weapon;


        public Room(Unit unit, Weapon weapon)
        {
            this.unit = unit;
            this.weapon = weapon;
        }
    }
}
