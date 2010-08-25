using Commander.Commander;

namespace ProAceFx.Tests.Commands
{
    public class CommandExecutionContext<TCommand> : InteractionContext<TCommand>
        where TCommand : BasicCommand
    {
        protected override void BeforeEach()
        {
            ClassUnderTest.InsideCommand = MockFor<ICommand>();
        }
    }
}