using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static Windows_Backend.Models.Domain.DaysOfWeek;

namespace Windows_Backend.Models.Domain
{
    public class OpeningHour
    {
        [Key]
        public int Id { get; set; }
        public DaysOfWeekEnum Day { get; set; }
        public string OpeningsHour { get; set; }
        public string ClosingsHour { get; set; }
    }
}