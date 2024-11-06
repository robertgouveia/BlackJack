using BlackJack.Business.Contracts;
using BlackJack.Business.Enums;
using BlackJack.Business.Models;
using BlackJack.Business.Models.Configurations;
using BlackJack.Business.Models.Players;

namespace BlackJack.Business.Managers;

public class GameManager
{
    private Game Game => _game;
    private List<Player> Players { get; }
    private Game _game { get; }
    private Dealer _dealer { get; }
    private ILogger _logger { get; }
    private IInput _input { get; }
    private string _lastRoundSummary { get; set; } = string.Empty;

    public GameManager(GameConfiguration gameConfiguration, ILogger logger, IInput input)
    {
        _logger = logger;
        _input = input;
        _game = new Game(gameConfiguration.Rounds);
        
        _logger.Log("Dealer has entered the game");
        _dealer = new Dealer();

        Players = [];
        for (int i = 0; i < gameConfiguration.Players; i++)
        {
            _logger.Log($"Player {i + 1} has entered the game");
            Players.Add(new Player());
        }

        foreach (Round round in Game.Rounds)
        {
            StartRound();
            foreach (var player in Players)
            {
                player.Reset();
            }
            _dealer.Reset();
        }
    }

    private void StartRound()
    {
        foreach (var player in Players)
        {
            _dealer.GiveCard(player);
            _dealer.GiveCard(player);
        }

        _logger.Log("Players have been dealt.");

        _dealer.GiveCard(_dealer);
        _dealer.GiveCard(_dealer);

        _logger.Log("Dealer has been dealt");
        PlayerInput();

        Player? topPlayer = null;
        foreach (Player player in Players)
        {
            if (player.GetValue() > 21) continue;
            
            topPlayer ??= player;

            if (player.GetValue() > topPlayer.GetValue()) topPlayer = player;
        }
        
        if (topPlayer is null)
        {
            _lastRoundSummary = "Dealer has won";
            Game.NextRound(GameState.Complete, _dealer);
            return;
        }
        
        if (_dealer.GetValue() > 21)
        {
            _lastRoundSummary = "Player has won";
            Game.NextRound(GameState.Complete, topPlayer);
            return;
        }

        if (_dealer.GetValue() > topPlayer.GetValue())
        {
            _lastRoundSummary = "Dealer has won";
            Game.NextRound(GameState.Complete, _dealer);
        }
        else if (_dealer.GetValue() == topPlayer.GetValue())
        {
            _lastRoundSummary = "Game has ended in a draw";
            Game.NextRound(GameState.Draw, null);
        }
        else
        {
            _lastRoundSummary = "Player has won";
            Game.NextRound(GameState.Complete, topPlayer);
        }
    }

    private void PlayerInput()
    {
        foreach (Player player in Players)
        {
            _logger.Log($"Dealer has dealt a card");
            string response;
            do
            {
                _logger.Clear();
                _logger.Log(_lastRoundSummary);
                foreach (Card card in player.Cards)
                {
                    _logger.Log(card.ToString());
                }
                _logger.Log($"Value: {player.GetValue().ToString()}");
                
                response = _input.GetInput("Hit or Hold").Trim().ToLower();
                switch (response)
                {
                    case "hit":
                        _logger.Log($"Dealer has dealt a card");
                        _dealer.GiveCard(player);
                        break;
                    case "hold":
                        _logger.Log($"Player chose to hold");
                        break;
                    default:
                        throw new Exception("Unable to compare user input");
                }
            } while (player.GetValue() <= 21 && response is not "hold");
        }
    }
}