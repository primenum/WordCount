using System;
using System.IO;
using System.Text;
using WordCount.Infrastructure;
using WordCount.Infrastructure.PersistanceImplementaton;
using WordCount.Infrastructure.Service;
using WordCount.Infrastructure.Service.Rest;

namespace WordCount.Application.Services.DataProcess
{
    internal class WebResourceDataProcess : IWebResourceDataProcess
    {
        private readonly IWordCounter _wordCounter;
        private readonly IPersistance _persistance;
        private readonly IRest _restService;

        public WebResourceDataProcess(IWordCounter wordCounter, IPersistance persistance, IRest restService)
        {
            _wordCounter = wordCounter;
            _persistance = persistance;
            _restService = restService;
        }

        public void DataProcess(string url)
        {
            if (string.IsNullOrEmpty(url))
                return;

            if (!Uri.TryCreate(url, UriKind.Absolute, out var uri))
            {
                throw new UriFormatException($"Invalid absolute URI: {url}");
            }

            


            using (FileStream fs = new FileStream(url, FileMode.Open) )
            {
                var wordsCount = _wordCounter.CountWords(fs);
                _persistance.AddOrUpdate(wordsCount);
                fs.Close();
            }

        }
    }
}
