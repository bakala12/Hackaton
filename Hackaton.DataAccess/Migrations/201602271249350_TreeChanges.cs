namespace Hackaton.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TreeChanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trees", "InventoryNumber", c => c.String());
            AddColumn("dbo.Trees", "Address", c => c.String());
            DropColumn("dbo.Trees", "District");
            DropColumn("dbo.Trees", "Street");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Trees", "Street", c => c.String());
            AddColumn("dbo.Trees", "District", c => c.String());
            DropColumn("dbo.Trees", "Address");
            DropColumn("dbo.Trees", "InventoryNumber");
        }
    }
}
