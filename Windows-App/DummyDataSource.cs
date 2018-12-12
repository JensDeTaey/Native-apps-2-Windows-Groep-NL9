using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;
using Windows_App.Model;

namespace Windows_App
{
    public static class DummyDataSource
    {
        private static BitmapImage businessPicture;

        public static BitmapImage BusinessPicture
        {
            get
            {
                return null;/*
                if (businessPicture == null)
                {
                    UriBuilder builder = new UriBuilder
                    {
                        Path = AppDomain.CurrentDomain.BaseDirectory + @"Images/ikea.png"
                    };
                    businessPicture = new BitmapImage(builder.Uri);
                }
                return businessPicture;*/
            }
        }

        public static List<OpeningHour> OpeningHoursIkea { get; } = new List<OpeningHour>()
        {
            new OpeningHour(){
                Day = DaysOfWeek.GiveDutchDayOfWeek(DaysOfWeek.DaysOfWeekEnum.Monday),
                OpeningsHour ="9:00",
                ClosingsHour ="20:00"
            },
            new OpeningHour(){
                Day = DaysOfWeek.GiveDutchDayOfWeek(DaysOfWeek.DaysOfWeekEnum.Tuesday),
                OpeningsHour ="9:00",
                ClosingsHour ="20:00"
            },
            new OpeningHour(){
                Day =   DaysOfWeek.GiveDutchDayOfWeek(DaysOfWeek.DaysOfWeekEnum.Wednesday),
                OpeningsHour ="9:00",
                ClosingsHour ="20:00"
            },
            new OpeningHour(){
                Day = DaysOfWeek.GiveDutchDayOfWeek(DaysOfWeek.DaysOfWeekEnum.Thursday),
                OpeningsHour ="9:00",
                ClosingsHour ="20:00"
            },
            new OpeningHour(){
                Day = DaysOfWeek.GiveDutchDayOfWeek(DaysOfWeek.DaysOfWeekEnum.Friday),
                OpeningsHour ="9:00",
                ClosingsHour ="20:00"
            },
            new OpeningHour(){
                Day = DaysOfWeek.GiveDutchDayOfWeek(DaysOfWeek.DaysOfWeekEnum.Saterday),
                OpeningsHour ="9:00",
                ClosingsHour ="20:00"
            },
            new OpeningHour(){
                Day = DaysOfWeek.GiveDutchDayOfWeek(DaysOfWeek.DaysOfWeekEnum.Sunday),
                OpeningsHour ="0:00",
                ClosingsHour ="0:00"
            }
        };

        public static List<Establishment> EstablishmentsIkea { get; } = new List<Establishment>()
        {
            new Establishment() {Name="Ikea Gent",Address="Maaltekouter 2, 9051 Gent",PhoneNumber="02 719 19 22",Email="IkeaGent@Ikea.com",OpeningHours=OpeningHoursIkea},
            new Establishment() {Name="Ikea Antwerpen",Address="Boomsesteenweg 755, 2610 Antwerpen",PhoneNumber="02 458 69 69",Email="IkeaAntwerpen@Ikea.com",OpeningHours=OpeningHoursIkea}
        };

        public static List<Business> Businesses { get; } = new List<Business>()
        {
            new Business() {
                Name ="Ikea",
                Description = "Dit is een korte beschrijving van de Ikea waar je ook lekker kunt gaan eten enzo",
                Category = "Interieur",
                Picture = BusinessPicture,
                LinkWebsite = "https://www.ikea.com/be/nl/",
                NumberOfSubscribers = 8,
                Establishments = new List<Establishment>(EstablishmentsIkea),
                Promotions = new List<Promotion>()
                },
            new Business() {
                Name ="Inno",
                Description = "Een winkel waar je vriendin je mee naartoe sleept om 'even' 'goedope' kleren te bekijken",
                Category = "Kleding",
                Picture = BusinessPicture,
                LinkWebsite = "https://www.inno.be/nl-be/",
                NumberOfSubscribers = 69,
                Establishments = new List<Establishment>(),
                Promotions = new List<Promotion>()
                },
            new Business() {
                Name ="Action",
                Description = "De meest goedkope elektronica winkel die er is. Dankje voor de 5 euro muis die nog steeds meegaat.",
                Category = "Elektronica",
                Picture = BusinessPicture,
                LinkWebsite = "https://www.action.com/nl-be/",
                NumberOfSubscribers = 420,
                Establishments = new List<Establishment>(),
                Promotions = new List<Promotion>()
                },
            new Business() {
                Name ="GameMania",
                Description = "Voor sentimentele waarden en games in te ruilen kan je hier terecht. Wordt gewoon PC masterrace, waarvoor je alles kan torrenten.",
                Category = "Games",
                Picture = BusinessPicture,
                LinkWebsite = "https://www.gamemania.nl/Winkels",
                NumberOfSubscribers = 53,
                Establishments = new List<Establishment>(),
                Promotions = new List<Promotion>()
                },
            new Business() {
                Name ="HEMA",
                Description = "HEMA maakt gebruik van cookies en daarmee vergelijkbare technieken om jou een optimale bezoekerservaring te bieden, om jou relevante advertenties aan te bieden en om jouw surfgedrag te meten.",
                Category = "Kleding",
                Picture = BusinessPicture,
                LinkWebsite = "https://www.hema.be/",
                NumberOfSubscribers = 1,
                Establishments = new List<Establishment>(),
                Promotions = new List<Promotion>()
                },
            new Business() {
                Name ="Media Markt",
                Description = "Wie dit leest is gek.",
                Category = "Elektronica",
                Picture = BusinessPicture,
                LinkWebsite = "https://www.mediamarkt.be/",
                NumberOfSubscribers = 6969,
                Establishments = new List<Establishment>(),
                Promotions = new List<Promotion>()
                },
            new Business() {
                Name ="Xenos",
                Description = "Nog nooit van deze winkel gehoord. Bezoek de site en zoek het zelf uit x",
                Category = "Interieur",
                Picture = BusinessPicture,
                LinkWebsite = "https://www.xenos.nl/",
                NumberOfSubscribers = 156,
                Establishments = new List<Establishment>(),
                Promotions = new List<Promotion>()
                }
        };

    }
}
