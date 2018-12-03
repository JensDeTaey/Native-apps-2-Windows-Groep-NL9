namespace Windows_Backend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Businesses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Category = c.String(),
                        LinkWebsite = c.String(),
                        NumberOfSubscribers = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Establishments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                        Picture = c.String(),
                        Business_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Businesses", t => t.Business_Id)
                .Index(t => t.Business_Id);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        BeginDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Establishment_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Establishments", t => t.Establishment_Id)
                .Index(t => t.Establishment_Id);
            
            CreateTable(
                "dbo.OpeningHours",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Day = c.Short(nullable: false),
                        OpeningsHour = c.String(),
                        ClosingsHour = c.String(),
                        Establishment_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Establishments", t => t.Establishment_Id)
                .Index(t => t.Establishment_Id);
            
            CreateTable(
                "dbo.Promotions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        IsDiscountCoupon = c.Boolean(nullable: false),
                        Business_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Businesses", t => t.Business_Id)
                .Index(t => t.Business_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Promotions", "Business_Id", "dbo.Businesses");
            DropForeignKey("dbo.Establishments", "Business_Id", "dbo.Businesses");
            DropForeignKey("dbo.OpeningHours", "Establishment_Id", "dbo.Establishments");
            DropForeignKey("dbo.Events", "Establishment_Id", "dbo.Establishments");
            DropIndex("dbo.Promotions", new[] { "Business_Id" });
            DropIndex("dbo.OpeningHours", new[] { "Establishment_Id" });
            DropIndex("dbo.Events", new[] { "Establishment_Id" });
            DropIndex("dbo.Establishments", new[] { "Business_Id" });
            DropTable("dbo.Promotions");
            DropTable("dbo.OpeningHours");
            DropTable("dbo.Events");
            DropTable("dbo.Establishments");
            DropTable("dbo.Businesses");
        }
    }
}
