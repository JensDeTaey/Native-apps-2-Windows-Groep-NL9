using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows_Backend.Models;

namespace Windows_Backend.Models.Domain
{
    public class Business
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        //public BitmapImage Picture { get; set; }
        public string LinkWebsite { get; set; }
        public int NumberOfSubscribers { get; set; }

        public List<Establishment> Establishments { get; set; }
        public List<Promotion> Promotions { get; set; }

        public Business(string name, string description, string category, string websiteUrl)
        {
            this.Establishments = new List<Establishment>();
            this.Promotions = new List<Promotion>();
            this.Name = name;
            this.Description = description;
            this.Category = category;
            this.LinkWebsite = websiteUrl;
        }

        public Business()
        {
        }
    }
}
