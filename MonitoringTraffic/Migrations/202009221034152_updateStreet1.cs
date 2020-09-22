namespace MonitoringTraffic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateStreet1 : DbMigration
    {
        public override void Up()
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
            
            CreateTable(
                "dbo.StreetPosstions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StreetID = c.Int(nullable: false),
                        Latitude = c.Single(),
                        Longitude = c.Single(),
                        Name = c.String(),
                        IsDeleted = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Streets", t => t.StreetID, cascadeDelete: true)
                .Index(t => t.StreetID);
            
            AddColumn("dbo.Streets", "StartLatitude", c => c.Single());
            AddColumn("dbo.Streets", "StartLongitude", c => c.Single());
            AddColumn("dbo.Streets", "EndLatitude", c => c.Single());
            AddColumn("dbo.Streets", "EndLongitude", c => c.Single());
            AddColumn("dbo.Streets", "DiractionsID", c => c.Int(nullable: true));
            CreateIndex("dbo.Streets", "DiractionsID");
            AddForeignKey("dbo.Streets", "DiractionsID", "dbo.Diractions", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StreetPosstions", "StreetID", "dbo.Streets");
            DropForeignKey("dbo.Streets", "DiractionsID", "dbo.Diractions");
            DropIndex("dbo.StreetPosstions", new[] { "StreetID" });
            DropIndex("dbo.Streets", new[] { "DiractionsID" });
            DropColumn("dbo.Streets", "DiractionsID");
            DropColumn("dbo.Streets", "EndLongitude");
            DropColumn("dbo.Streets", "EndLatitude");
            DropColumn("dbo.Streets", "StartLongitude");
            DropColumn("dbo.Streets", "StartLatitude");
            DropTable("dbo.StreetPosstions");
            DropTable("dbo.Diractions");
        }
    }
}
