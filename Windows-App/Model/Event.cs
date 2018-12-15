using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows_App.Model
{
   public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Picture { get; set; }
        public int EstablishmentId { get; set; }

        public string TimeValid
        {
            get
            {
                return String.Format("{0} - {1}", StartDate.ToString("MM/dd/yyyy"), EndDate.ToString("MM/dd/yyyy"));
            }
        }
    }
}
