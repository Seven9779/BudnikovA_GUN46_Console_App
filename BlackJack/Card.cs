namespace BlackJackGame;

public struct Card
{
    
    public readonly CardSuit CardSuit {get;}
    public readonly CardRank CardRank {get;}

    public Card(CardSuit cardSuit, CardRank cardRank)
    {
        CardSuit = cardSuit;
        CardRank = cardRank;
    }
}