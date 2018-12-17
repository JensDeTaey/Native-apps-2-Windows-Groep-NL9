namespace BackendV7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial8 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.OpeningHours");
            AlterColumn("dbo.OpeningHours", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.OpeningHours", new[] { "Day", "EstablishmentId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.OpeningHours");
            AlterColumn("dbo.OpeningHours", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.OpeningHours", "Id");
        }
    }
}
