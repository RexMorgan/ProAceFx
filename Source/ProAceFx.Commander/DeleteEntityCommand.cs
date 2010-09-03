using Commander.Commands;
using Commander.Runtime;

namespace ProAceFx.Commander
{
    public class DeleteEntityCommand<TEntity> : BasicCommand
        where TEntity : class
    {
        private readonly ICommandContext _commandContext;

        public DeleteEntityCommand(ICommandContext commandContext)
        {
            _commandContext = commandContext;
        }

        protected override DoNext PerformInvoke()
        {
            _commandContext.Set(new DeleteEntityRequest());
            return DoNext.Continue;
        }
    }
}