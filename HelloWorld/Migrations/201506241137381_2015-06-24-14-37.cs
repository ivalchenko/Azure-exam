namespace HelloWorld.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _201506241437 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicationUserPosts",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        Post_PostId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.Post_PostId })
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .ForeignKey("dbo.Posts", t => t.Post_PostId, cascadeDelete: true)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.Post_PostId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplicationUserPosts", "Post_PostId", "dbo.Posts");
            DropForeignKey("dbo.ApplicationUserPosts", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.ApplicationUserPosts", new[] { "Post_PostId" });
            DropIndex("dbo.ApplicationUserPosts", new[] { "ApplicationUser_Id" });
            DropTable("dbo.ApplicationUserPosts");
        }
    }
}
