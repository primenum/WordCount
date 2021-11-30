using System.Collections.Generic;
using System.IO;

namespace WordCount.Application.Services.DataProcess
{
    internal interface IWordCounter
    {
        IDictionary<string, int> CountWords(Stream stream);
    }
}