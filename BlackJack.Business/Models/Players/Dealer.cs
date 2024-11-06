using BlackJack.Business.Contracts;
using BlackJack.Business.Models.Extensions;
using BlackJack.Business.Models.Suits;
using MoreLinq;

namespace BlackJack.Business.Models.Players;

public class Dealer : Hand, IGiveable
{
    public Deck Deck => _deck;
    private Deck _deck { get; }

    public Dealer()
    {
        _deck = new Deck();
        _deck.ShuffleDeck();
    } 
    
    public void GiveCard(IGiveable hand)
    {
        var card = _deck.Cards[^1];
        hand.AddCard(card);
        _deck.Cards.RemoveLast();
    }

    public void AddCard(Card card)
    {
        _cards.Add(card);
    }
}