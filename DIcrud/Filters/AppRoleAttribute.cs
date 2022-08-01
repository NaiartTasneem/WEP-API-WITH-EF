
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
namespace DIcrud.Filters
{
   public class AppRole : IActionFilter
    {

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var auth = context.HttpContext.Request.Headers["Role"];
            if (auth=="admin")
            {
                 return;
            }
            else
            {
                context.Result = new BadRequestObjectResult("You Are Not An Admin");
                return;
            }

        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

    }
}