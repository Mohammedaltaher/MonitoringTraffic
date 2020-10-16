namespace MonitoringTraffic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dfvsddwed : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cameras", "IsInStreetBegaining", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cameras", "IsInStreetBegaining");
        }
    }
}
