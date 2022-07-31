using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DIcrud.Repo;
using DIcrud.Models;
using DIcrud.Filters;

namespace DIcrud.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {   private IUserRepo _UsersRepo;


        public UserController(IUserRepo UserRepo)
        {
            _UsersRepo = UserRepo;
        }
       
        [HttpGet]
        public ActionResult<List<User>> GetAll()
        {
            return Ok( _UsersRepo.GetAll());
        }
        [HttpGet("{id}")]
        [ServiceFilter(typeof(AppRole))]
        public ActionResult<User> GetUser(int id)
        {
            var user = _UsersRepo.GetObj(id);
            if (user == null)
             return NotFound();
            return Ok(user) ;

        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var user = _UsersRepo.GetObj(id);
            if (user == null)
              return NotFound();
           _UsersRepo.Delete(id);
            return Ok();

        }

        [HttpPost]
        public ActionResult Create([FromBody]User newUser)
        {
            _UsersRepo.Add(newUser);
            return Ok();
        }

        [HttpPut]
        public ActionResult Update([FromBody]User user)
        {
           
            
            _UsersRepo.Update(user);
            return Ok();
        }
    }
}
