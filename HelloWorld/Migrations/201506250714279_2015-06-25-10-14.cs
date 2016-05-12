namespace HelloWorld.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _201506251014 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Comments", "Description", c => c.String(nullable: false, maxLength: 300));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Comments", "Description", c => c.String(nullable: false));
        }
    }
}
