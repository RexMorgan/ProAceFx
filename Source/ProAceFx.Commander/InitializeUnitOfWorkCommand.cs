using Commander.Commander;
using ProAceFx.Infrastructure;

namespace ProAceFx.Commander
{
    public class InitializeUnitOfWorkCommand : BasicCommand
    {
        private readonly IUnitOfWork _unitOfWork;

        public InitializeUnitOfWorkCommand(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        protected override DoNext PerformInvoke()
        {
            if(InsideCommand != null)
            {
                _unitOfWork.Initialize();
            }

            return DoNext.Continue;
        }
    }
}