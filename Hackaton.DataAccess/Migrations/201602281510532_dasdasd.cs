namespace Hackaton.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dasdasd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.UsersEvents", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UsersEvents", "EventId", "dbo.Events");
            DropIndex("dbo.AspNetUsers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "Image_Id" });
            DropIndex("dbo.Events", new[] { "Organizer_Id" });
            DropIndex("dbo.UsersEvents", new[] { "UserId" });
            DropIndex("dbo.UsersEvents", new[] { "EventId" });
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Gender = c.Int(nullable: false),
                        Age = c.Int(nullable: false),
                        Height = c.Int(nullable: false),
                        Weight = c.Double(nullable: false),
                        AdvanceLevel = c.Int(nullable: false),
                        ApplicationUserId = c.String(),
                        Image_Id = c.Int(),
                        Event_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.Event_Id)
                .Index(t => t.Image_Id)
                .Index(t => t.Event_Id);
            
            AddColumn("dbo.Events", "User_Id", c => c.Int());
            AlterColumn("dbo.Events", "Organizer_Id", c => c.Int());
            CreateIndex("dbo.Events", "User_Id");
            CreateIndex("dbo.Events", "Organizer_Id");
            AddForeignKey("dbo.Events", "User_Id", "dbo.Users", "Id");
            //DropColumn("dbo.AspNetUsers", "Name");
            //DropColumn("dbo.AspNetUsers", "Surname");
            //DropColumn("dbo.AspNetUsers", "Gender");
            //DropColumn("dbo.AspNetUsers", "Age");
            //DropColumn("dbo.AspNetUsers", "Height");
            //DropColumn("dbo.AspNetUsers", "Weight");
            //DropColumn("dbo.AspNetUsers", "AdvanceLevel");
            //DropColumn("dbo.AspNetUsers", "ApplicationUser_Id");
            //DropColumn("dbo.AspNetUsers", "Image_Id");
            //DropTable("dbo.UsersEvents");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UsersEvents",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        EventId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.EventId });
            
            AddColumn("dbo.AspNetUsers", "Image_Id", c => c.Int());
            AddColumn("dbo.AspNetUsers", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUsers", "AdvanceLevel", c => c.Int());
            AddColumn("dbo.AspNetUsers", "Weight", c => c.Double());
            AddColumn("dbo.AspNetUsers", "Height", c => c.Int());
            AddColumn("dbo.AspNetUsers", "Age", c => c.Int());
            AddColumn("dbo.AspNetUsers", "Gender", c => c.Int());
            AddColumn("dbo.AspNetUsers", "Surname", c => c.String());
            AddColumn("dbo.AspNetUsers", "Name", c => c.String());
            DropForeignKey("dbo.Users", "Event_Id", "dbo.Events");
            DropForeignKey("dbo.Events", "User_Id", "dbo.Users");
            DropIndex("dbo.Users", new[] { "Event_Id" });
            DropIndex("dbo.Users", new[] { "Image_Id" });
            DropIndex("dbo.Events", new[] { "Organizer_Id" });
            DropIndex("dbo.Events", new[] { "User_Id" });
            AlterColumn("dbo.Events", "Organizer_Id", c => c.String(maxLength: 128));
            DropColumn("dbo.Events", "User_Id");
            DropTable("dbo.Users");
            CreateIndex("dbo.UsersEvents", "EventId");
            CreateIndex("dbo.UsersEvents", "UserId");
            CreateIndex("dbo.Events", "Organizer_Id");
            CreateIndex("dbo.AspNetUsers", "Image_Id");
            CreateIndex("dbo.AspNetUsers", "ApplicationUser_Id");
            AddForeignKey("dbo.UsersEvents", "EventId", "dbo.Events", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UsersEvents", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUsers", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
