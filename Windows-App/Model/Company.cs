using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows_App.Model
{
    class Company
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public List<Establishment> Establishments { get; set; }
        public string OpeningHours { get; set; }
        public long Picture { get; set; }
        public List<Promotion> Promotions { get; set; }
        public List<Event> Events { get; set; }
        public int NumberOfSubsribers { get; set; }
        public string LinkWebsite { get; set; }

    }
}
