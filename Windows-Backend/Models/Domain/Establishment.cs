using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Windows_Backend.Models.Domain;

namespace Windows_Backend.Models
{
    public class Establishment
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public List<OpeningHour> OpeningHours { get; set; }
        public string Picture { get; set; }
        public List<Event> Events { get; set; }
    }
}