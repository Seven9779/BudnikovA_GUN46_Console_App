namespace DiceGame;

public class WrongDiceNumberException : Exception
{
    public WrongDiceNumberException(string message) : base(message)
    {
       
    }
}