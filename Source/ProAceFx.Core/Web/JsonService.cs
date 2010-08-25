using System;
using System.Linq;
using System.Reflection;
using System.Web.Script.Serialization;
using ProAceFx.Web;

namespace ProAceFx.Core.Web
{
    public class JsonService : IJsonService
    {
        private readonly JavaScriptSerializer _serializer;
        private readonly MethodInfo _method;

        public JsonService()
        {
            _serializer = new JavaScriptSerializer();
            _method = _serializer
                .GetType()
                .GetMethods(BindingFlags.Instance | BindingFlags.Public)
                .First(m => m.Name.EndsWith("Deserialize"));
        }

        public string Serialize<T>(T instance)
        {
            return Serialize(typeof (T), instance);
        }

        public string Serialize(Type type, object instance)
        {
            return _serializer.Serialize(instance);
        }

        public T Deserialize<T>(string input)
        {
            return _serializer.Deserialize<T>(input);
        }

        public object Deserialize(Type type, string input)
        {
            return _method
                    .MakeGenericMethod(type)
                    .Invoke(_serializer, new[] { input });
        }
    }
}