namespace Hackaton.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dasdasddsadsa : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Events", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Users", "Event_Id", "dbo.Events");
            DropIndex("dbo.Events", new[] { "User_Id" });
            DropIndex("dbo.Users", new[] { "Event_Id" });
            CreateTable(
                "dbo.UsersEvents",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        EventId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.EventId })
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Events", t => t.EventId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.EventId);
            
            DropColumn("dbo.Events", "User_Id");
            DropColumn("dbo.Users", "Event_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Event_Id", c => c.Int());
            AddColumn("dbo.Events", "User_Id", c => c.Int());
            DropForeignKey("dbo.UsersEvents", "EventId", "dbo.Events");
            DropForeignKey("dbo.UsersEvents", "UserId", "dbo.Users");
            DropIndex("dbo.UsersEvents", new[] { "EventId" });
            DropIndex("dbo.UsersEvents", new[] { "UserId" });
            DropTable("dbo.UsersEvents");
            CreateIndex("dbo.Users", "Event_Id");
            CreateIndex("dbo.Events", "User_Id");
            AddForeignKey("dbo.Users", "Event_Id", "dbo.Events", "Id");
            AddForeignKey("dbo.Events", "User_Id", "dbo.Users", "Id");
        }
    }
}
