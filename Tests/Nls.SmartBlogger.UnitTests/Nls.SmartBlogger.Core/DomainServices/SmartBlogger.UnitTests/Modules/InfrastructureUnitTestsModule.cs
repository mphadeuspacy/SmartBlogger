using Autofac;
using Nls.SmartBlogger.Core.DomainServices;

namespace SmartBlogger.UnitTests.Modules
{
    public class InfrastructureUnitTestsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(db => new BlogService()).As<IBlogService>();
        }
        
    }
}
