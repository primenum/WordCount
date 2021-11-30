using System;
using System.Collections.Generic;
using System.Text;
using WordCount.Infrastructure.PersistanceImplementaton;

namespace WordCount.Infrastructure.Service
{
    internal class Persistance : IPersistance
    {
        private readonly IPersistanceInMemory _inMemoryImplementation;

        public Persistance(IPersistanceFactory persistanceFactory)
        {
            _inMemoryImplementation =  persistanceFactory.GetService<IPersistanceInMemory>();
        }
        public void AddOrUpdate(IDictionary<string, int> wordsCount)
        {
            _inMemoryImplementation.AddOrUpdate(wordsCount);
        }

        public int GetCount(string word)
        {
            return _inMemoryImplementation.GetCount(word);
        }
    }
}
