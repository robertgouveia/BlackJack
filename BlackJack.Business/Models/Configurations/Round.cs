using BlackJack.Business.Enums;
using BlackJack.Business.Models.Players;

namespace BlackJack.Business.Models.Configurations;

public class Round
{
    public int Number => _number;
    private GameState _state { get; set; } = GameState.Pending;
    private int _number { get; set; }
    private Hand? _winner { get; set; } = null;
    private Result? _result { get; set; } = null;

    public GameState State
    {
        get => _state;
        set
        {
            if (value is GameState.Complete)
            {
                if (_winner is null) throw new NullReferenceException("Winner is not present");
                _result = new Result(Number, _winner);
                _state = value;
                return;
            }

            if (value is not GameState.Draw) throw new Exception("Update was not successful");
            
            _result = new Result(Number);
            _state = value;
        }
    }

    public Round(int number)
    {
        _number = number;
    }

    public void Update(GameState state) => State = state;

    public void Update(GameState state, Hand hand)
    {
        if (state is not GameState.Complete) throw new ArgumentOutOfRangeException(nameof(GameState), "Game state must be of type Win");
        
        _winner = hand;
        State = GameState.Complete;
    }

    public Result? Result => _result;
}