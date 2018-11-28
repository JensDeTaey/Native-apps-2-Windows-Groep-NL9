using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows_App.Model
{
    public class Business
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public List<Establishment> Establishments { get; set; }
        public long Logo { get; set; }
        public List<Promotion> Promotions { get; set; }
        public int NumberOfSubsribers { get; set; }
        public string LinkWebsite { get; set; }

    }
}
