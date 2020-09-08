namespace MonitoringTraffic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateCamera : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cameras", "Diriction", c => c.Int(nullable: false));
            AddColumn("dbo.Cameras", "IsIn", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cameras", "IsIn");
            DropColumn("dbo.Cameras", "Diriction");
        }
    }
}
