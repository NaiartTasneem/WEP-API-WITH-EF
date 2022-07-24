using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DIcrud.Repo;
using DIcrud.Models;

namespace DIcrud.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {   private UserInterface _UsersRepo;
       


        public UserController(UserInterface UserRepo)
        {
            _UsersRepo = UserRepo;
        }
        [HttpGet]
        public ActionResult<List<User>> GetAll()
        {
            return _UsersRepo.GetAll();
        }
        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id)
        {
            var user = _UsersRepo.GetUser(id);
            if (user == null)
                return NotFound();
            return Ok(user);

        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var user = _UsersRepo.GetUser(id);
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
            var _user = _UsersRepo.GetUser(user.Id);
            if (_user == null)
                return NotFound();
            _UsersRepo.Update(user);
            return Ok();
        }
    }
}
