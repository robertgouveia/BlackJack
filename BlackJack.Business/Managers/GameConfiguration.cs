namespace BlackJack.Business.Managers;

public class GameConfiguration
{
    public int Rounds
    {
        get => _rounds;
        private init
        {
            if (value < 1) throw new Exception("Game cannot have less than one round");
            _rounds = value;
        }
    }

    public int Players
    {
        get => _players;
        private init
        {
            if (value < 1) throw new Exception("Game cannot have less than one player");
            _players = value;
        }
    }
    
    private int _rounds { get; init; }
    private int _players { get; init; }

    public GameConfiguration(int rounds, int players)
    {
        Rounds = rounds;
        Players = players;
    }
}