namespace Hackaton.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteTreeNumber : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Trees", "Number");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Trees", "Number", c => c.Int(nullable: false));
        }
    }
}
