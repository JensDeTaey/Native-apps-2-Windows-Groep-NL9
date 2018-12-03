using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Windows_Backend.Models.Domain
{
    public static class DaysOfWeek
    {
        public enum DaysOfWeekEnum : short
        {
            Saturday, Sunday, Monday, Tuesday, Wednesday, Thursday, Friday
        }

        private static Dictionary<DaysOfWeekEnum, string> translationDictionary = new Dictionary<DaysOfWeekEnum, string>()
        {
            {DaysOfWeekEnum.Monday, "Maandag"},
            {DaysOfWeekEnum.Tuesday, "Dinsdag"},
            {DaysOfWeekEnum.Wednesday, "Woensdag"},
            {DaysOfWeekEnum.Thursday, "Donderdag"},
            {DaysOfWeekEnum.Friday, "Vrijdag"},
            {DaysOfWeekEnum.Saturday, "Zaterdag"},
            {DaysOfWeekEnum.Sunday, "Zondag"}
        };

    }
}