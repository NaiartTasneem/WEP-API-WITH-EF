using DIcrud.Models;
namespace DIcrud.Repo
{
    public interface PostInterface
    {
        public List<Post> GetAll();
        public Post GetPost(int id);
        public void Delete(int id);
        public void Add(Post post);
        public void Update(Post post);
    }
}

