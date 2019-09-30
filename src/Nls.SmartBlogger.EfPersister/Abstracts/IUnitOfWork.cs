using System;
using System.Threading.Tasks;

namespace Nls.SmartBlogger.EfPersister.Abstracts
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> CommitAsync();
    }
}
