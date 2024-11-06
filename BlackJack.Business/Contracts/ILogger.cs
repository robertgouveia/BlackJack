namespace BlackJack.Business.Contracts;

public interface ILogger
{
    public void Log(string message);
    public void Clear();
}