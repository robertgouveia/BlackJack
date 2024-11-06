using BlackJack.Business.Contracts;
using BlackJack.Business.Enums;
using BlackJack.Business.Models.Extensions;
using BlackJack.Business.Models.Faces;
using BlackJack.Business.Models.Suits;
using MoreLinq.Extensions;

namespace BlackJack.Business.Models;

public class Deck
{
    public CardList Cards
    {
        get => _cards;
        set => _cards = value;
    }

    private CardList _cards { get; set; }

    public Deck()
    {
        _cards = [];
        GenerateDeck();
    }

    private void GenerateDeck()
    {
        foreach (SuitType suit in Enum.GetValues(typeof(SuitType)))
        {
            ISuit instance;
            switch (suit)
            {
                case SuitType.Club:
                    instance = new Club();
                    break;
                case SuitType.Diamond:
                    instance = new Diamond();
                    break;
                case SuitType.Heart:
                    instance = new Heart();
                    break;
                case SuitType.Spade:
                    instance = new Spade();
                    break;
                default:
                    throw new Exception("Failure to generate suit");
            }

            var cards = GenerateBySuit(instance);

            if (cards is null || Cards is null) throw new NullReferenceException("Cards generated returned null");
            
            Cards.AddRange(cards);
        }
    }

    private CardList GenerateBySuit(ISuit suit)
    {
        var cards = new CardList();
        for (int i = 2; i < 11; i++)
        {
            var card = new Card(suit, i);
            cards.Add(card);
        }

        foreach (FaceType face in Enum.GetValues(typeof(FaceType)))
        {
            IFace faceInstance;
            switch (face)
            {
                case FaceType.Ace:
                    faceInstance = new Ace();
                    break;
                case FaceType.Jack:
                    faceInstance = new Jack();
                    break;
                case FaceType.King:
                    faceInstance = new King();
                    break;
                case FaceType.Queen:
                    faceInstance = new Queen();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(FaceType), "Is not a valid face type");
            }

            var card = new Card(suit, faceInstance);
            cards.Add(card);
        }

        return cards;
    }

    public void ShuffleDeck()
    {
        Cards = new CardList(Cards.Shuffle().ToList());
    }

    public override string ToString() => $"Deck: {Cards.Count} card's in the deck";
}