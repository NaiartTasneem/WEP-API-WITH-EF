using DIcrud.Models;
using Microsoft.EntityFrameworkCore;

namespace DIcrud.Repo
{
    public interface IGenRepo<T> where T :class ,IBaseModel
    { 

        public Task<List<T>>? GetAll();
        public Task<T> GetObj(int id);
        public void Delete(int id);
        public Task<T> Add(T obj);
        public Task<T> Update(T obj);

    }
    public class GenRepo<T> : IGenRepo<T> where T :class ,IBaseModel
    {
       public  readonly UserContext _context;
        

        public GenRepo(UserContext context)
        {
            _context=context;


        }

        public async Task<List<T>>? GetAll()
        {

            return _context.Set<T>().ToList();

                   // _context.SaveChangesAsync();

        }
        public async Task<T> GetObj(int id)
        {
            return _context.Set<T>().Find(id);
       

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
