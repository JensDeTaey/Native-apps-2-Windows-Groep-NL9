using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Windows_Backend.Models.Domain;

namespace Windows_Backend.Models
{
    public class Windows_BackendContext : IdentityDbContext<ApplicationUser>
    {
        public System.Data.Entity.DbSet<Business> Businesses { get; set; }
        public System.Data.Entity.DbSet<Promotion> Promotions { get; set; }
        public System.Data.Entity.DbSet<Event> Events { get; set; }

        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public Windows_BackendContext() : base("DefaultConnection")
        {
            Database.SetInitializer<Windows_BackendContext>(new Windows_BackendInitializer());
            Database.CreateIfNotExists();
            
        }


        public static Windows_BackendContext Create()
        {
            return new Windows_BackendContext();
        }





    }

    public class Windows_BackendInitializer : CreateDatabaseIfNotExists<Windows_BackendContext>
    {
        
    }
}
