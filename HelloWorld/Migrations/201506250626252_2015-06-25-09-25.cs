namespace HelloWorld.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _201506250925 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tags", "TagName", c => c.String(nullable: false, maxLength: 60));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tags", "TagName", c => c.String(nullable: false));
        }
    }
}
