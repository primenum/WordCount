using System.IO;
using System.Text;
using WordCount.Infrastructure;
using WordCount.Infrastructure.PersistanceImplementaton;

namespace WordCount.Application.Services.DataProcess
{
    internal class TextDataProcess : ITextDataProcess
    {
        private readonly IWordCounter _wordCounter;
        private readonly IPersistanceFactory _persistanceFactory;

        public TextDataProcess(IWordCounter wordCounter, IPersistanceFactory persistanceFactory)
        {
            _wordCounter = wordCounter;
            _persistanceFactory = persistanceFactory;
        }

        public void DataProcess(string data)
        {
            if (string.IsNullOrEmpty(data))
                return;

            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(data)) )
            {
                var wordsCount = _wordCounter.CountWords(ms);
                IPersistance persistanceImpl = _persistanceFactory.GetService<IPersistanceInMemory>();
                persistanceImpl.AddOrUpdate(wordsCount);
                ms.Close();
            }

        }
    }
}
