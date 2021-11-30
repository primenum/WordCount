using System.Collections.Generic;

namespace WordCount.Infrastructure.Service
{
    public interface IPersistance 
    {
        int GetCount(string word);
        void AddOrUpdate(IDictionary<string, int> wordsCount);
    }
}