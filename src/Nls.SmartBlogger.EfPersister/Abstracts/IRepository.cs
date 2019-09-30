namespace Nls.SmartBlogger.EfPersister.Abstracts
{
    public interface IRepository<TEntity>
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
