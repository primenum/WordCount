using System.IO;
using System.Text;
using WordCount.Infrastructure;
using WordCount.Infrastructure.PersistanceImplementaton;
using WordCount.Infrastructure.Service;

namespace WordCount.Application.Services.DataProcess
{
    internal class FileDataProcess : IFileDataProcess
    {
        private readonly IWordCounter _wordCounter;
        private readonly IPersistance _persistance;

        public FileDataProcess(IWordCounter wordCounter, IPersistance persistance)
        {
            _wordCounter = wordCounter;
            _persistance = persistance;
        }

        public void DataProcess(string filepath)
        {
            if (string.IsNullOrEmpty(filepath))
                return;

            if (!File.Exists(filepath))
                throw new FileNotFoundException(nameof(filepath));


            using (FileStream fs = new FileStream(filepath, FileMode.Open) )
            {
                var wordsCount = _wordCounter.CountWords(fs);
                _persistance.AddOrUpdate(wordsCount);
                fs.Close();
            }

        }
    }
}
