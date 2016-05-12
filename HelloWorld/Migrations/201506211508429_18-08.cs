namespace HelloWorld.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1808 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Comments", "Date", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Comments", "Date", c => c.String(nullable: false));
        }
    }
}
