using System.Collections.Generic;
using System.IO;

namespace WordCount.Application.Services.Data
{
    internal interface IWordCounter
    {
        IDictionary<string, int> CountWords(Stream stream);
    }
}