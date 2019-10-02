using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nls.SmartBlogger.EfPersister.Entities;

namespace Nls.SmartBlogger.Mvc.ViewModels
{
    public class BlogListViewModel
    {
        public IList<Blog> Blogs { get; }

        public BlogListViewModel(IList<Blog> blogs)
        {
            Blogs = blogs;
        }
    }
}
