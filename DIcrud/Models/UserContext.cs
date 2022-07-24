using Microsoft.EntityFrameworkCore;

namespace DIcrud.Models
{
    public class UserContext: DbContext
    {
       
            public UserContext(DbContextOptions options) : base(options) { }
            DbSet<User>users
            {
                get;
                set;
            }
        DbSet <Post> Post
        {
            get;
            set;
        }

    }
}
