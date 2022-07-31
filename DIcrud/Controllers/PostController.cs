using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DIcrud.Repo;
using DIcrud.Models;
using DIcrud.Filters;

namespace DIcrud.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PostController : ControllerBase
    {   private IPostRepo _PostsRepo;
       


        public PostController(IPostRepo postRepo)
        {
            _PostsRepo = postRepo;
        }
        [HttpGet]
       
        public ActionResult<List<Post>> GetAll()
        {
            return _PostsRepo.GetAll();
        }
        [HttpGet("{id}")]
        [ServiceFilter(typeof(AppRole))]
        public ActionResult<Post> GetUser(int id)
        {
            var post = _PostsRepo.GetObj(id);
            if (post == null)
                return NotFound();
            return Ok(post);

        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var post = _PostsRepo.GetObj(id);
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
         
            _PostsRepo.Update(post);
            return Ok();
        }
    }
}
