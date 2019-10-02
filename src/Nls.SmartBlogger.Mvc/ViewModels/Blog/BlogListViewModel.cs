using System.Collections.Generic;

namespace Nls.SmartBlogger.Mvc.ViewModels.Blog
{
    public class BlogListViewModel
    {
        public IList<EfPersister.Entities.Blog> Blogs { get; }

        public BlogListViewModel(IList<EfPersister.Entities.Blog> blogs)
        {
            Blogs = blogs;
        }
    }
}
