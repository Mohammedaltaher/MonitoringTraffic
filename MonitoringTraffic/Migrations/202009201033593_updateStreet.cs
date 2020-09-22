namespace MonitoringTraffic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateStreet : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Streets", "Capacity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Streets", "Capacity");
        }
    }
}
