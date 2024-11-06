using BlackJack.Business.Contracts;

namespace BlackJack.Business.Models.Players;

public class Player : Hand, IGiveable
{
    public void AddCard(Card card)
    {
        _cards.Add(card);
    }
}