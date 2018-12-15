namespace Windows_Backend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "BusinessId", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "BusinessId");
            AddForeignKey("dbo.AspNetUsers", "BusinessId", "dbo.Businesses", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "BusinessId", "dbo.Businesses");
            DropIndex("dbo.AspNetUsers", new[] { "BusinessId" });
            DropColumn("dbo.AspNetUsers", "BusinessId");
        }
    }
}
