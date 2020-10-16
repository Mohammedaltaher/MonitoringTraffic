namespace MonitoringTraffic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dada : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cameras", "InCount", c => c.Int());
            AddColumn("dbo.Cameras", "OutCount", c => c.Int());
            DropColumn("dbo.Cameras", "IsIn");
            DropColumn("dbo.Cameras", "Count");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cameras", "Count", c => c.Int());
            AddColumn("dbo.Cameras", "IsIn", c => c.Boolean());
            DropColumn("dbo.Cameras", "OutCount");
            DropColumn("dbo.Cameras", "InCount");
        }
    }
}
