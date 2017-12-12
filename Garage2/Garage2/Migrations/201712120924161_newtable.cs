namespace Garage2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newtable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Receipts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypeOf = c.Int(nullable: false),
                        Registration = c.String(),
                        Color = c.String(),
                        Model = c.String(),
                        NumberOfWheels = c.String(),
                        ArrivalTime = c.DateTime(nullable: false),
                        Departure = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Receipts");
        }
    }
}
