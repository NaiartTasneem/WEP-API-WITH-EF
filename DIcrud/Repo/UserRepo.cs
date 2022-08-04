using AutoMapper;
using AutoMapper.QueryableExtensions;
using DIcrud.Controllers;
using DIcrud.Models;
using DIcrud.vms;
using Microsoft.EntityFrameworkCore;


namespace DIcrud.Repo
{
    public interface IUserRepo : IGenRepo<User>
    {

    }
    public class UserRepo :GenRepo<User>,IUserRepo
    {
        public IMapper _mapper;
        public UserRepo(UserContext context, IMapper mapper) : base(context,mapper)
        {
            _mapper=mapper;

        }

     
       /* public async new Task<List<UserVM>>? GetAll()
        {
            return await _context.users
                .ProjectTo<UserVM>(_mapper.ConfigurationProvider).ToListAsync();
        }
        public new UserVM? GetObj<UserVM>(int id) where UserVM : class, IBaseModel
        {
            return _context.users
                .ProjectTo<UserVM>(_mapper.ConfigurationProvider).FirstOrDefault(c => c.Id == id);


        }*/


    }
}
