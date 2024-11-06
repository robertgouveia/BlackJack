namespace BlackJack.Business.Models.Extensions;

public static class ListExtension
{
    public static void RemoveLast<T>(this List<T> list)
    {
        list.RemoveAt(list.Count - 1);
    }
}