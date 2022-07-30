using Microsoft.EntityFrameworkCore;

namespace DIcrud.Models
{
    public class UserContext: DbContext
    {
       
            public UserContext(DbContextOptions options) : base(options) { }

        public object User { get; internal set; }
        public DbSet<User>users
            {
                get;
                set;
            }
        public DbSet <Post> Post
        {
            get;
            set;
        }

    }
}
