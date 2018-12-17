using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendV7
{
   public class OpeningHour
    {

        [Required]
        [Key]
        [Column(Order =0)]
        public int Day { get; set; }
        [Required]
        public string OpeningsHour { get; set; }
        [Required]
        public string ClosingsHour { get; set; }

        //Assocations
        [JsonIgnore]
        [Column(Order = 3)]
        [Key,ForeignKey("Establishment")]
        public int EstablishmentId { get; set; }
        [JsonIgnore]
        public Establishment Establishment { get; set; }
    }
}
