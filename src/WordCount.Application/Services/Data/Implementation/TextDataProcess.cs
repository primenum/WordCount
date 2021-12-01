using System.IO;
using System.Text;
using WordCount.Infrastructure.Service;

namespace WordCount.Application.Services.Data.Implementation

{
    internal class TextDataProcess : ITextDataProcess
    {
        private readonly IWordCounter _wordCounter;
        private readonly IPersistance _persistance;

        public TextDataProcess(IWordCounter wordCounter, IPersistance persistance)
        {
            _wordCounter = wordCounter;
            _persistance = persistance;
        }

        public void DataProcess(string data)
        {
            if (string.IsNullOrEmpty(data))
                return;

            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(data)) )
            {
                var wordsCount = _wordCounter.CountWords(ms);
                _persistance.AddOrUpdate(wordsCount);
                ms.Close();
            }

        }
    }
}
