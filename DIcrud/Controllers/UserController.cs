﻿using Microsoft.AspNetCore.Http;
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
    {   private readonly IUserRepo _UsersRepo;
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
          
            var user = _UsersRepo.Get<User>(id);
            var _mappedUser = _mapper.Map<UserVM>(user);
            if (_mappedUser == null)
             return NotFound();
            return _mappedUser;

        }


        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
           await _UsersRepo.Delete(id);
           /* var user = _UsersRepo.GetObj<User>(id);
            var _mappedUser = _mapper.Map<User>(user);
            if (_mappedUser == null)
              return NotFound();
           _UsersRepo.Delete(id);
            return Ok();*/
            

        }


        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public async Task Create([FromBody]UserVM newUser)
        {
            var _mappedUser = _mapper.Map<User>(newUser);
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userId = claimsIdentity.FindFirst("userId")?.Value;

            _mappedUser.Id = Convert.ToInt32(userId);
           await _UsersRepo.Add(_mappedUser, _mappedUser.Id);
           
        }


        [HttpPut]
        public async Task<ActionResult> Update([FromBody]UserVM user)
        {
            
            var _mappedUser = _mapper.Map<User>(user);
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userId = claimsIdentity.FindFirst("userId")?.Value;

            _mappedUser.Id = Convert.ToInt32(userId);
            _UsersRepo.Update(_mappedUser, _mappedUser.Id);
            return Ok();
        }
    }
}
