using System.ComponentModel.DataAnnotations;

namespace DIcrud.Models
{
    public class Post:BaseModel
    {
       
        public string? Title{ get; set; }
        
        public int UserId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public int CreateBy { get; set; }
        public int UpdateBy { get; set; }
        public User? User { get; set; }

    }
}
