using Commander.Commands;
using Commander.Runtime;
using NUnit.Framework;
using ProAceFx.Commander;
using ProAceFx.Infrastructure;
using Rhino.Mocks;

namespace ProAceFx.Tests.Commands
{
    [TestFixture]
    public class when_executing_update_entity_command : CommandExecutionContext<UpdateEntityCommand<DummyEntity>>
    {
        [Test]
        public void entity_is_updated_and_inside_command_is_executed_if_delete_request_is_not_set()
        {
            var entity = new DummyEntity();

            MockFor<ICommandContext>()
                .Expect(ctx => ctx.Has<DeleteEntityRequest>())
                .Return(false);

            MockFor<ICommandContext>()
                .Expect(ctx => ctx.Get<DummyEntity>())
                .Return(entity);

            MockFor<IUnitOfWork>()
                .Expect(uow => uow.Update(entity));

            MockFor<ICommand>()
                .Expect(cmd => cmd.Execute());

            ClassUnderTest
                .Execute();

            VerifyCallsFor<IUnitOfWork>();
            VerifyCallsFor<ICommandContext>();
            VerifyCallsFor<ICommand>();
        }

        [Test]
        public void entity_is_deleted_and_inside_command_is_executed_if_delete_request_is_set()
        {
            var entity = new DummyEntity();

            MockFor<ICommandContext>()
                .Expect(ctx => ctx.Has<DeleteEntityRequest>())
                .Return(true);

            MockFor<ICommandContext>()
                .Expect(ctx => ctx.Get<DummyEntity>())
                .Return(entity);

            MockFor<IUnitOfWork>()
                .Expect(uow => uow.Delete(entity));

            MockFor<ICommand>()
                .Expect(cmd => cmd.Execute());

            ClassUnderTest
                .Execute();

            VerifyCallsFor<IUnitOfWork>();
            VerifyCallsFor<ICommandContext>();
            VerifyCallsFor<ICommand>();
        }
    }
}