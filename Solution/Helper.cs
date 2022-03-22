using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using Solution.Models;

namespace Solution
{
    public class Helper
    {
        private static ISessionFactory? _sessionFactory;
        private static string? _connectionString;

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    _sessionFactory = Fluently.Configure()
                    .Database(PostgreSQLConfiguration.Standard.ConnectionString(_connectionString))
                    .Mappings(m => m.FluentMappings
                        .AddFromAssemblyOf<User>())
                    .ExposeConfiguration(cfg => new SchemaUpdate(cfg)
                    .Execute(true, true))
                    .BuildSessionFactory();
                }

                return _sessionFactory;
            }
        }

        public static NHibernate.ISession OpenSession(string connectionString)
        {
            _connectionString = connectionString;
            return SessionFactory.OpenSession();
        }
    }
}