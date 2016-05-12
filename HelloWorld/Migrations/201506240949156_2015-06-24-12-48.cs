namespace HelloWorld.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _201506241248 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Posts", "LikesNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "LikesNumber", c => c.Int(nullable: false));
        }
    }
}
