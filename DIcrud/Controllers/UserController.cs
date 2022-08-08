using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DIcrud.Repo;
using DIcrud.Models;
using DIcrud.Filters;
using AutoMapper;
using DIcrud.vms;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace DIcrud.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {   private IUserRepo _UsersRepo;
        private readonly IMapper _mapper;

        public UserController(IUserRepo UserRepo, IMapper mapper)
        {
            _UsersRepo = UserRepo;
            _mapper = mapper;
            

        }

        [HttpGet]
         public  async Task<List<UserVM>> GetAll()
          {
             return await _UsersRepo.GetAll<UserVM>();

             
          }


        [HttpGet("{id}")]
       // [ServiceFilter(typeof(AppRole))]
        public async Task<ActionResult<UserVM>> GetUser(int id)
        {
          
            var user = _UsersRepo.GetObj<User>(id);
            var _mappedUser = _mapper.Map<UserVM>(user);
            if (_mappedUser == null)
             return NotFound();
            return _mappedUser;

        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
           
            var user = _UsersRepo.GetObj<User>(id);
            var _mappedUser = _mapper.Map<User>(user);
            if (_mappedUser == null)
              return NotFound();
           _UsersRepo.Delete(id);
            return Ok();
            

        }


        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public async Task<ActionResult> Create([FromBody]UserVM newUser)
        {
            var _mappedUser = _mapper.Map<User>(newUser);
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userId = claimsIdentity.FindFirst("Id")?.Value;

            _mappedUser.Id = Convert.ToInt32(userId);
            _UsersRepo.Add(_mappedUser, _mappedUser.Id);
            return Ok();
        }


        [HttpPut]
        public async Task<ActionResult> Update([FromBody]UserVM user)
        {
            
            var _mappedUser = _mapper.Map<User>(user);
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userId = claimsIdentity.FindFirst("Id")?.Value;

            _mappedUser.Id = Convert.ToInt32(userId);
            _UsersRepo.Update(_mappedUser, _mappedUser.Id);
            return Ok();
        }
    }
}
