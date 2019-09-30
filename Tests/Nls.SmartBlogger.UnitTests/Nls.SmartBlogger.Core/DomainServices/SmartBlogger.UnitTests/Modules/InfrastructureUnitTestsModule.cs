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
            //builder.RegisterType<SmartBloggerDbContext>()
            //    .As<IUnitOfWork>()
            //    .InstancePerLifetimeScope();

            //builder.RegisterType<BlogRepository>()
            //    .As<IBlogRepository>()
            //    .InstancePerLifetimeScope();

            builder.RegisterType<BlogService>()
                .As<IBlogService>()
                .InstancePerLifetimeScope();
        }
        
    }
}
