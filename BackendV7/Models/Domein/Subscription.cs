using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Windows_App.Model;

namespace BackendV7.Models.Domein
{
    public class Subscription
    {
        [Key]
        public int SubscriptionId { get; set; }

        public int BusinessId { get; set; }
        public Business Business { get; set; }

        public int UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}