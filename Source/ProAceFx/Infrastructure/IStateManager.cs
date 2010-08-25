namespace ProAceFx.Infrastructure
{
    public interface IStateManager
    {
        void Update<T>(T instance)
            where T : class;

        void Remove<T>(T instance)
            where T : class;

        void Commit();
    }
}