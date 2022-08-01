namespace DIcrud.vms
{
    public class UserVM
    {   public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

       // public string FullName { get; set; }

        public ICollection<PostVM>? PostVM { get; set; }
    }
}
