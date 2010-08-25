using System;

namespace ProAceFx.Infrastructure
{
    public interface IStateProvider
    {
        T Get<T>() where T : class;
        object Get(Type type);
        void Set<T>(T instance);
        void Remove<T>();
    }
}