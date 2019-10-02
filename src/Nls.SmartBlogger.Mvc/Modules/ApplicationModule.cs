using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Nls.SmartBlogger.Common;
using Nls.SmartBlogger.Core.DomainServices;
using Nls.SmartBlogger.EfPersister;
using Nls.SmartBlogger.EfPersister.Abstracts;
using Nls.SmartBlogger.EfPersister.Repositories;

namespace Nls.SmartBlogger.Mvc.Modules
{
    public class ApplicationModule : Autofac.Module
    {
        private readonly string _connectionString;

        public ApplicationModule(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void Load(ContainerBuilder builder)
        {
            var smartDbContext = new SmartBloggerDbContext(_connectionString);

            builder.RegisterType<BlogRepository>()
                .As<IBlogRepository>()
                .WithParameter("context", smartDbContext)
                .SingleInstance();

            builder.RegisterType<BlogService>()
                .As<IBlogService>()
                .SingleInstance();

            builder.RegisterType<CloudBlobStorageService>()
                .As<ICloudBlobStorageService>()
                .SingleInstance();
        }
    }
}
