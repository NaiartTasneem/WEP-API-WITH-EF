using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
namespace DIcrud.Filters
{
    internal class AppRole :Attribute, IActionFilter
    {
        //private StringValues d;
        private string v;

        public AppRole(string v)
        {
            this.v = v;
        }

        public AppRole()
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {

          // context.HttpContext.Request.Headers.TryGetValue("Role", out d);
           var val = context.HttpContext.Request.Headers.Where(t => t.Key == "Role").Where(t => t.Value == v);
            if (val.Any())
            {

            }
            else
            {
                return;
            }

        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

    }
}