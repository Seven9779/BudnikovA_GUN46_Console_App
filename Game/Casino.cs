namespace CasinoGame;
using SaveLoadSystem;
using DiceGame;
using BlackJackGame;

public class Casino : IGame
{
    private CasinoGameBase _casinoGameBase;

    private readonly FileSystemSaveLoadService _file =
        new FileSystemSaveLoadService("C:\\Users\\Администратор\\Desktop\\");

    private readonly BlackJack _blackJack;
    private readonly DiceGame _diceGame;
    private const long StartingMoney = 5000;

    private string _playerName;
    private long _moneyPlayer;
    private long _bet;


    private bool _endGame;


    public Casino()
    {
        _blackJack = new BlackJack(52);
        _diceGame = new DiceGame(3, 1, 6);

        _blackJack.OnWin += PlayerWin;
        _blackJack.OnLoose += PlayerLoose;
        _blackJack.OnDraw += Draw;

        _diceGame.OnWin += PlayerWin;
        _diceGame.OnLoose += PlayerLoose;
        _diceGame.OnDraw += Draw;
    }

    public void StartGame()
    {
        Console.WriteLine("Hello Player! Welcome to Casino!");
        Console.WriteLine("finding profile...");
        string data = _file.LoadData("Casino");
        
        if (data == null)
        {
            CreateProfile();
        }

        else
        {
            FindingProfile(data);
        }

        while (!_endGame)
        {
            Console.WriteLine("Game started. Type exit to quit.");
            if (_moneyPlayer > int.MaxValue)
            {
                Console.WriteLine($"You wasted half of your bank money in casino’s bar. Your money {_moneyPlayer}");
                _moneyPlayer /= 2;
                SaveProfile();
            }

            if (_moneyPlayer <= 0)
            {
                Console.WriteLine("No money? Kicked");
                SaveProfile();
                return;
            }

            Console.WriteLine("Choose Game. 1 - BlackJack, 2 - Dice");
            string input = Console.ReadLine();
            if (HandleExit(input)) return;

            switch (input)
            {
                case "1":
                    _casinoGameBase = _blackJack;
                    break;
                case "2":
                    _casinoGameBase = _diceGame;
                    break;
                default:
                    Console.WriteLine("Invalid game choice");
                    continue;
            }

            Console.WriteLine("Choose Bet");
            input = Console.ReadLine();
            if (HandleExit(input)) return;

            if (long.TryParse(input, out _bet))
            {
                if (_bet > 0 && _bet <= _moneyPlayer)
                {
                    _casinoGameBase.PlayGame();
                }

                else
                {
                    Console.WriteLine("Not enough money or minimum value not reached(1)");
                }
            }
        }
        
        SaveProfile();
    }

    private void PlayerWin()
    {
        long newMoney = _moneyPlayer + _bet;
        if (newMoney > int.MaxValue)
        {
            long remainder = newMoney - int.MaxValue;
            Console.WriteLine(
                $"You have bankrupted the casino! A new casino will be built here. Your remainder {remainder}");
            _moneyPlayer = int.MaxValue;
            SaveProfile();
            _endGame = true;
        }

        else
        {
            _moneyPlayer = newMoney;
            SaveProfile();
            Console.WriteLine($"You win!, your money {_moneyPlayer}");
        }
    }

    private void PlayerLoose()
    {
        _moneyPlayer -= _bet;
        SaveProfile();
        Console.WriteLine($"You loose, your money {_moneyPlayer}");
    }

    private void Draw()
    {
        SaveProfile();
        Console.WriteLine($"Draw, your money {_moneyPlayer}");
    }

    private void CreateProfile()
    {
        Console.WriteLine("No profile found");
        Console.WriteLine("Input your name");
        _playerName = Console.ReadLine();
        _moneyPlayer = StartingMoney;
        Console.WriteLine($"Your name {_playerName}, your money {_moneyPlayer}");
        _file.SaveData($"{_playerName}\n{_moneyPlayer}", "Casino");
    }

    private void FindingProfile(string data)
    {
        
        var values = data.Split('\n');
        if (values.Length != 2) 
        {
            Console.WriteLine("Invalid profile data. Please contact support");
            _endGame = true;
            return;
        }
        _playerName = values[0];
        if (!long.TryParse(values[1], out _moneyPlayer))
        {
            Console.WriteLine("Invalid profile data. Please contact support");
            _endGame = true;
            return;
        }

        Console.WriteLine($"Welcome {_playerName} your money {_moneyPlayer}");
    }

    private void SaveProfile()
    {
        _file.SaveData($"{_playerName}\n{_moneyPlayer}", "Casino");
    }

    private bool HandleExit(string input)
    {
        if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine($"Goodbye {_playerName}");
            SaveProfile();
            return true;
        }

        return false;
    }
}