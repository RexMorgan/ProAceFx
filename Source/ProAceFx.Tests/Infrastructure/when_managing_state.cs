using Hrci.Testing.Infrastructure;
using NUnit.Framework;
using ProAceFx.Core.Infrastructure;
using ProAceFx.Infrastructure;
using Rhino.Mocks;

namespace ProAceFx.Tests.Infrastructure
{
    [TestFixture]
    public class when_managing_state : InteractionContext<StateManager>
    {
        [Test]
        public void updating_does_not_set_state_provider_before_commit()
        {
            var state = new StatefulObject();
            
            ClassUnderTest
                .Update(state);

            MockFor<IStateProvider>()
                .AssertWasNotCalled(p => p.Set(state), o => o.IgnoreArguments());
        }

        [Test]
        public void updating_sets_state_provider_after_commit()
        {
            var state = new StatefulObject();
            MockFor<IStateProvider>()
                .Expect(p => p.Set(state));

            ClassUnderTest
                .Update(state);

            ClassUnderTest
                .Commit();

            VerifyCallsFor<IStateProvider>();
        }
    }
}