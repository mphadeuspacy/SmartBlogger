using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Nls.SmartBlogger.EfPersister.Abstracts;
using Nls.SmartBlogger.EfPersister.Entities;

namespace Nls.SmartBlogger.EfPersister.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly SmartBloggerDbContext _context;

        public IUnitOfWork UnitOfWork => _context;

        public BlogRepository(SmartBloggerDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Blog> GetByIdAsync(int id)
        {
            return await _context.Blogs.FindAsync(id);
        }

        public async Task<IList<Blog>> GetAllAsync()
        {
            return await _context.Blogs.ToListAsync();
        }

        public Blog Add(Blog blog)
        {
            _context.Entry(blog).State = EntityState.Added;

            return _context.Blogs.Add(blog);
        }
        
        public void Update(Blog blog)
        {
            _context.Entry(blog).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var entityToDelete =  _context.Blogs.FirstOrDefault(b => b.BlogId == id);

            if (entityToDelete == null)
            {
                return;
            }

            _context.Blogs.Remove(entityToDelete);
        }
    }
}
