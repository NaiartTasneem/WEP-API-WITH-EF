using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DIcrud.Models
{
    public class User : IdentityUser<int>, IBaseModel
    {
       
        public string? FirstName { get; set; }
         public string? LastName { get; set; }

        public ICollection<Post>? Post { get; set; }
      
    }
}
