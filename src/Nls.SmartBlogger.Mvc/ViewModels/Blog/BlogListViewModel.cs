using System.Collections.Generic;

namespace Nls.SmartBlogger.Mvc.ViewModels.Blog
{
    public class BlogListViewModel
    {
        public IList<EfPersister.Entities.Blog> Blogs { get; set; }
  
    }
}
