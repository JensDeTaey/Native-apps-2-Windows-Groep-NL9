namespace BackendV7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial9 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.OpeningHours", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OpeningHours", "Id", c => c.Int(nullable: false));
        }
    }
}
