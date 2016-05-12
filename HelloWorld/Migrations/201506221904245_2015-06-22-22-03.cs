namespace HelloWorld.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _201506222203 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "AuthorId", c => c.String());
            DropColumn("dbo.Comments", "Author");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "Author", c => c.String());
            DropColumn("dbo.Comments", "AuthorId");
        }
    }
}
