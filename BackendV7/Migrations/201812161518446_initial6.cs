namespace BackendV7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Subscriptions", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Subscriptions", new[] { "UserId" });
            DropPrimaryKey("dbo.Subscriptions");
            AlterColumn("dbo.Subscriptions", "UserId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Subscriptions", new[] { "BusinessId", "UserId" });
            CreateIndex("dbo.Subscriptions", "UserId");
            AddForeignKey("dbo.Subscriptions", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            DropColumn("dbo.Subscriptions", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Subscriptions", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Subscriptions", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Subscriptions", new[] { "UserId" });
            DropPrimaryKey("dbo.Subscriptions");
            AlterColumn("dbo.Subscriptions", "UserId", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.Subscriptions", "Id");
            CreateIndex("dbo.Subscriptions", "UserId");
            AddForeignKey("dbo.Subscriptions", "UserId", "dbo.AspNetUsers", "Id");
        }
    }
}
