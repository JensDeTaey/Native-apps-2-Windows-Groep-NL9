using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Windows_App.Model.DaysOfWeek;

namespace Windows_App.Model
{
    public class Establishment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Picture { get; set; }
        private List<OpeningHour> openingsHours;
        public List<OpeningHour> OpeningHours
        {
            get {
               List<DaysOfWeekEnum> daysFromOpeningHours =  openingsHours.Select(openingsHour => openingsHour.Day).ToList();
                daysFromOpeningHours = Enum.GetValues(typeof(DaysOfWeekEnum)).Cast<DaysOfWeekEnum>().ToList().Except(daysFromOpeningHours).ToList();
                List<OpeningHour> openingsHoursComplete =  daysFromOpeningHours.Select(day => new OpeningHour { Day = day, IsClosed = true }).ToList();
                openingsHoursComplete.AddRange(openingsHours);
                return openingsHoursComplete.OrderBy(o => o.Day).ToList();
            }
            set { openingsHours = value; }
        }
        public List<Event> Events { get; set; }
        public List<Promotion> Promotions { get; set; }
        public int BusinessId { get; set; }
    }
}
