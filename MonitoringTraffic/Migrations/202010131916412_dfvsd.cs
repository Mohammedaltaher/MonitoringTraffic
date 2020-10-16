namespace MonitoringTraffic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dfvsd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CameraRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CameraID = c.Int(nullable: false),
                        Date = c.DateTime(),
                        InCount = c.Int(),
                        OutCount = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cameras", t => t.CameraID, cascadeDelete: true)
                .Index(t => t.CameraID);
            
            DropColumn("dbo.Cameras", "IsInStreetBegaining");
            DropColumn("dbo.Cameras", "Date");
            DropColumn("dbo.Cameras", "InCount");
            DropColumn("dbo.Cameras", "OutCount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cameras", "OutCount", c => c.Int());
            AddColumn("dbo.Cameras", "InCount", c => c.Int());
            AddColumn("dbo.Cameras", "Date", c => c.DateTime());
            AddColumn("dbo.Cameras", "IsInStreetBegaining", c => c.Boolean());
            DropForeignKey("dbo.CameraRequests", "CameraID", "dbo.Cameras");
            DropIndex("dbo.CameraRequests", new[] { "CameraID" });
            DropTable("dbo.CameraRequests");
        }
    }
}
