namespace BackendV7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Establishments", "Business_Id", "dbo.Businesses");
            DropIndex("dbo.Establishments", new[] { "Business_Id" });
            RenameColumn(table: "dbo.Establishments", name: "Business_Id", newName: "BusinessId");
            AlterColumn("dbo.Establishments", "BusinessId", c => c.Int(nullable: false));
            CreateIndex("dbo.Establishments", "BusinessId");
            AddForeignKey("dbo.Establishments", "BusinessId", "dbo.Businesses", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Establishments", "BusinessId", "dbo.Businesses");
            DropIndex("dbo.Establishments", new[] { "BusinessId" });
            AlterColumn("dbo.Establishments", "BusinessId", c => c.Int());
            RenameColumn(table: "dbo.Establishments", name: "BusinessId", newName: "Business_Id");
            CreateIndex("dbo.Establishments", "Business_Id");
            AddForeignKey("dbo.Establishments", "Business_Id", "dbo.Businesses", "Id");
        }
    }
}
