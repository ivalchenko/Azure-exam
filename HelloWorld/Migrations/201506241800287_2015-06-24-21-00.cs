namespace HelloWorld.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _201506242100 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "IsVisible", c => c.Boolean(nullable: false));
            DropColumn("dbo.Comments", "IsHiddenMedia");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "IsHiddenMedia", c => c.Boolean(nullable: false));
            DropColumn("dbo.Comments", "IsVisible");
        }
    }
}
