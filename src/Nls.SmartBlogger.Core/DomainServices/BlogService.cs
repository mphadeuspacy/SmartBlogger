using Nls.SmartBlogger.EfPersister.Abstracts;

namespace Nls.SmartBlogger.Core.DomainServices
{
    public interface IBlogService
    {

    }

    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepository;

        public BlogService(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }
    }
}
