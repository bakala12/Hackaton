namespace Hackaton.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelationUserEvents : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Events", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "Event_Id", "dbo.Events");
            DropIndex("dbo.AspNetUsers", new[] { "Event_Id" });
            DropIndex("dbo.Events", new[] { "User_Id" });
            CreateTable(
                "dbo.UsersEvents",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        EventId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.EventId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Events", t => t.EventId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.EventId);
            
            DropColumn("dbo.AspNetUsers", "Event_Id");
            DropColumn("dbo.Events", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "User_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUsers", "Event_Id", c => c.Int());
            DropForeignKey("dbo.UsersEvents", "EventId", "dbo.Events");
            DropForeignKey("dbo.UsersEvents", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.UsersEvents", new[] { "EventId" });
            DropIndex("dbo.UsersEvents", new[] { "UserId" });
            DropTable("dbo.UsersEvents");
            CreateIndex("dbo.Events", "User_Id");
            CreateIndex("dbo.AspNetUsers", "Event_Id");
            AddForeignKey("dbo.AspNetUsers", "Event_Id", "dbo.Events", "Id");
            AddForeignKey("dbo.Events", "User_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
