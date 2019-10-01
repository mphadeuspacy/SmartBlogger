using System.Collections.Generic;
using Nls.SmartBlogger.EfPersister.Entities;

namespace SmartBlogger.Tests.Common.Builders
{
    public class BlogBuilder
    {
        public IList<Blog> BuildBlogs => new List<Blog>
        {
            new Blog { BlogId = 1 },
            new Blog { BlogId = 2 },
            new Blog { BlogId = 3 },
            new Blog { BlogId = 4 },
            new Blog { BlogId = 5 },
            new Blog { BlogId = 6 },
            new Blog { BlogId = 7 },
            new Blog { BlogId = 8 },
            new Blog { BlogId = 9 },
            new Blog { BlogId = 10 }
        };
    }
}
