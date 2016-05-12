namespace HelloWorld.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _201506211129 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "AuthorId", c => c.Int(nullable: false));
            AddColumn("dbo.Comments", "PostId", c => c.Int(nullable: false));
            DropColumn("dbo.Comments", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "UserId", c => c.Int(nullable: false));
            DropColumn("dbo.Comments", "PostId");
            DropColumn("dbo.Comments", "AuthorId");
        }
    }
}
