using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendV7
{
   public class Promotion
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [JsonProperty("Picture")]
        public string PictureURL { get; set; }
        public bool IsDiscountCoupon { get; set; }

        public int BusinessId {
            get {
                return Establishment.BusinessId;
            }
        }

        //Assocations
        public int EstablishmentId { get; set; }
        [JsonIgnore]
        public Establishment Establishment { get; set; }
    }


}
