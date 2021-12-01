namespace WordCount.Application.Services.Data.Implementation

{
    public interface IWebResourceDataProcess : IDataProcess
    {
        void DataProcess(string url);
    }
}