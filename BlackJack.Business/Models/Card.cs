using BlackJack.Business.Contracts;
using BlackJack.Business.Models.Faces;

namespace BlackJack.Business.Models;

public class Card
{
    public ISuit Suit { get; set; }
    public IFace? Face { get; set; } = null;
    private int rank { get; set; }

    public int Rank
    {
        get
        {
            if (Face is null) return rank;
            return Face.Rank;
        }
        set
        {
            if (Face is not null)
            {
                Face.Rank = value;
                return;
            }
            if (value is < 13 and > 0) rank = value;
        }
    }

    public Card(ISuit suit, IFace face)
    {
        Suit = suit;
        Face = face;
        Rank = face.Rank;
    }

    public Card(ISuit suit, int rank)
    {
        Suit = suit;
        Rank = rank;
        Face = null;
    }

    public override string ToString() => Face is null ? $"Card: {Rank} of {Suit}'s" : $"Card: {Face} of {Suit}'s";
}