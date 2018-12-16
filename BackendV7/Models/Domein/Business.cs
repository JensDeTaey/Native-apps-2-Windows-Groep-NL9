﻿
using BackendV7.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendV7
{
    public class Business
    {

        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        [JsonProperty("Picture")]
        public string PictureURL { get; set; }
        [Required]
        public string LinkWebsite { get; set; }
        public int NumberOfSubscribers {
            get {
                return Subscriptions == null ? 0: Subscriptions.Count;
            }
        }

        [NotMapped]
        public bool isSubscribedTo {
            get; set;
        } = false;

        [JsonIgnore]
        public ApplicationUser User { get; set; }
        [ForeignKey("User")]
        [JsonIgnore]
        public string UserId { get; set; }

        //Associations
        [JsonIgnore]
        public List<Subscription> Subscriptions { get; set; }
        public List<Establishment> Establishments { get; set; }

        

    }
}
