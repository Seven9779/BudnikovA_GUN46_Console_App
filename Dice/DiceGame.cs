using CasinoGame;

namespace DiceGame;

public class DiceGame : CasinoGameBase
{
    private readonly List<Dice> _list = new List<Dice>();
    private int _min;
    private int _max;
    private int _countDice;

    public DiceGame(int countDice, int min, int max)
    {
        if (countDice < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(countDice),"Count of dice must be greater than 0");
        }

        _min = min;
        _max = max;
        _countDice = countDice;
        FactoryMethod();
    }

    protected override void FactoryMethod()
    {
        for (int i = 0; i < _countDice; i++)
        {
            _list.Add(new Dice(_min, _max));
        }
    }

    public override void PlayGame()
    {
        int playerScoreSum = 0;
        int enemyScoreSum = 0;
        
        for (int i = 0; i < _countDice; i++)
        {
            int playerScore = 0;
            int enemyScore = 0;
            
            playerScore = _list[i].Number;
            Console.WriteLine($"Player throw dice {playerScore}");
            playerScoreSum += playerScore;

            enemyScore = _list[i].Number;
            Console.WriteLine($"Enemy throw dice {enemyScore}");
            enemyScoreSum += enemyScore;
        }

        DetermineResult(playerScoreSum, enemyScoreSum);
    }

    private void DetermineResult(int playerScore, int enemyScore)
    {
        if (playerScore == enemyScore)
        {
            OnDrawInvoke();
            Console.WriteLine($"Player Score - {playerScore} and Enemy Score {enemyScore}");
        }

        if (playerScore > enemyScore)
        {
            OnWinInvoke();
            Console.WriteLine($"Player Score - {playerScore} and Enemy Score {enemyScore}");
        }

        if (playerScore < enemyScore)
        {
            OnLooseInvoke();
            Console.WriteLine($"Player Score - {playerScore} and Enemy Score {enemyScore}");
        }
    }
    
}