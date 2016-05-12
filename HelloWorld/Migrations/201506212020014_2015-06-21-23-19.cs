namespace HelloWorld.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _201506212319 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "Date", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "Date");
        }
    }
}
