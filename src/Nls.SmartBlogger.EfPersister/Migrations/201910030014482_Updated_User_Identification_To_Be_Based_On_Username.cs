namespace Nls.SmartBlogger.EfPersister.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updated_User_Identification_To_Be_Based_On_Username : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Blogs", "AuthorId", c => c.String());
            AlterColumn("dbo.Blogs", "CreatorUserId", c => c.String());
            AlterColumn("dbo.Blogs", "LastModifierUserId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Blogs", "LastModifierUserId", c => c.Int());
            AlterColumn("dbo.Blogs", "CreatorUserId", c => c.Int());
            AlterColumn("dbo.Blogs", "AuthorId", c => c.Int(nullable: false));
        }
    }
}
