using DIcrud.Controllers;
using DIcrud.Models;
using Microsoft.EntityFrameworkCore;


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

     
        public async new Task<List<User>>? GetAll()
        {
            return _context.users.Include(p => p.Post).ToList();
        }


    }
}
