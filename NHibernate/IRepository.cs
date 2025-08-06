namespace Lethon.NHibernate
{
    public interface IRepository<T>
    {
        T GetById(int id);
        void Save(T entity);
        void Delete(T entity);
        IEnumerable<T> GetAll();
    }
}
