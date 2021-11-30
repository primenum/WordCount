namespace WordCount.Infrastructure
{
    internal interface IPersistanceFactory
    {
        T GetService<T>() where T : PersistanceImplementaton.IPersistanceImplemenation;
    }
}