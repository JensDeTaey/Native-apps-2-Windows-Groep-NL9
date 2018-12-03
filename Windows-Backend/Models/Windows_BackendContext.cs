using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Windows_App.Model;

namespace Windows_Backend.Models
{
    public class Windows_BackendContext : DbContext
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

        public Windows_BackendContext() : base("name=Windows_BackendContext")
        {
        }

        
    }
}
