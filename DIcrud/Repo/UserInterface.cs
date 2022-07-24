using DIcrud.Models;
namespace DIcrud.Repo
{
    public interface UserInterface
    {
        public  List<User> GetAll();
        public  User GetUser(int id);
        public  void Delete(int id);
       public  void Add(User user);
       public  void Update(User user);
    }
}
