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
    //[Authorize(Roles="Admin")]

    public class PostController : ControllerBase
    {
        private readonly IPostRepo _postRepo;
        private readonly IMapper _mapper;


        public PostController(IPostRepo postRepo, IMapper iMapper)
        {
            _postRepo = postRepo;
            _mapper = iMapper;
        }

        [HttpGet]
        //[ServiceFilter(typeof(Filters))]
        public async Task<List<PostVM>> GetAll()
        {
            var posts = await _postRepo.GetAll<Post>();
            return _mapper.Map<List<PostVM>>(posts);
        }
        [HttpGet]
        public List<PostVM> GetBySearch(int Page, int Size, string phrase)
        {
            var response = _postRepo.SearchPost(Page, Size, phrase);
            return _mapper.Map<List<Post>, List<PostVM>>(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PostVM>> Get(int id)
        {

            var post = _postRepo.Get<Post>(id);
            var post1 = _mapper.Map<PostVM>(post);
            if (post == null)

                return NotFound();
            return post1;

        }
        [HttpDelete("{id}")]

        public async Task<ActionResult> Deletet(int id)
        {

            var user1 = _postRepo.Get<Post>(id);
            if (user1 == null)

                return NotFound();
            _postRepo.Delete(id);
            return Ok();

        }
        [HttpPost]
        public async Task Create([FromBody] PostVM PostV)
        {
            var post1 = _mapper.Map<Post>(PostV);
            // var post_ = _postRepo.Get<Post>(post1.Id);
            // await _postRepo.Add(post1);
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userId = claimsIdentity.FindFirst("UserId")?.Value;

            post1.UserId = Convert.ToInt32(userId);
            await _postRepo.Add(post1, post1.UserId);


        }
        [HttpPut]
        public async Task Update(PostVM postV)
        {
            var post1 = _mapper.Map<Post>(postV);
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userId = claimsIdentity.FindFirst("UserId")?.Value;

            post1.UserId = Convert.ToInt32(userId);
            await _postRepo.Update(_mapper.Map<Post>(postV), post1.UserId);



        }


    }
}
