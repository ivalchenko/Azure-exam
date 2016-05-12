namespace HelloWorld.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _201506241624 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "ImagePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "ImagePath");
        }
    }
}
