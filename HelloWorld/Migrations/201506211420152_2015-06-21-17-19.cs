namespace HelloWorld.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _201506211719 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Posts", "Date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "Date", c => c.String(nullable: false));
        }
    }
}
