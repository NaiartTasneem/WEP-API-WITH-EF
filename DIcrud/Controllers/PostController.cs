using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DIcrud.Repo;
using DIcrud.Models;

namespace DIcrud.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PostController : ControllerBase
    {   private PostInterface _PostsRepo;
       


        public PostController(PostInterface postRepo)
        {
            _PostsRepo = postRepo;
        }
        [HttpGet]
        public ActionResult<List<Post>> GetAll()
        {
            return _PostsRepo.GetAll();
        }
        [HttpGet("{id}")]
        public ActionResult<Post> GetUser(int id)
        {
            var post = _PostsRepo.GetPost(id);
            if (post == null)
                return NotFound();
            return Ok(post);

        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var post = _PostsRepo.GetPost(id);
            if (post == null)
                return NotFound();
            _PostsRepo.Delete(id);
            return Ok();

        }

        [HttpPost]
        public ActionResult Create([FromBody] Post newPost)
        {
            _PostsRepo.Add(newPost);
            return Ok();
        }

        [HttpPut]
        public ActionResult Update([FromBody]Post post)
        {
            var _post = _PostsRepo.GetPost(post.Id);
            if (_post== null)
                return NotFound();
            _PostsRepo.Update(post);
            return Ok();
        }
    }
}
