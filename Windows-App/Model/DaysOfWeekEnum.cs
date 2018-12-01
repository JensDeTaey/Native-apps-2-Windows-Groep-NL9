using System.Collections.Generic;

namespace Windows_App.Model
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

        public static string GiveDutchDayOfWeek(DaysOfWeekEnum dayOfWeek)
        {
            return translationDictionary.GetValueOrDefault(dayOfWeek);
        }
    }


}