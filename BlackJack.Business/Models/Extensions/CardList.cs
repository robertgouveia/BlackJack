namespace BlackJack.Business.Models.Extensions;

public class CardList : List<Card>
{
    public CardList() : base() { }
    public CardList(List<Card> cards) : base(cards) { }
    
    public override string ToString() => $"{Count} cards in the deck";

    public void Output()
    {
        foreach (Card card in this)
        {
            Console.WriteLine(card.ToString());
        }
    }
}