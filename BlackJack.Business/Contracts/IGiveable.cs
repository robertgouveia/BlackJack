using BlackJack.Business.Models;

namespace BlackJack.Business.Contracts;

public interface IGiveable
{
    public void AddCard(Card card);
}