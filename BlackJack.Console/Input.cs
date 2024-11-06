using BlackJack.Business.Contracts;

namespace BlackJack.Console;

public class Input : IInput
{
    public string GetInput(string message)
    {
        string? input;
        do
        {
            System.Console.WriteLine(message);
            input = System.Console.ReadLine();
        } while (input is null);
        
        return input.Trim().ToLower();
    }
}