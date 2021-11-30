using System;
using System.Collections.Generic;
using System.Text;
using WordCount.Infrastructure;
using WordCount.Infrastructure.PersistanceImplementaton;

namespace WordCount.Application.Services.Query
{
    internal class Statistics : IStatistics
    {
        private readonly IPersistanceFactory _persistanceFactory;

        public Statistics(IPersistanceFactory persistanceFactory)
        {
            _persistanceFactory = persistanceFactory;
        }
        public int GetWordCount(string key)
        {
            IPersistance persistanceImplementation =  _persistanceFactory.GetService<IPersistanceInMemory>();
            var count  = persistanceImplementation.GetCount(key);
            return count;
        }
    }
}
