namespace Garage2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ParkedVehicles", "TypeOf", c => c.Int(nullable: false));
            DropColumn("dbo.ParkedVehicles", "Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ParkedVehicles", "Type", c => c.String());
            DropColumn("dbo.ParkedVehicles", "TypeOf");
        }
    }
}
