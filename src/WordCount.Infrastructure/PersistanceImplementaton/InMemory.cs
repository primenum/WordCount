using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace WordCount.Infrastructure.PersistanceImplementaton
{
    internal class InMemory : IPersistanceInMemory
    {
        //thread safe collection
        private readonly ConcurrentDictionary<string, int> _dataStore;

        public InMemory()
        {
            _dataStore = new ConcurrentDictionary<string, int>();
        }

        public void AddOrUpdate(IDictionary<string, int> wordsCount)
        {
            foreach (KeyValuePair<string,int> item in wordsCount)
            {
                if (_dataStore.ContainsKey(item.Key))
                {
                    _dataStore[item.Key] = _dataStore[item.Key] + item.Value;
                }
                else
                    _dataStore.TryAdd(item.Key, item.Value);
            }
        }

        public int GetCount(string word)
        {
            string key = word.ToLower();
            if (_dataStore.ContainsKey(key))
                return _dataStore[key];
            return 0;
        }
    }
}
