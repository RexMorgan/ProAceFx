using NHibernate;
using ProAceFx.Infrastructure;

namespace ProAceFx.Core.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private ISession _session;
        private ITransaction _transaction;
        private bool _alreadyCommitted;

        public UnitOfWork(ISession session)
        {
            _session = session;
        }

        public void Dispose()
        {
            _session = null;
            _transaction = null;
        }

        public void Initialize()
        {
            _transaction = _session.BeginTransaction();
            _alreadyCommitted = false;
        }

        public void Insert(object entity)
        {
            _session.Save(entity);
        }

        public void Update(object entity)
        {
            _session.Update(entity);
        }

        public void Delete(object entity)
        {
            _session.Delete(entity);
        }

        public void Commit()
        {
            if (!_alreadyCommitted)
            {
                _transaction.Commit();
                _alreadyCommitted = true;
            }
        }

        public void Rollback()
        {
            if (_transaction != null)
            {
                _transaction.Rollback();
            }
        }
    }
}
