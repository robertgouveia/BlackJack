using BlackJack.Business.Contracts;
using BlackJack.Business.Enums;

namespace BlackJack.Business.Models.Faces;

public class Face : IFace
{
    private FaceType type { get; set; }
    private int rank { get; set; }

    public int Rank
    {
        get => rank;
        set
        {
            if (type is FaceType.Ace && value is 1 or 11) rank = value;
            else return;
        }
    }
    
    public FaceType Type
    {
        get => type;
        set
        {
            type = value;
            rank = type switch
            {
                FaceType.Jack => 11,
                FaceType.Queen => 12,
                FaceType.King => 13,
                FaceType.Ace => 1,
                _ => throw new ArgumentOutOfRangeException(nameof(type))
            };
        }
    }

    public Face(FaceType faceType)
    {
        Type = faceType;
    }

    public override string ToString() => Type.ToString();
}