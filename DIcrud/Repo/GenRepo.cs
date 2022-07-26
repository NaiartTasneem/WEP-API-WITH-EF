using DIcrud.Models;
namespace DIcrud.Repo
{
    public interface IGenRepo<T> where T :class ,IBaseModel
    { 

        public List<T>? GetAll();
        public T GetObj(int id);
        public void Delete(int id);
        public T Add(T obj);
        public T Update(T obj);

    }
    public class GenRepo<T> : IGenRepo<T> where T :class ,IBaseModel
    {
        readonly UserContext _context;
        

        public GenRepo(UserContext context)
        {
            _context=context;


        }

        public List<T>? GetAll()
        {
            
            return _context.Set<T>().ToList();

            _context.SaveChanges();

        }
        public T GetObj(int id)
        {
            return _context.Set<T>().Find(id);

                

        }

        public void Delete(int id)
        {
            var _temp = _context.Set<T>().FirstOrDefault(c => c.Id == id);
         
                _context.Set<T>().Remove(_temp);
                _context.SaveChanges();
            
        }
        public T Add(T obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
            return obj;

        }
        public T Update(T obj)
        {


            _context.Set<T>().Update(obj);
            _context.SaveChanges();
            return obj;

        }
    }
}
