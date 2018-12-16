using BackendV7.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BackendV7
{
    public class Subscription
    {

        [Key, Column(Order = 0)]
        public int BusinessId { get; set; }
        public Business Business { get; set; }

        [Key, Column(Order = 1)]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}