namespace WordCount.Application.Services.DataProcess
{
    public interface ITextDataProcess  : IDataProcess
    {
        void DataProcess(string data);
    }
}