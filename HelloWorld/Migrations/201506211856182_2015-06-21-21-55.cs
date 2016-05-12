namespace HelloWorld.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _201506212155 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "Author", c => c.String());
            DropColumn("dbo.Comments", "AuthorId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "AuthorId", c => c.Int(nullable: false));
            DropColumn("dbo.Comments", "Author");
        }
    }
}
