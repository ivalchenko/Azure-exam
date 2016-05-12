namespace HelloWorld.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _240620150015 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "Post_PostId", c => c.Int());
            CreateIndex("dbo.Comments", "Post_PostId");
            AddForeignKey("dbo.Comments", "Post_PostId", "dbo.Posts", "PostId");
            DropColumn("dbo.Comments", "PostId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "PostId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Comments", "Post_PostId", "dbo.Posts");
            DropIndex("dbo.Comments", new[] { "Post_PostId" });
            DropColumn("dbo.Comments", "Post_PostId");
        }
    }
}
