namespace HelloWorld.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _201506211401 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PostComments",
                c => new
                    {
                        PostCommentId = c.Int(nullable: false, identity: true),
                        Post_PostId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PostCommentId)
                .ForeignKey("dbo.Posts", t => t.Post_PostId, cascadeDelete: true)
                .Index(t => t.Post_PostId);
            
            AddColumn("dbo.Comments", "PostComment_PostCommentId", c => c.Int());
            CreateIndex("dbo.Comments", "PostComment_PostCommentId");
            AddForeignKey("dbo.Comments", "PostComment_PostCommentId", "dbo.PostComments", "PostCommentId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PostComments", "Post_PostId", "dbo.Posts");
            DropForeignKey("dbo.Comments", "PostComment_PostCommentId", "dbo.PostComments");
            DropIndex("dbo.PostComments", new[] { "Post_PostId" });
            DropIndex("dbo.Comments", new[] { "PostComment_PostCommentId" });
            DropColumn("dbo.Comments", "PostComment_PostCommentId");
            DropTable("dbo.PostComments");
        }
    }
}
