using System.ComponentModel.DataAnnotations;

namespace DIcrud.Models
{
    public class Post:BaseModel
    {
       
        public string Title{ get; set; }
        
        public int UserId { get; set; }
        
        public User? User { get; set; }

    }
}
