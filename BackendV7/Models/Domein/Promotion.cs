using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows_App.Model
{
   public class Promotion
    {
        [Key]
        public int PromotionId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string PictureURL { get; set; }
        public bool IsDiscountCoupon { get; set; }

        //Assocations
        public int EstablishmentId { get; set; }
        public Establishment Establishment { get; set; }
    }


}
