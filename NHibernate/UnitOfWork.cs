using NHibernate;
using ISession = NHibernate.ISession;

namespace Lethon.NHibernate
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ITransaction _transaction;
        private readonly ISession _session;

        public UnitOfWork(ISession session)
        {
            _session = session;
            _transaction = _session.BeginTransaction();
        }

        public void Commit()
        {
            if (_transaction.IsActive)
            {
                _transaction.Commit();
            }
        }

        public void Dispose()
        {
            if (_transaction.IsActive)
            {
                _transaction.Rollback();
            }
            _session.Dispose();
        }
    }
}
