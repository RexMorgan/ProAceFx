using Commander.Commander;
using Commander.Runtime;
using NUnit.Framework;
using ProAceFx.Commander;
using ProAceFx.Infrastructure;
using Rhino.Mocks;

namespace ProAceFx.Tests.Commands
{
    [TestFixture]
    public class when_executing_insert_entity_command : CommandExecutionContext<InsertEntityCommand<DummyEntity>>
    {
        [Test]
        public void entity_is_inserted_and_inside_command_is_executed()
        {
            var entity = new DummyEntity();

            MockFor<ICommandContext>()
                .Expect(ctx => ctx.Get<DummyEntity>())
                .Return(entity);

            MockFor<IUnitOfWork>()
                .Expect(uow => uow.Insert(entity));

            MockFor<ICommand>()
                .Expect(cmd => cmd.Execute());

            ClassUnderTest
                .Execute();

            VerifyCallsFor<IUnitOfWork>();
            VerifyCallsFor<ICommand>();
        }
    }
}