using Commander.Runtime;
using NUnit.Framework;
using ProAceFx.Commander;
using Rhino.Mocks;

namespace ProAceFx.Tests.Commands
{
    [TestFixture]
    public class when_executing_delete_entity_command : CommandExecutionContext<DeleteEntityCommand<DummyEntity>>
    {
        [Test]
        public void delete_entity_request_is_set_in_command_context()
        {
            MockFor<ICommandContext>()
                .Expect(ctx => ctx.Set(Arg<DeleteEntityRequest>.Is.NotNull));

            ClassUnderTest
                .Execute();

            VerifyCallsFor<ICommandContext>();
        }
    }
}