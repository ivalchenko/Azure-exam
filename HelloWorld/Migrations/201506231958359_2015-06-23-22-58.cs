namespace HelloWorld.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _201506232258 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "CommentsNumber", c => c.Int(nullable: false));
            AddColumn("dbo.Posts", "LikesNumber", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "LikesNumber");
            DropColumn("dbo.Posts", "CommentsNumber");
        }
    }
}
