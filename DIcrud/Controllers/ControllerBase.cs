using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DIcrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ControllerBase : Controller 
    {
        
        protected int GetUserId()
        {
            return int.Parse(this.User.Claims.First(i => i.Type == "Id").Value);
        }

    }
}
