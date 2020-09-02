namespace MonitoringTraffic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addStreetModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Streets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CityID = c.Int(nullable: false),
                        Name = c.String(),
                        IsDeleted = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityID, cascadeDelete: true)
                .Index(t => t.CityID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Streets", "CityID", "dbo.Cities");
            DropIndex("dbo.Streets", new[] { "CityID" });
            DropTable("dbo.Streets");
        }
    }
}
