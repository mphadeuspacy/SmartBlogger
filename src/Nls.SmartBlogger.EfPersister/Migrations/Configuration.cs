using System.Linq;
using Nls.SmartBlogger.EfPersister.Entities;

namespace Nls.SmartBlogger.EfPersister.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<SmartBloggerDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SmartBloggerDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            CreateDefaultSmartBloggerTags(context);

        }

        // Seed Tag Lookup Table
        private void CreateDefaultSmartBloggerTags(SmartBloggerDbContext context)
        {
            Tag.ListOfAllPredefinedTags
                .ToList()
                .ForEach(tag =>
                {
                    context.Tags.AddOrUpdate(new Tag(tag.Value, tag.Name));
                });

            context.SaveChanges();
        }
    }
}
