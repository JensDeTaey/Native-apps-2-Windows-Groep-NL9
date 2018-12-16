using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows_App.Model
{
    class PageLoadWithMultipleParameters
    {
        //public int EstablishmentId { get; set; }
        public int BusinessId { get; set; }
        public PivotOptions Pivot { get; set; }

        public enum PivotOptions
        {
            BUSINESS, ESTABLISHMENT, PROMOTION, EVENT
        }
    }

}
