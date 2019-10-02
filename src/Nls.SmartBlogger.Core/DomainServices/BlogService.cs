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
        Task<IList<Blog>> GetAllByFilterAsync(GetAllByFilterInput getAllByFilterInput);

        Task<Blog> GetByIdAsync(int id);

        Task<bool> CreateAsync(Blog blog);

        Task<bool> UpdateAsync(Blog blog);

        Task DeleteAsync(int id);
    }

    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepository;

        public BlogService(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository ?? throw new ArgumentNullException();
        }

        public async Task<IList<Blog>> GetAllByFilterAsync(GetAllByFilterInput getAllByFilterInput)
        {
            if (getAllByFilterInput == null)
            {
                // TODO: Add logger for exception message
                throw new BusinessException($"Business exception occurred with message : {nameof(getAllByFilterInput)} is cannot be null");
            }

            IList<Blog> blogList = await _blogRepository.GetAllAsync();

            return blogList.Skip(getAllByFilterInput.Skip).Take(getAllByFilterInput.Take).ToList();
        }

        public async Task<Blog> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                // TODO: Add logger for exception message
                throw new BusinessException($"Business exception occurred with message : id with value {id} is invalid");
            }

            return await _blogRepository.GetByIdAsync(id);
        }

        public async Task<bool> CreateAsync(Blog blog)
        {
            if (blog == null)
            {
                // TODO: Add logger for exception message
                throw new BusinessException($"Business exception occurred with message : {nameof(blog)} cannot be null");
            }

            _blogRepository.Add(blog);

            await _blogRepository.UnitOfWork.CommitAsync();

            return true;
        }

        public async Task<bool> UpdateAsync(Blog blog)
        {
            if (blog == null)
            {
                // TODO: Add logger for exception message
                throw new BusinessException($"Business exception occurred with message : {nameof(blog)} cannot be null");
            }

            _blogRepository.Update(blog);

            await _blogRepository.UnitOfWork.CommitAsync();

            return true;
        }

        public async Task DeleteAsync(int id)
        {
            if (id <= 0)
            {
                // TODO: Add logger for exception message
                throw new BusinessException($"Business exception occurred with message : id with value {id} is invalid");
            }

            _blogRepository.Delete(id);

            await _blogRepository.UnitOfWork.CommitAsync();
        }
    }
}
