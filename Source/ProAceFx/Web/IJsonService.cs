using System;

namespace ProAceFx.Web
{
    public interface IJsonService
    {
        string Serialize<T>(T instance);
        string Serialize(Type type, object instance);
        T Deserialize<T>(string input);
        object Deserialize(Type type, string input);
    }
}