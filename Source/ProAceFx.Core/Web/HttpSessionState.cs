using System.Web;
using ProAceFx.Web;

namespace ProAceFx.Core.Web
{
    public class HttpSessionState : IHttpSessionState
    {
        private readonly HttpSessionStateBase _session;

        public HttpSessionState(HttpSessionStateBase session)
        {
            _session = session;
        }

        public object Get(string key)
        {
            return _session[key];
        }

        public void Set(string key, object value)
        {
            _session[key] = value;
        }

        public void Remove(string key)
        {
            _session.Remove(key);
        }
    }
}