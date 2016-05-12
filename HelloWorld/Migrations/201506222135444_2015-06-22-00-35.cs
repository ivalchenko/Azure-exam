namespace HelloWorld.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _201506220035 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Comments", "CommentDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "CommentDate", c => c.String());
        }
    }
}
