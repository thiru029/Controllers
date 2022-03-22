using Solution.Models;

namespace Solution.Repositories
{
    public class EmployeeRepository : userRepository<User>
    {
        private string v;

        public EmployeeRepository(NHibernate.ISession session) : base(session)
        {

        }

 
        public new IEnumerable<User> GetAll()
        {
            var data = Session.Query<User>()
                .Where(u => u.IsUpdated == null || u.IsUpdated == false);
            return data;
        }

        public new void Update(User user)
        {
            user.IsUpdated = true;
            Session.Update(user);
            Session.Flush();
        }

        
    }
}
