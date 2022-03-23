using NHibernate;
using Solution.Models;

namespace Solution
{
    public class userRepository<T> where T : class
    {
        private readonly NHibernate.ISession _session;
        protected NHibernate.ISession Session { get { return _session; } }

        public userRepository(NHibernate.ISession session)
        {
            _session = session;
        }

        public IEnumerable<T> GetAll()
        {
            var data = Session.Query<T>();
            return data;
        }

        public T Get(int id)
        {
            var data = Session.Get<T>(id);
            return data;
        }

        public T Create(T entity)
        {
            Session.Save(entity);
            Session.Flush();
            return entity;
        }

        public T Update(T entity)
        {
            Session.Update(entity);
            Session.Flush();
            return entity;
        }

        public void Delete(T entity)
        {
            Session.Delete(entity);
            Session.Flush();
        }
    }
}