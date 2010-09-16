using Commander.Commands;
using Commander.Runtime;
using ProAceFx.Infrastructure;

namespace ProAceFx.Commander
{
    public class UpdateEntityCommand<TEntity> : BasicCommand
        where TEntity : class
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICommandContext _commandContext;

        public UpdateEntityCommand(IUnitOfWork unitOfWork, ICommandContext commandContext)
        {
            _unitOfWork = unitOfWork;
            _commandContext = commandContext;
        }

        protected override DoNext PerformInvoke()
        {
            var entity = _commandContext.Get<TEntity>();
            if(_commandContext.Has<DeleteEntityRequest>())
            {
                _unitOfWork.Delete(entity);
            }
            else
            {
                _unitOfWork.Update(entity);
            }
            
            return DoNext.Continue;
        }
    }
}