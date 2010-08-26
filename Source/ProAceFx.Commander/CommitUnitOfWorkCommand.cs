using Commander.Commands;
using ProAceFx.Infrastructure;

namespace ProAceFx.Commander
{
    public class CommitUnitOfWorkCommand : BasicCommand
    {
        private readonly IUnitOfWork _unitOfWork;

        public CommitUnitOfWorkCommand(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        protected override DoNext PerformInvoke()
        {
            _unitOfWork.Commit();
            return DoNext.Continue;
        }
    }
}