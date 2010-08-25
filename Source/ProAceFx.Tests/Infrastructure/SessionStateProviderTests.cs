using Hrci.Testing.Infrastructure;
using NUnit.Framework;
using ProAceFx.Core.Infrastructure;
using ProAceFx.Web;
using Rhino.Mocks;

namespace ProAceFx.Tests.Infrastructure
{
    [TestFixture]
    public class SessionStateProviderTests : InteractionContext<SessionStateProvider>
    {
        const string SerializedState = "serialized value";

        [Test]
        public void setting_state_serializes_to_json_and_keys_off_of_type_name()
        {
            var state = new StatefulObject();

            MockFor<IJsonService>()
                .Expect(s => s.Serialize<StatefulObject>(state))
                .Return(SerializedState);

            MockFor<IHttpSessionState>()
                .Expect(s => s.Set(state.GetType().Name, SerializedState));


            ClassUnderTest
                .Set<StatefulObject>(state);

            VerifyCallsFor<IJsonService>();
            VerifyCallsFor<IHttpSessionState>();
        }

        [Test]
        public void getting_state_pulls_from_session_state_and_deserializes()
        {
            var state = new StatefulObject();

            MockFor<IJsonService>()
                .Expect(s => s.Deserialize(typeof(StatefulObject), SerializedState))
                .Return(state);

            MockFor<IHttpSessionState>()
                .Expect(s => s.Get(state.GetType().Name))
                .Return(SerializedState);

            ClassUnderTest
                .Get<StatefulObject>();

            VerifyCallsFor<IJsonService>();
            VerifyCallsFor<IHttpSessionState>();
        }

        [Test]
        public void removing_state_removes_key_from_session()
        {
            MockFor<IHttpSessionState>()
                .Expect(s => s.Remove(typeof (StatefulObject).Name));

            ClassUnderTest
                .Remove<StatefulObject>();

            VerifyCallsFor<IHttpSessionState>();
        }
    }
}