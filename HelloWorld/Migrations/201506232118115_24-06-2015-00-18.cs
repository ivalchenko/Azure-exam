namespace HelloWorld.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _240620150018 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "PostComment_PostCommentId", "dbo.PostComments");
            DropForeignKey("dbo.PostComments", "Post_PostId", "dbo.Posts");
            DropIndex("dbo.Comments", new[] { "PostComment_PostCommentId" });
            DropIndex("dbo.PostComments", new[] { "Post_PostId" });
            DropColumn("dbo.Comments", "PostComment_PostCommentId");
            DropTable("dbo.PostComments");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PostComments",
                c => new
                    {
                        PostCommentId = c.Int(nullable: false, identity: true),
                        Post_PostId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PostCommentId);
            
            AddColumn("dbo.Comments", "PostComment_PostCommentId", c => c.Int());
            CreateIndex("dbo.PostComments", "Post_PostId");
            CreateIndex("dbo.Comments", "PostComment_PostCommentId");
            AddForeignKey("dbo.PostComments", "Post_PostId", "dbo.Posts", "PostId", cascadeDelete: true);
            AddForeignKey("dbo.Comments", "PostComment_PostCommentId", "dbo.PostComments", "PostCommentId");
        }
    }
}
