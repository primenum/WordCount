namespace WordCount.Infrastructure
{
    public interface IPersistanceFactory
    {
        T GetService<T>() where T : PersistanceImplementaton.IPersistance;
    }
}