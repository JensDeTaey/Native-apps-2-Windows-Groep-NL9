using BackendV7.Models.Domein;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Windows_App.Model
{
    public class Business
    {

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string PictureURL { get; set; }
        public string LinkWebsite { get; set; }
        //public int NumberOfSubscribers { get; set; }

        //Associations
        public List<Subscription> Subscriptions { get; set; }
        public List<Establishment> Establishments { get; set; }
        

    }
}
