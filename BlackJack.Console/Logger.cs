using BlackJack.Business.Contracts;

namespace BlackJack.Console;

public class Logger : ILogger
{
    public void Log(string message)
    {
        System.Console.WriteLine(message);
    }

    public void Clear()
    {
        System.Console.Clear();
    }
}