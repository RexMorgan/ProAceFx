using Commander.Commands;
using Commander.Runtime;
using ProAceFx.Infrastructure;

namespace ProAceFx.Commander
{
    public class InsertEntityCommand<TEntity> : BasicCommand
        where TEntity : class
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICommandContext _commandContext;

        public InsertEntityCommand(IUnitOfWork unitOfWork, ICommandContext commandContext)
        {
            _unitOfWork = unitOfWork;
            _commandContext = commandContext;
        }

        protected override DoNext PerformInvoke()
        {
            var entity = _commandContext.Get<TEntity>();
            _unitOfWork.Insert(entity);
            return DoNext.Continue;
        }
    }
}