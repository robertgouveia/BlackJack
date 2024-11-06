
# Blackjack Game

This is a blackjack card game written in C#




## How it works

```c#
public class GameManager
{
    private Game Game => _game;
    private List<Player> Players { get; }
    private Game _game { get; }
    private Dealer _dealer { get; }
    private ILogger _logger { get; }
    private IInput _input { get; }
    private string _lastRoundSummary { get; set; } = string.Empty;
}
```

A game manager will manage the game object and instantiate players along with the dealer.

I have allowed for an external logger and user input interface in case I would extend to API instead of just console.

```csharp
public class Game
{
    public List<Round> Rounds => _rounds;
    public int? CurrentRoundNumber => _currentRound?.Number;

    public bool Finished => Rounds[^1].Result is not null ;

    private Round? _currentRound
    {
        get
        {
            foreach (Round round in Rounds)
            {
                if (round.Result is null) return round;
            }

            return Finished ? null : Rounds[0];
        }
    }
    
    private List<Round> _rounds { get; set; } = [];
}
```
```csharp
public void NextRound(GameState state, Hand? hand)
```

The game keeps track of rounds and exposes certain attributes.

This project includes extending C#'s current data types:

```csharp
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
```
```csharp
public static class ListExtension
{
    public static void RemoveLast<T>(this List<T> list)
    {
        list.RemoveAt(list.Count - 1);
    }
}
```

And ofcourse takes advantage of Enums:

```csharp
public enum SuitType
{
    Heart,
    Club,
    Diamond,
    Spade
}
```
