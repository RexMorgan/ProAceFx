namespace ProAceFx.Web
{
    public interface IHttpSessionState
    {
        object Get(string key);
        void Set(string key, object value);
        void Remove(string key);
    }
}