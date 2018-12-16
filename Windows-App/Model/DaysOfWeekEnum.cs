using System;
using System.Collections.Generic;

namespace Windows_App.Model
{
    public static class DaysOfWeek
    {
        public enum DaysOfWeekEnum { Monday = 0, Tuesday = 1, Wednesday = 2, Thursday = 3, Friday = 4, Saturday = 5, Sunday = 6 };

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

        public static string GiveDutchDayOfWeek(DaysOfWeekEnum dayOfWeek)
        {
            string translation = "";
            if (translationDictionary.TryGetValue(dayOfWeek, out translation))
            {
                return translation;
            }
            else
            {
                 throw new Exception($"No Dutch translation found for {dayOfWeek}");
            }
        }
    }


}