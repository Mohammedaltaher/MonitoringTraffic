namespace MonitoringTraffic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ddds : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Streets", "DiractionsID", "dbo.Diractions");
            DropIndex("dbo.Streets", new[] { "DiractionsID" });
            AddColumn("dbo.Streets", "Diractions", c => c.String());
            DropTable("dbo.Diractions");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Diractions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        From = c.String(),
                        To = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Streets", "Diractions");
            CreateIndex("dbo.Streets", "DiractionsID");
            AddForeignKey("dbo.Streets", "DiractionsID", "dbo.Diractions", "Id");
        }
    }
}
