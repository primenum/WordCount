namespace WordCount.Application.Services.DataProcess
{
    public interface IFileDataProcess : IDataProcess
    {
        void DataProcess(string data);
    }
}