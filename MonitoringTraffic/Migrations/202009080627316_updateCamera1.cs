namespace MonitoringTraffic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateCamera1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cameras", "Date", c => c.DateTime());
            AddColumn("dbo.Cameras", "Count", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cameras", "Count");
            DropColumn("dbo.Cameras", "Date");
        }
    }
}
