using System.Collections.Generic;
using System.Threading.Tasks;
using Nls.SmartBlogger.EfPersister.Entities;

namespace Nls.SmartBlogger.EfPersister.Abstracts
{
    public interface IBlogRepository : IRepository<Blog>
    {
        Task<Blog> GetByIdAsync(int id);

        Task<IList<Blog>> GetAllAsync();

        Blog Add(Blog blog);

        void Update(Blog blog);

        void Delete(int id);
    }
}
