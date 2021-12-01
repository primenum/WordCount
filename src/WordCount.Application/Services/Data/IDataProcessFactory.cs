namespace WordCount.Application.Services.Data
{
    internal interface IDataProcessFactory
    {

        T GetService<T>() where T : IDataProcess;
    }
}