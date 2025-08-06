using NHibernate;
using System.Linq;
using ISession = NHibernate.ISession;

namespace Lethon.NHibernate
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ISession _session;

        public Repository(ISession session)
        {
            _session = session;
        }

        public T GetById(int id) => _session.Get<T>(id);

        public IEnumerable<T> GetAll() => _session.Query<T>().ToList();

        public void Save(T entity) => _session.SaveOrUpdate(entity);

        public void Delete(T entity) => _session.Delete(entity);
    }
}
