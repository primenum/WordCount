using System;
using System.Collections.Generic;
using System.Text;

namespace WordCount.Application.Services.Data
{
    internal class DataAnalize : IDataAnalize
    {
        private readonly IDataProcessFactory _dataProcessFactory;

        public DataAnalize(IDataProcessFactory dataProcessFactory)
        {
            _dataProcessFactory = dataProcessFactory;
        }

        public void AnalyzeFile(string filePath)
        {
            var dataProcessImplementation = _dataProcessFactory.GetService<Implementation.IFileDataProcess>();
            dataProcessImplementation.DataProcess(filePath);

        }

        public void AnalyzeFreeText(string text)
        {
            var dataProcessImplementation = _dataProcessFactory.GetService<Implementation.ITextDataProcess>();
            dataProcessImplementation.DataProcess(text);
        }

        public void AnalyzeWebResource(string url)
        {
            var dataProcessImplementation = _dataProcessFactory.GetService<Implementation.IWebResourceDataProcess>();
            dataProcessImplementation.DataProcess(url);
        }
    }
}
