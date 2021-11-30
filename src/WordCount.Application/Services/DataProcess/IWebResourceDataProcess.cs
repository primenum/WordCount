namespace WordCount.Application.Services.DataProcess
{
    public interface IWebResourceDataProcess : IDataProcess
    {
        void DataProcess(string url);
    }
}