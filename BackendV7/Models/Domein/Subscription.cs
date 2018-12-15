using BackendV7.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BackendV7
{
    public class Subscription
    {
        [Key]
        public int Id { get; set; }

        public int BusinessId { get; set; }
        public Business Business { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}