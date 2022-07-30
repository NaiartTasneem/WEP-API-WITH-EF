using DIcrud.Controllers;
using DIcrud.Models;
using Microsoft.EntityFrameworkCore;

namespace DIcrud.Repo
{
    public interface IPostRepo : IGenRepo<Post>
    {

    }

    public class PostRepo : GenRepo<Post>,IPostRepo
    {
        public PostRepo(UserContext context) : base(context)
        {


        }
        public new List<Post>? GetAll()
        {
            return _context.Post.Include(p => p.User).ToList();
        }

    }
}


