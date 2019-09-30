using System.Data.Entity;
using Autofac;
using Nls.SmartBlogger.Core.DomainServices;
using Nls.SmartBlogger.EfPersister;
using Nls.SmartBlogger.EfPersister.Abstracts;
using Nls.SmartBlogger.EfPersister.Repositories;

namespace SmartBlogger.UnitTests.Modules
{
    public class InfrastructureUnitTestsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            const string connectionString = "SmartBloggerDbContext";

            var smartDbContext = new SmartBloggerDbContext(connectionString);

            var blogRepository = new BlogRepository(smartDbContext);

            //var blogService = new BlogService(blogRepository);

            //builder.RegisterType<DbContext>().AsSelf();
            //builder.RegisterType<IUnitOfWork>().AsSelf();

            //builder.RegisterType<SmartBloggerDbContext>()
            //    .As<IUnitOfWork>()
            //    .As<DbContext>()
            //    .SingleInstance();

            //builder.RegisterType<BlogRepository>()
            //    .As<IBlogRepository>()
            //    .SingleInstance();

            builder.RegisterType<BlogService>()
                .As<IBlogService>()
                .WithParameter("blogRepository", blogRepository)
                .SingleInstance();
        }
    }
}
