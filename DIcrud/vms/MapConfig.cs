using AutoMapper;
using DIcrud.Models;

namespace DIcrud.vms
{
    public class MapConfig: Profile
    {
        public MapConfig()
        {
            CreateMap<UserVM, User>().ReverseMap();

            CreateMap<PostVM, Post>().ReverseMap();
            CreateMap<Post, Post>();

        }
    }
}
