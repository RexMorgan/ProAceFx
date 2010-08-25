using System;
using ProAceFx.Infrastructure;
using ProAceFx.Web;

namespace ProAceFx.Core.Infrastructure
{
    public class SessionStateProvider : IStateProvider
    {
        private readonly IJsonService _jsonService;
        private readonly IHttpSessionState _sessionState;
        private readonly Func<Type, string> _keyGenerator;
        public SessionStateProvider(IJsonService jsonService, IHttpSessionState sessionState)
        {
            _jsonService = jsonService;
            _sessionState = sessionState;

            _keyGenerator = (type => type.Name);
        }

        public T Get<T>()
             where T : class
        {
            return Get(typeof (T)) as T;
        }

        public object Get(Type type)
        {
            var serializedState = _sessionState
                                    .Get(_keyGenerator(type))
                                    .ToString();

            return _jsonService.Deserialize(type, serializedState);
        }

        public void Set<T>(T instance)
        {
            var serializedState = _jsonService.Serialize(instance);
            _sessionState.Set(_keyGenerator(typeof(T)), serializedState);
        }

        public void Remove<T>()
        {
            _sessionState.Remove(_keyGenerator(typeof(T)));
        }
    }
}