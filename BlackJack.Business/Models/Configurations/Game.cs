using BlackJack.Business.Enums;
using BlackJack.Business.Models.Players;

namespace BlackJack.Business.Models.Configurations;

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

    public Game(int rounds)
    {
        for (int i = 0; i < rounds; i++)
        {
            _rounds.Add(new Round(i + 1));
        }
    }

    public void NextRound(GameState state, Hand? hand)
    {
        if (Finished) throw new Exception("Game has already finished");
        if (state == GameState.Pending) throw new ArgumentException("Game must be complete to move to next round");

        if (hand is null && state == GameState.Draw)
        {
            _currentRound!.Update(state);
            return;
        }

        if (hand is null || state != GameState.Complete)
            throw new AggregateException("Game cannot be complete without a winner");
        
        _currentRound!.Update(state, hand);
    }

    public override string ToString() 
        => $"Game:{(Finished ? " " : " Round " + CurrentRoundNumber + ", ")}{(Finished ? "Complete" : "Incomplete")}";

}