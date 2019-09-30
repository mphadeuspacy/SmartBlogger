using System.Data.Common;
using System.Data.Entity;
using System.Threading.Tasks;
using Nls.SmartBlogger.EfPersister.Abstracts;
using Nls.SmartBlogger.EfPersister.Entities;

namespace Nls.SmartBlogger.EfPersister
{
    public class SmartBloggerDbContext : DbContext, IUnitOfWork
    {
        public SmartBloggerDbContext(string connection) 
            : base("SmartBloggerDbContext")
        {
        }

        //This constructor is used in tests
        public SmartBloggerDbContext(DbConnection connection)
            : base(connection, true)
        {
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public Task<int> CommitAsync()
        {
            return base.SaveChangesAsync();
        }
    }
}
