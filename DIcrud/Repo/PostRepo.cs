using AutoMapper;
using AutoMapper.QueryableExtensions;
using DIcrud.Controllers;
using DIcrud.Models;
using DIcrud.vms;
using Microsoft.EntityFrameworkCore;


namespace DIcrud.Repo
{
    public interface IPostRepo : IGenRepo<Post>
    {

    }

    public class PostRepo : GenRepo<Post>,IPostRepo
    {
        public IMapper _mapper;
        public PostRepo(UserContext context, IMapper mapper) : base(context, mapper)
        {
            _mapper = mapper;


        }
      /*  public async new Task<List<PostVM>>? GetAll()
        {
            return await _context.Post
                .ProjectTo<PostVM>(_mapper.ConfigurationProvider).ToListAsync();
        }
        public new PostVM? GetObj<PostVM>(int id) where PostVM : class, IBaseModel
        {
            return _context.Post
                .ProjectTo<PostVM>(_mapper.ConfigurationProvider).FirstOrDefault(c => c.Id == id);


        }*/

    }
}


