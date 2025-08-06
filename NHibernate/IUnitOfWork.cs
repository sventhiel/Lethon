namespace Lethon.NHibernate
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
