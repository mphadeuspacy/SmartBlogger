using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nls.SmartBlogger.Common.Exceptions;
using Nls.SmartBlogger.Core.Filters;
using Nls.SmartBlogger.EfPersister.Abstracts;
using Nls.SmartBlogger.EfPersister.Entities;

namespace Nls.SmartBlogger.Core.DomainServices
{
    public interface IBlogService
    {
        Task<IList<Blog>> GetAllByFilterAsync(GetAllAsyncFilter getAllAsyncFilter);
    }

    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepository;

        public BlogService(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository ?? throw new ArgumentNullException();
        }

        public async Task<IList<Blog>> GetAllByFilterAsync(GetAllAsyncFilter getAllAsyncFilter)
        {
            if (getAllAsyncFilter == null)
            {
                // TODO: Add logger for exception message
                throw new BusinessException($"Business exception occurred with message : {nameof(getAllAsyncFilter)} is cannot be null");
            }

            IList<Blog> blogList = await _blogRepository.GetAllAsync();

            return blogList.Skip(getAllAsyncFilter.Skip).Take(getAllAsyncFilter.Take).ToList();
        }
    }
}
