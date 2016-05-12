namespace HelloWorld.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20150623 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TagPosts", "Tag_TagId", "dbo.Tags");
            DropForeignKey("dbo.TagPosts", "Post_PostId", "dbo.Posts");
            DropIndex("dbo.TagPosts", new[] { "Tag_TagId" });
            DropIndex("dbo.TagPosts", new[] { "Post_PostId" });
            AddColumn("dbo.Posts", "SelectedTag", c => c.String(nullable: false));
            AddColumn("dbo.Posts", "TagList_DataGroupField", c => c.String());
            AddColumn("dbo.Posts", "TagList_DataTextField", c => c.String());
            AddColumn("dbo.Posts", "TagList_DataValueField", c => c.String());
            AddColumn("dbo.Posts", "Tag_TagId", c => c.Int());
            CreateIndex("dbo.Posts", "Tag_TagId");
            AddForeignKey("dbo.Posts", "Tag_TagId", "dbo.Tags", "TagId");
            DropTable("dbo.TagPosts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TagPosts",
                c => new
                    {
                        Tag_TagId = c.Int(nullable: false),
                        Post_PostId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_TagId, t.Post_PostId });
            
            DropForeignKey("dbo.Posts", "Tag_TagId", "dbo.Tags");
            DropIndex("dbo.Posts", new[] { "Tag_TagId" });
            DropColumn("dbo.Posts", "Tag_TagId");
            DropColumn("dbo.Posts", "TagList_DataValueField");
            DropColumn("dbo.Posts", "TagList_DataTextField");
            DropColumn("dbo.Posts", "TagList_DataGroupField");
            DropColumn("dbo.Posts", "SelectedTag");
            CreateIndex("dbo.TagPosts", "Post_PostId");
            CreateIndex("dbo.TagPosts", "Tag_TagId");
            AddForeignKey("dbo.TagPosts", "Post_PostId", "dbo.Posts", "PostId", cascadeDelete: true);
            AddForeignKey("dbo.TagPosts", "Tag_TagId", "dbo.Tags", "TagId", cascadeDelete: true);
        }
    }
}
