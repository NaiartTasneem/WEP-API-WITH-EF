using DIcrud.Controllers;
using DIcrud.Models;

namespace DIcrud.Repo
{


    public class PostRepo : PostInterface
        {
            private UserContext _context;

            public PostRepo(UserContext context)
            {
                _context = context;

            }
            public List<Post> GetAll()
            {
                List<Post> post;
                post= _context.Set<Post>().ToList();


                return post;
                _context.SaveChanges();

            }
            public Post GetPost(int id)
            {
                Post post = _context.Find<Post>(id);
                return post;
                _context.SaveChanges();

            }

            public void Delete(int id)
            {
                var post = GetPost(id);
                if (post != null)
                {
                    _context.Remove(post);
                    _context.SaveChanges();
                }
            }
            public void Add(Post post)
            {
                _context.Add(post);
                _context.SaveChanges();

            }
            public void Update(Post post)
            {

                Post _post = GetPost(post.Id);
                if (_post != null)
                {
                    _post.Title = post.Title;
                   
                    _context.Update<Post>(_post);
                    _context.SaveChanges();

                }


            }


        }
    }


