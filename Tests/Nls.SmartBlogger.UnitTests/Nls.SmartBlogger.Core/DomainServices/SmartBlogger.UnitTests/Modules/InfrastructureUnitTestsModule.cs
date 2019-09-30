using System.Data.Entity;
using Autofac;
using Nls.SmartBlogger.Core.DomainServices;
using Nls.SmartBlogger.EfPersister;
using Nls.SmartBlogger.EfPersister.Abstracts;
using Nls.SmartBlogger.EfPersister.Repositories;
using SmartBlogger.Tests.Common;

namespace SmartBlogger.UnitTests.Modules
{
    public class InfrastructureUnitTestsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var smartDbContext = new SmartBloggerDbContext(SmartBloggerTestsConsts.connectionString);

            var blogRepository = new BlogRepository(smartDbContext);
            
            builder.RegisterType<BlogRepository>()
                .As<IBlogRepository>()
                .WithParameter("context", smartDbContext)
                .SingleInstance();

            builder.RegisterType<BlogService>()
                .As<IBlogService>()
                .WithParameter("blogRepository", blogRepository)
                .SingleInstance();
        }
    }
}
