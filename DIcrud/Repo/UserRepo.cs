using DIcrud.Controllers;
using DIcrud.Models;
namespace DIcrud.Repo
{
    public interface IUserRepo : IGenRepo<User>
    {

    }
    public class UserRepo :GenRepo<User>,IUserRepo
    {
        public UserRepo(UserContext context) : base(context)
        {
        

        }




    }
}
