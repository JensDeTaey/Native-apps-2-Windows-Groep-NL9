using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows_App.Model
{
    public class Establishment
    {
        public int EstablishmentId { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string PictureURL { get; set; }

        public List<OpeningHour> OpeningHours { get; set; }
        public List<Event> Events { get; set; }
        public List<Promotion> Promotions { get; set; }
    }
}
