namespace MonitoringTraffic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addUserAndUserType2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        Username = c.String(),
                        UserTypeId = c.Int(nullable: false),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        IsDeleted = c.String(),
                        CreateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserTypes", t => t.UserTypeId, cascadeDelete: true)
                .Index(t => t.UserTypeId);
            
            CreateTable(
                "dbo.UserTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsDeleted = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "UserTypeId", "dbo.UserTypes");
            DropIndex("dbo.Users", new[] { "UserTypeId" });
            DropTable("dbo.UserTypes");
            DropTable("dbo.Users");
        }
    }
}
