namespace BackendV7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.OpeningHours", "OpeningsHour", c => c.String(nullable: false));
            AlterColumn("dbo.OpeningHours", "ClosingsHour", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OpeningHours", "ClosingsHour", c => c.String());
            AlterColumn("dbo.OpeningHours", "OpeningsHour", c => c.String());
        }
    }
}
