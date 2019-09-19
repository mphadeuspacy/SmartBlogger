using Autofac;
using Autofac.Core;

namespace SmartBlogger.Tests.Common
{
    /// <summary>
    /// This will serves as a base class for all test classes, i.e,
    /// they should all inherit from this to use Autofac IoC properly
    /// </summary>
    /// <typeparam name="TModule"></typeparam>
    public class TestBase<TModule> where TModule : IModule, new()
    {
        private readonly IContainer _container;

        protected TestBase()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule(new TModule());

            _container = builder.Build();
        }

        protected TEntity Resolve<TEntity>()
        {
            return _container.Resolve<TEntity>();
        }

        protected void Shutdown()
        {
            _container.Dispose();
        }
    }
}
