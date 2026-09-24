namespace DiceGame;

public struct Dice
{
    private int _min;
    private int _max;
    private Random _random = new Random();

    public Dice(int min, int max)
    {
        if (min < 1 || max < 1 || min >= max)
        {
            throw new WrongDiceNumberException($"Invalid input min - {min} and max - {max}. Valid min - 1, max - {int.MaxValue - 1}");
        }
        
        _min = min;
        _max = max;
        
    }

    public readonly int Number
    {
        get { return _random.Next(_min, _max + 1); }
    }
}