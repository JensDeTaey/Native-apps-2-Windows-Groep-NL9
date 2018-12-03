namespace Windows_Backend.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Windows_Backend.Models;
    using Windows_Backend.Models.Domain;

    internal sealed class Configuration : DbMigrationsConfiguration<Windows_BackendContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Windows_BackendContext context)
        { 
            context.Businesses.AddRange(DummyDataSource.Businesses);

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }




    }
}
