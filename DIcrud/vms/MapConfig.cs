using AutoMapper;
using DIcrud.Models;

namespace DIcrud.vms
{
    public class MapConfig: Profile
    {
        public MapConfig()
        {
            CreateMap<User,UserVM> ().ReverseMap();

            CreateMap<Post,PostVM>().ReverseMap();
            CreateMap<Post, Post>().ReverseMap();
            CreateMap<User, User>().ReverseMap();

        }
    }
}
