using BlackJack.Business.Contracts;
using BlackJack.Business.Enums;

namespace BlackJack.Business.Models.Suits;

public abstract class Suit : ISuit
{
    private SuitType Name { get; }

    protected Suit(SuitType name) => Name = name;
    
    public override string ToString() => Name.ToString();
}