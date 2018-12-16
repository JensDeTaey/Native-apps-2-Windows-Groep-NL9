using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendV7
{
    public class Establishment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [JsonProperty("Picture")]
        public string PictureURL { get; set; }

        
        public int BusinessId { get; set; }
        [JsonIgnore]
        public Business Business { get; set; }

        public List<OpeningHour> OpeningHours { get; set; } = new List<OpeningHour>();
        public List<Event> Events { get; set; } = new List<Event>();
        public List<Promotion> Promotions { get; set; } = new List<Promotion>();
    }
}
