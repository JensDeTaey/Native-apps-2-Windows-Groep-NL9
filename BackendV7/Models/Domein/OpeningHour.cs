using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows_App.Model
{
   public class OpeningHour
    {
        [Key]
        public int OpeningHourId { get; set; }

        public int Day { get; set; }
        public string OpeningsHour { get; set; }
        public string ClosingsHour { get; set; }

        //Assocations
        public int EstablishmentId { get; set; }
        public Establishment Establishment { get; set; }
    }
}
