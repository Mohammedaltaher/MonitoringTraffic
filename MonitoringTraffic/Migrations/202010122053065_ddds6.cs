namespace MonitoringTraffic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ddds6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cameras", "Latitude", c => c.Single());
            AddColumn("dbo.Cameras", "Longitude", c => c.Single());
            AddColumn("dbo.Cameras", "IsInStreetBegaining", c => c.Boolean());
            AddColumn("dbo.Streets", "From", c => c.String());
            AddColumn("dbo.Streets", "To", c => c.String());
            AlterColumn("dbo.Cameras", "Diriction", c => c.String());
            DropColumn("dbo.Cameras", "Pin");
            DropColumn("dbo.Streets", "Diractions");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Streets", "Diractions", c => c.String());
            AddColumn("dbo.Cameras", "Pin", c => c.String());
            AlterColumn("dbo.Cameras", "Diriction", c => c.Int());
            DropColumn("dbo.Streets", "To");
            DropColumn("dbo.Streets", "From");
            DropColumn("dbo.Cameras", "IsInStreetBegaining");
            DropColumn("dbo.Cameras", "Longitude");
            DropColumn("dbo.Cameras", "Latitude");
        }
    }
}
