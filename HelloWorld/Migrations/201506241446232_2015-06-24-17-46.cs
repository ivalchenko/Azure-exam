namespace HelloWorld.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _201506241746 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "IsHiddenMedia", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "IsHiddenMedia");
        }
    }
}
