using System.IO;
using System.Text;
using WordCount.Infrastructure;
using WordCount.Infrastructure.PersistanceImplementaton;

namespace WordCount.Application.Services.DataProcess
{
    internal class FileDataProcess : IFileDataProcess
    {
        private readonly IWordCounter _wordCounter;
        private readonly IPersistanceFactory _persistanceFactory;

        public FileDataProcess(IWordCounter wordCounter, IPersistanceFactory persistanceFactory)
        {
            _wordCounter = wordCounter;
            _persistanceFactory = persistanceFactory;
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
                IPersistance persistanceImpl = _persistanceFactory.GetService<IPersistanceInMemory>();
                persistanceImpl.AddOrUpdate(wordsCount);
                fs.Close();
            }

        }
    }
}
