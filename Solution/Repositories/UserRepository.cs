using Solution.Models;

namespace Solution.Repositories
{
    public class UserRepository : userRepository<User>
    {
   
        public UserRepository(string connectionString)
            : base(Helper.OpenSession(connectionString))
        {

        }
        public new IEnumerable<User> GetAll()
        {
            var data = Session.Query<User>()
                .Where(x => x.IsUpdated == null || x.IsUpdated == false);
            return data;
        }
        public new void Create(object user)
        {

            Session.Save(user);
            Session.Flush();
        }

        public new void Update(object user)
        {

            Session.Update(user);
            Session.Flush();
        }


        public new bool Delete(int id)
        {
            var user = Session.Query<User>().FirstOrDefault(x => x.Id == id);
            if (user != null)
            {
                Session.Delete(user);
                Session.Flush();
                return true;
            }

            throw new Exception("Invalid 'UserId' provided");
        }
    }
 }

