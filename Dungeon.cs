using Rooms;
using Units;
using Weapons;

namespace Dungeons
{
    public class Dungeon
    {
        Room[] rooms;

        public Dungeon() 
        {
            rooms = new Room[]
            {
                new Room(new Unit("Archer"), new Weapon("Bow")),
                new Room(new Unit("Mage"), new Weapon("Staff")),
                new Room(new Unit("Warrior"), new Weapon("Sword"))
            };
        }


        public void ShowRooms() 
        {
            for (int i = 0; i < rooms.Length; i++) // поле типа Room[]
            {
                var room = rooms[i];
                Console.WriteLine("Unit of room " + room.unit.Name);
                Console.WriteLine("Weapon of room " + room.weapon.Name);
                Console.WriteLine("—");
            }
        }
    }
}
