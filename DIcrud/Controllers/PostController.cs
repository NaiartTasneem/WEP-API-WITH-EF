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

namespace DIcrud.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
   

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
            /* var _mappedPost = _mapper.Map<Post>(newPost);
             _PostsRepo.Add(_mappedPost);
             return Ok();*/
            var tokenHandler = new JwtSecurityTokenHandler();
         //   var SecretKey = config.GetValue<string>("SecretKey");
           // var key = Encoding.ASCII.GetBytes(SecretKey);
            var token = HttpContext.Request.Headers["Authorization"];

            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
               // IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "Id ").Value);


            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody]PostVM post)
        {
            var _mappedPost = _mapper.Map<Post>(post);
            _PostsRepo.Update(_mappedPost);
            return Ok();
        }
    }
}
