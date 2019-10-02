using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Nls.SmartBlogger.Common;
using Nls.SmartBlogger.Mvc.Modules;

namespace Nls.SmartBlogger.Mvc.App_Start
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            // Register dependencies in controllers
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // Register dependencies in filter attributes
            builder.RegisterFilterProvider();

            // Register dependencies in custom views
            builder.RegisterSource(new ViewRegistrationSource());

            // Register our Application dependencies
            builder.RegisterModule(new ApplicationModule(SmartBloggerConsts.ConnectionString));

            var container = builder.Build();

            // Set MVC DI resolver to use our Autofac container
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
