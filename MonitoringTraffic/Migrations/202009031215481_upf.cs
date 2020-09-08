namespace MonitoringTraffic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class upf : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cameras", "Diriction", c => c.Int());
            AlterColumn("dbo.Cameras", "IsIn", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cameras", "IsIn", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Cameras", "Diriction", c => c.Int(nullable: false));
        }
    }
}
