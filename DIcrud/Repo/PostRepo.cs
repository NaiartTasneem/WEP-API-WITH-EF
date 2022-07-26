using DIcrud.Controllers;
using DIcrud.Models;

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




    }
}


