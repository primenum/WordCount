namespace WordCount.Application.Services.Query
{
    public interface IStatistics
    {
        int GetWordCount(string key);
    }
}