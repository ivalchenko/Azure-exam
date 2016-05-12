namespace HelloWorld.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _201506240926 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Avatars");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Avatars",
                c => new
                    {
                        AvatarId = c.Int(nullable: false, identity: true),
                        ImagePath = c.String(nullable: false),
                        UserId = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.AvatarId);
            
        }
    }
}
