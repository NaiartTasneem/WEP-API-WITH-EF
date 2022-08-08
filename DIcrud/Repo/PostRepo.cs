using AutoMapper;
using AutoMapper.QueryableExtensions;
using DIcrud.Controllers;
using DIcrud.Models;
using DIcrud.vms;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace DIcrud.Repo
{
    public interface IPostRepo : IGenRepo<Post>
    {
        public List<Post> SearchPost(int pageN, int pagesize, string Search);

    }

    public class PostRepo : GenRepo<Post>,IPostRepo
    {
        public IMapper _mapper;
        public PostRepo(UserContext context, IMapper mapper) : base(context, mapper)
        {
            _mapper = mapper;
            _context = context;


        }
        public List<Post> SearchPost(int pageN, int pagesize, string Search)
        {

          
            var pagedData = _context.Post
           .Skip((pageN - 1) * pagesize)
           .Take(pageN)
           .Where(s => s.Title.Contains(Search))
           .ToList();
            return pagedData;
           

        }
       

    }
}


