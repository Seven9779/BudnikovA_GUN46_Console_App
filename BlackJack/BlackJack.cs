using CasinoGame;


namespace BlackJackGame;

public class BlackJack : CasinoGameBase
{
    private readonly int _deckSize;
    private readonly Random _random = new Random();
    private readonly List<Card> _cards = new List<Card>();
    private Queue<Card> _deck = new Queue<Card>();
    
    public BlackJack(int deckSize)
    {
        if (deckSize < 4 || deckSize > 52)
        {
            throw new ArgumentOutOfRangeException(nameof(deckSize), "Deck size must be between 4 and 52");
        }
        _deckSize = deckSize;
        FactoryMethod();
    }

    protected override void FactoryMethod()
    {
        for (int i = 0; i < _deckSize; i++)
        {
            Card newCard = new Card((CardSuit)_random.Next(0, 4), (CardRank)_random.Next(2, 15));
            if (_cards.Any(card => card.CardSuit == newCard.CardSuit && card.CardRank == newCard.CardRank))
            {
                i--;
            }

            else
            {
                _cards.Add(newCard);
            }
        }
    }

    private int GenerateAnotherIndex(int from, int to) => _random.Next(from, to);

    private Queue<Card> Shuffle(List<Card> list)
    {
        if (null == list)
            throw new ArgumentNullException(nameof(list));


        for (int i = 0; i < list.Count - 1; i++)
        {
            int genCard = GenerateAnotherIndex(i, list.Count);
            (list[i], list[genCard]) = (list[genCard], list[i]);
        }

        return new Queue<Card>(list);
    }

    public override void PlayGame()
    {
        int playerScore = 0;
        int enemyScore = 0;
        List<Card> playerDeck = new List<Card>();
        List<Card> enemyDeck = new List<Card>();
        _deck = Shuffle(_cards);
        Card card;

        Console.WriteLine("Game started. Player gets 2 cards");
        playerDeck.Add(_deck.Dequeue());
        playerDeck.Add(_deck.Dequeue());
        playerScore = CalculateSumScore(playerDeck);

        Console.WriteLine($"Your Cards");
        Console.WriteLine(String.Join(" | ", playerDeck.Select(card => $"{card.CardSuit} {card.CardRank}")));
        
        enemyDeck.Add(_deck.Dequeue());
        enemyDeck.Add(_deck.Dequeue());

        enemyScore = CalculateSumScore(enemyDeck);

        Console.WriteLine("Enemy gets 2 cards");
        Console.WriteLine($"Enemy Cards");
        Console.WriteLine(String.Join(" | ", enemyDeck.Select(card => $"{card.CardSuit} {card.CardRank}")));

        while (playerScore < 21 && enemyScore < 21 && playerScore == enemyScore)
        {
            card = _deck.Dequeue();
            playerDeck.Add(card);
            playerScore = CalculateSumScore(playerDeck);
            Console.WriteLine($"Your Cards");
            Console.WriteLine(String.Join(" | ", playerDeck.Select(card => $"{card.CardSuit} {card.CardRank}")));


            card = _deck.Dequeue();
            enemyDeck.Add(card);
            enemyScore = CalculateSumScore(enemyDeck);
            Console.WriteLine($"Enemy Cards");
            Console.WriteLine(String.Join(" | ", enemyDeck.Select(card => $"{card.CardSuit} {card.CardRank}")));
        }

        DetermineResult(playerScore, enemyScore);
    }


    private void DetermineResult(int playerScore, int enemyScore)
    {
        if (playerScore > 21 && enemyScore > 21)
        {
            OnDrawInvoke();
        }

        else if (playerScore > 21)
        {
            OnLooseInvoke();
        }
        
        else if (enemyScore > 21)
        {
            OnWinInvoke();
        }
        
        else if (playerScore > enemyScore)
        {
            OnWinInvoke();
        }
        
        else if (playerScore < enemyScore)
        {
            OnLooseInvoke();
        }
        
        else
        {
            OnDrawInvoke();
        }
    }

    private int CalculateSumScore(List<Card> list)
    {
        int score = 0;
        int aces = 0;

        foreach (var card in list)
        {
            if ((int)card.CardRank < 14 && (int)card.CardRank > 10)
            {
                score += 10;
            }

            if ((int)card.CardRank <= 10)
            {
                score += (int)card.CardRank;
            }

            if (card.CardRank == CardRank.Ace)
            {
                aces++;
            }
        }

        for (int i = 0; i < aces; i++)
        {
            if (score + 11 > 21)
            {
                score += 1;
            }

            else
            {
                score += 11;
            }
        }

        return score;
    }
}