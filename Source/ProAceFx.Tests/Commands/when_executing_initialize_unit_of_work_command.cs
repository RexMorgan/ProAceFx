using Commander.Commander;
using NUnit.Framework;
using ProAceFx.Commander;
using ProAceFx.Infrastructure;
using Rhino.Mocks;

namespace ProAceFx.Tests.Commands
{
    [TestFixture]
    public class when_executing_initialize_unit_of_work_command : CommandExecutionContext<InitializeUnitOfWorkCommand>
    {
        [Test]
        public void unit_of_work_is_initialized_and_inside_command_is_executed()
        {
            MockFor<IUnitOfWork>()
                .Expect(uow => uow.Initialize());

            MockFor<ICommand>()
                .Expect(cmd => cmd.Execute());

            ClassUnderTest
                .Execute();
            
            VerifyCallsFor<IUnitOfWork>();
            VerifyCallsFor<ICommand>();
        }
    }
}