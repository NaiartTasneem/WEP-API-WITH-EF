using DIcrud.Controllers;
using DIcrud.Models;
namespace DIcrud.Repo
{
    public class UserRepo : UserInterface
    {
        private UserContext _context;

        public UserRepo (UserContext context)
        {
            _context=context;

        }
        public  List<User> GetAll()
        {
            List<User> users;
            users= _context.Set<User>().ToList();
            return users;
            _context.SaveChanges();

        }
        public  User GetUser(int id)
        {  User user=_context.Find<User>(id);
            return user;
            _context.SaveChanges();

        }

        public void Delete(int id)
        {
            var user = GetUser(id);
            if (user != null)
            { 
            _context.Remove(user);
            _context.SaveChanges();
            }
        }
        public void Add(User user)
        {
            _context.Add(user);
            _context.SaveChanges();

        }
        public  void Update(User user)
        {

            User _user = GetUser(user.Id);
            if (_user != null)
            {
                _user.FirstName = user.FirstName;
                _user.LastName = user.LastName;
                _context.Update<User>(_user);
                _context.SaveChanges();

            }


        }

      
    }
}
