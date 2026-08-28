using Units;
using Weapons;
using Intervals;
using Dungeons;
using Rooms;

public class Program
{
    public static void Main(string[] args) 
    {
        Unit unit = new Unit();
        Console.WriteLine(unit.Name);

        Interval interval = new Interval(9,109);
        Console.WriteLine(interval.Get);

        Dungeon dungeon = new Dungeon();

        dungeon.ShowRooms();
    
    }
}


