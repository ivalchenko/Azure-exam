namespace HelloWorld.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newnewnew : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "CommentDate", c => c.String());
            AddColumn("dbo.Posts", "PostDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Comments", "Date");
            DropColumn("dbo.Posts", "Date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "Date", c => c.String(nullable: false));
            AddColumn("dbo.Comments", "Date", c => c.String());
            DropColumn("dbo.Posts", "PostDate");
            DropColumn("dbo.Comments", "CommentDate");
        }
    }
}
