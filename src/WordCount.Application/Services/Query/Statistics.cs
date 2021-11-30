using System;
using System.Collections.Generic;
using System.Text;
using WordCount.Infrastructure;
using WordCount.Infrastructure.PersistanceImplementaton;
using WordCount.Infrastructure.Service;

namespace WordCount.Application.Services.Query
{
    internal class Statistics : IStatistics
    {
        private readonly IPersistance _persistance;

        public Statistics(IPersistance persistance)
        {
            _persistance = persistance;
        }
        public int GetWordCount(string key)
        {
            var count  = _persistance.GetCount(key);
            return count;
        }
    }
}
