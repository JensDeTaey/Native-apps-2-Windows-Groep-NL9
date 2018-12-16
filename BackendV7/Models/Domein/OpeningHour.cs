using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendV7
{
   public class OpeningHour
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }

        [Required]
        public int Day { get; set; }
        [Required]
        public string OpeningsHour { get; set; }
        [Required]
        public string ClosingsHour { get; set; }

        //Assocations
        [JsonIgnore]
        public int EstablishmentId { get; set; }
        [JsonIgnore]
        public Establishment Establishment { get; set; }
    }
}
