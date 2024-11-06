using BlackJack.Business.Models.Extensions;

namespace BlackJack.Business.Models.Players;

public abstract class Hand
{
    public CardList Cards  => _cards;

    protected CardList _cards { get; private set; } = [];

    public int GetValue() => _cards.Sum(card => card.Rank);
    
    public void Reset() => _cards = [];
}