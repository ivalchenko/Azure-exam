namespace HelloWorld.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _201506241404 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Posts", "CommentsNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "CommentsNumber", c => c.Int(nullable: false));
        }
    }
}
