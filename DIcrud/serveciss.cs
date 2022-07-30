using DIcrud.CustomExc;
using DIcrud.Models;
using DIcrud.Repo;
namespace DIcrud
{
    public static class serveciss
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddMvc();
            services.AddSwaggerGen();


           services.AddScoped<IUserRepo, UserRepo>();
           services.AddScoped<IPostRepo, PostRepo>();
        }
        public static void ConfigureCustomExceptionMiddleware(this WebApplication app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
