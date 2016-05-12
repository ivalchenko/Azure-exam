namespace HelloWorld.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _201506231431 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Posts", "SelectedTag");
            DropColumn("dbo.Posts", "TagList_DataGroupField");
            DropColumn("dbo.Posts", "TagList_DataTextField");
            DropColumn("dbo.Posts", "TagList_DataValueField");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "TagList_DataValueField", c => c.String());
            AddColumn("dbo.Posts", "TagList_DataTextField", c => c.String());
            AddColumn("dbo.Posts", "TagList_DataGroupField", c => c.String());
            AddColumn("dbo.Posts", "SelectedTag", c => c.String(nullable: false));
        }
    }
}
