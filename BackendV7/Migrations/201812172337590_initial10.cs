namespace BackendV7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial10 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "Created", c => c.DateTime(nullable: false));
            AddColumn("dbo.Promotions", "Created", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "NotificationsClearedTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "NotificationsClearedTime");
            DropColumn("dbo.Promotions", "Created");
            DropColumn("dbo.Events", "Created");
        }
    }
}
