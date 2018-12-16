namespace BackendV7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "BusinessId", "dbo.Businesses");
            DropIndex("dbo.AspNetUsers", new[] { "BusinessId" });
            AddColumn("dbo.Businesses", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Businesses", "UserId");
            AddForeignKey("dbo.Businesses", "UserId", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.AspNetUsers", "BusinessId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "BusinessId", c => c.Int());
            DropForeignKey("dbo.Businesses", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Businesses", new[] { "UserId" });
            DropColumn("dbo.Businesses", "UserId");
            CreateIndex("dbo.AspNetUsers", "BusinessId");
            AddForeignKey("dbo.AspNetUsers", "BusinessId", "dbo.Businesses", "Id");
        }
    }
}
