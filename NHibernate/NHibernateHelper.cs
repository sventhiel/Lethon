using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Lethon.Entities;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using ISession = NHibernate.ISession;

namespace Lethon.NHibernate
{
    public class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;

        public static ISessionFactory SessionFactory => _sessionFactory ??= Fluently.Configure()
            .Database(PostgreSQLConfiguration.Standard.ConnectionString(
            "Server=localhost;" +
            "Port=5432;" +
            "Database=test;" +
            "User Id=postgres;" +
            "Password=kMpbMl4rWnZV1mGa47dK;"))
            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Product>())
            .ExposeConfiguration(cfg => new SchemaExport(cfg).Create(false, true))
            .BuildSessionFactory();

        public static ISession OpenSession() => SessionFactory.OpenSession();
    }
}
