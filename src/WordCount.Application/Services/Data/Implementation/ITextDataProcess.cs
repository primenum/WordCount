namespace WordCount.Application.Services.Data.Implementation
{
    public interface ITextDataProcess  : IDataProcess
    {
        void DataProcess(string data);
    }
}