using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DIcrud.Repo;
using DIcrud.Models;
using DIcrud.Filters;
using AutoMapper;
using DIcrud.vms;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;

namespace DIcrud.Controllers
{
   
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]

    public class PostController : ControllerBase
    {   
        private IPostRepo _PostsRepo;
        private readonly IMapper _mapper;
        
      
        public PostController(IPostRepo postRepo, IMapper mapper)
        {
            _PostsRepo = postRepo;
            _mapper = mapper;
          
        }
        [HttpGet]
       
      public async Task<List<PostVM>> GetAll()
        {
            var Posts = await _PostsRepo.GetAll<Post>();

            return _mapper.Map<List<Post>, List<PostVM>>(Posts);

        }
        [HttpGet]
        public List<PostVM> GetBySearch(int PageN,int pageSize,string phrase)
        {
            var response = _PostsRepo.SearchPost(PageN, pageSize, phrase);
            return _mapper.Map<List<Post>, List<PostVM>>(response);

            
        }

        [HttpGet("{id}")]
       // [ServiceFilter(typeof(AppRole))]
        public async Task<ActionResult<PostVM>> GetPost(int id)
        {
            var post= _PostsRepo.GetObj<Post>(id);
            var _mappedPost = _mapper.Map<PostVM>(post);
            if (_mappedPost == null)
            return NotFound();
            return _mappedPost;

        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var post = _PostsRepo.GetObj<Post>(id);
            var _mappedPost = _mapper.Map<Post>(post);
            if (_mappedPost == null)
                return NotFound();
            _PostsRepo.Delete(id);
            return Ok();


        }


        [HttpPost]
        public async Task<ActionResult> Create([FromBody] PostVM newPost)
        {
             var _mappedPost = _mapper.Map<Post>(newPost);
            

            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userId = claimsIdentity.FindFirst("Id")?.Value;

            _mappedPost.UserId = Convert.ToInt32(userId);
            _PostsRepo.Add(_mappedPost, _mappedPost.UserId);
            return Ok();


        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody]PostVM post)
        {
            var _mappedPost = _mapper.Map<Post>(post);

            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userId = claimsIdentity.FindFirst("Id")?.Value;

            _mappedPost.UserId = Convert.ToInt32(userId);
            _PostsRepo.Update(_mappedPost, _mappedPost.UserId);
            return Ok();
        }
    }
}
