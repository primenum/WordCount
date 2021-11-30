using System.Collections.Generic;

namespace WordCount.Infrastructure.PersistanceImplementaton
{
    public interface IPersistance
    {
        int GetCount(string word);
        void AddOrUpdate(IDictionary<string, int> wordsCount);
    }
}