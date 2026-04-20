using System.Collections.Concurrent;

public class Resolvers
{
    public string GetFormattedDate([Parent] Book e)
    {
        return e.PublishDate.ToShortDateString();
    }
}