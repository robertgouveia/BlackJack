using System.Runtime.InteropServices.JavaScript;
using BlackJack.Business.Models.Players;

namespace BlackJack.Business.Models.Configurations;

public class Result
{
    public int Number { get; init; }
    public Hand? Winner { get; init; }

    public Result(int number, Hand winner)
    {
        Number = number;
        Winner = winner;
    }

    public Result(int number)
    {
        Number = number;
    }
}