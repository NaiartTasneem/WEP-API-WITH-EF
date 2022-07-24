using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace DIcrud.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
         public string LastName { get; set; }

        public ICollection<Post>? Post { get; set; }
    }
}
