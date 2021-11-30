namespace WordCount.Application.Services.DataProcess
{
    public interface IDataProcessFactory
    {

        T GetService<T>() where T : IDataProcess;
    }
}