namespace WordCount.Application.Services.Data
{
    public interface IDataAnalize
    {
        void AnalyzeFreeText(string text);
        void AnalyzeFile(string filePath);
        void AnalyzeWebResource(string filePath);
    }
}