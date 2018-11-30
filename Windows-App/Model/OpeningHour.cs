using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Windows_App.Model.DaysOfWeek;

namespace Windows_App.Model
{
   public class OpeningHour
    {
        public DaysOfWeekEnum Day { get; set; }
        public string OpeningsHour { get; set; }
        public string ClosingsHour { get; set; }
    }
}
