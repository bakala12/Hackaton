namespace Hackaton.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class entitiesAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        EventType = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Organizer_Id = c.String(maxLength: 128),
                        Tree_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Organizer_Id)
                .ForeignKey("dbo.Trees", t => t.Tree_Id)
                .Index(t => t.Organizer_Id)
                .Index(t => t.Tree_Id);
            
            CreateTable(
                "dbo.UserImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Image = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Trees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CoordX = c.Double(nullable: false),
                        CoordY = c.Double(nullable: false),
                        District = c.String(),
                        Street = c.String(),
                        Number = c.Int(nullable: false),
                        Location = c.String(),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "Name", c => c.String());
            AddColumn("dbo.AspNetUsers", "Surname", c => c.String());
            AddColumn("dbo.AspNetUsers", "Gender", c => c.Int());
            AddColumn("dbo.AspNetUsers", "Age", c => c.Int());
            AddColumn("dbo.AspNetUsers", "Height", c => c.Int());
            AddColumn("dbo.AspNetUsers", "Weight", c => c.Double());
            AddColumn("dbo.AspNetUsers", "AdvanceLevel", c => c.Int());
            AddColumn("dbo.AspNetUsers", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.AspNetUsers", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUsers", "Image_Id", c => c.Int());
            AddColumn("dbo.AspNetUsers", "Event_Id", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "ApplicationUser_Id");
            CreateIndex("dbo.AspNetUsers", "Image_Id");
            CreateIndex("dbo.AspNetUsers", "Event_Id");
            AddForeignKey("dbo.AspNetUsers", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AspNetUsers", "Image_Id", "dbo.UserImages", "Id");
            AddForeignKey("dbo.AspNetUsers", "Event_Id", "dbo.Events", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "Tree_Id", "dbo.Trees");
            DropForeignKey("dbo.AspNetUsers", "Event_Id", "dbo.Events");
            DropForeignKey("dbo.Events", "Organizer_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "Image_Id", "dbo.UserImages");
            DropForeignKey("dbo.AspNetUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Events", new[] { "Tree_Id" });
            DropIndex("dbo.Events", new[] { "Organizer_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "Event_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "Image_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.AspNetUsers", "Event_Id");
            DropColumn("dbo.AspNetUsers", "Image_Id");
            DropColumn("dbo.AspNetUsers", "ApplicationUser_Id");
            DropColumn("dbo.AspNetUsers", "Discriminator");
            DropColumn("dbo.AspNetUsers", "AdvanceLevel");
            DropColumn("dbo.AspNetUsers", "Weight");
            DropColumn("dbo.AspNetUsers", "Height");
            DropColumn("dbo.AspNetUsers", "Age");
            DropColumn("dbo.AspNetUsers", "Gender");
            DropColumn("dbo.AspNetUsers", "Surname");
            DropColumn("dbo.AspNetUsers", "Name");
            DropTable("dbo.Trees");
            DropTable("dbo.UserImages");
            DropTable("dbo.Events");
        }
    }
}
