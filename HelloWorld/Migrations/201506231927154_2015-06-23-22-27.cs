namespace HelloWorld.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _201506232227 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "PostComment_PostCommentId", c => c.Int());
            CreateIndex("dbo.Comments", "PostComment_PostCommentId");
            AddForeignKey("dbo.Comments", "PostComment_PostCommentId", "dbo.PostComments", "PostCommentId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "PostComment_PostCommentId", "dbo.PostComments");
            DropIndex("dbo.Comments", new[] { "PostComment_PostCommentId" });
            DropColumn("dbo.Comments", "PostComment_PostCommentId");
        }
    }
}
