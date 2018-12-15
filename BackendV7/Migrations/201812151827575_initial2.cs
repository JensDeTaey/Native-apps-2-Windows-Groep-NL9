namespace BackendV7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial2 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Subscriptions", new[] { "User_Id" });
            DropColumn("dbo.Subscriptions", "UserId");
            RenameColumn(table: "dbo.Subscriptions", name: "User_Id", newName: "UserId");
            AlterColumn("dbo.Subscriptions", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Subscriptions", "UserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Subscriptions", new[] { "UserId" });
            AlterColumn("dbo.Subscriptions", "UserId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Subscriptions", name: "UserId", newName: "User_Id");
            AddColumn("dbo.Subscriptions", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Subscriptions", "User_Id");
        }
    }
}
