namespace MonitoringTraffic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCameraModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cameras",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StreetID = c.Int(nullable: false),
                        Pin = c.String(),
                        IpAddress = c.String(),
                        IsDeleted = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Streets", t => t.StreetID, cascadeDelete: true)
                .Index(t => t.StreetID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cameras", "StreetID", "dbo.Streets");
            DropIndex("dbo.Cameras", new[] { "StreetID" });
            DropTable("dbo.Cameras");
        }
    }
}
