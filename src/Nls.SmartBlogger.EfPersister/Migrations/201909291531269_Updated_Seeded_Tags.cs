namespace Nls.SmartBlogger.EfPersister.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updated_Seeded_Tags : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tags", "BlogId", "dbo.Blogs");
            DropIndex("dbo.Tags", new[] { "BlogId" });
            AddColumn("dbo.Blogs", "TagId", c => c.Int());
            AddColumn("dbo.Blogs", "Tag_TagKey", c => c.Int());
            CreateIndex("dbo.Blogs", "Tag_TagKey");
            AddForeignKey("dbo.Blogs", "Tag_TagKey", "dbo.Tags", "TagKey");
            DropColumn("dbo.Tags", "BlogId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tags", "BlogId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Blogs", "Tag_TagKey", "dbo.Tags");
            DropIndex("dbo.Blogs", new[] { "Tag_TagKey" });
            DropColumn("dbo.Blogs", "Tag_TagKey");
            DropColumn("dbo.Blogs", "TagId");
            CreateIndex("dbo.Tags", "BlogId");
            AddForeignKey("dbo.Tags", "BlogId", "dbo.Blogs", "BlogId", cascadeDelete: true);
        }
    }
}
