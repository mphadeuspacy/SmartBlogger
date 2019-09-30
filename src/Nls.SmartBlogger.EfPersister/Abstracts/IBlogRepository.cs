using System.Collections.Generic;
using System.Threading.Tasks;
using Nls.SmartBlogger.EfPersister.Entities;

namespace Nls.SmartBlogger.EfPersister.Abstracts
{
    public interface IBlogRepository
    {
        Task<Blog> GetByIdAsync(int id);

        IList<Task<Blog>> GetAllAsync();

        Blog Add(Blog blog);

        void Update(Blog blog);

        void Delete(int id);
    }
}
