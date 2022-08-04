using AutoMapper;
using AutoMapper.QueryableExtensions;
using DIcrud.Models;
using DIcrud.vms;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DIcrud.Repo
{
    public interface IGenRepo<T> where T :class ,IBaseModel
    { 

        public Task<List<TVM>>? GetAll<TVM>();
        public TVM? GetObj<TVM>(int id) where TVM : class, IBaseModel;
        public void Delete(int id);
        public Task<T> Add(T obj);
        public Task<T> Update(T obj);

    }
    public class GenRepo<T> : IGenRepo<T> where T :class ,IBaseModel
    {
       public UserContext _context;
       public IMapper _mapper;

        public UserContext Context { get; }

        public GenRepo(UserContext context ,IMapper mapper)
        {
            _context=context;
            _mapper = mapper;

        }


        public async Task<List<TVM>>? GetAll<TVM>()
        {
            return await _context.Set<T>()
                .ProjectTo<TVM>(_mapper.ConfigurationProvider).ToListAsync();
          

        }
        public TVM? GetObj<TVM>(int id) where TVM : class, IBaseModel
        {
            return _context.Set<T>()
                .ProjectTo<TVM>(_mapper.ConfigurationProvider).FirstOrDefault(c => c.Id == id);
       

        }

        public async void Delete(int id)
        {
            var _temp = await _context.Set<T>().FirstOrDefaultAsync(c => c.Id == id);

           _context.Set<T>().Remove(_temp);
            await _context.SaveChangesAsync();

        }
        public async Task<T> Add(T obj)
        {
            await _context.AddAsync(obj);
            await _context.SaveChangesAsync();
            return obj;

        }
        public async Task<T> Update(T obj)
        {


           _context.Set<T>().Update(obj);
           await _context.SaveChangesAsync();
            return obj;

        }
    }
}
