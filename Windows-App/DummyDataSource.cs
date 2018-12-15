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

        public static Promotion PromotionIkeaAntwerpen1 { get; } = new Promotion()
        {
            Id = 2,
            Name = "Actie in Ikea Antwerpen",
            Description = "Deze week grote kortingen tot 70% op alles!",
            StartDate = new DateTime(2018, 11, 11),
            EndDate = new DateTime(2018, 12, 11),
            IsDiscountCoupon = false,
            EstablishmentId = 2
        };

        public static Event EventIkeaAntwerpen1 { get; } = new Event()
        {
            Id = 2,
            Name = "Evenement in Ikea Antwerpen",
            Description = "Deze week grote opening tot nieuwe vestiging!",
            StartDate = new DateTime(2018, 11, 11),
            EndDate = new DateTime(2018, 11, 15),
            EstablishmentId = 2
        };


        public static List<Promotion> PromotionsIkeaAntwerpen { get; } = new List<Promotion>()
        {
            PromotionIkeaAntwerpen1
        };

        public static List<Event> EventsIkeaAntwerpen { get; } = new List<Event>()
        {
            EventIkeaAntwerpen1
        };


        
        public static Event EventIkeaGent1 { get; } = new Event()
        {
            Id = 1,
            Name = "Evenement in Ikea",
            Description = "Deze week grote opening tot nieuwe vestiging!",
            StartDate = new DateTime(2018, 11, 11),
            EndDate = new DateTime(2018, 11, 15),
            EstablishmentId = 1
        };
        public static Promotion PromotionIkeaGent1 { get; } = new Promotion()
        {
            Id = 1,
            Name = "Actie in Ikea",
            Description = "Deze week grote kortingen tot 70% op alles!",
            StartDate = new DateTime(2018, 11, 11),
            EndDate = new DateTime(2018, 12, 11),
            IsDiscountCoupon = false,
            EstablishmentId = 1
        };
        public static List<Promotion> PromotionsIkeaGent { get; } = new List<Promotion>()
        {
            PromotionIkeaGent1
        };



        public static List<Event> EventsIkeaGent { get; } = new List<Event>()
        {
            EventIkeaGent1
        };


        public static Establishment EstablishmentIkeaAntwerpen { get; } = new Establishment()
        {
            Id = 2,
            Name = "Ikea Antwerpen",
            Address = "Boomsesteenweg 755, 2610 Antwerpen",
            PhoneNumber = "02 458 69 69",
            Email = "IkeaAntwerpen@Ikea.com",
            OpeningHours = OpeningHoursIkea,
            Promotions = PromotionsIkeaAntwerpen,
            Events = EventsIkeaAntwerpen,
            BusinessId = 1
        };
        public static Establishment EstablishmentIkeaGent { get; } = new Establishment()
        {
            Id = 1,
            Name = "Ikea Gent",
            Address = "Maaltekouter 2, 9051 Gent",
            PhoneNumber = "02 719 19 22",
            Email = "IkeaGent@Ikea.com",
            OpeningHours = OpeningHoursIkea,
            Promotions = PromotionsIkeaGent,
            Events = EventsIkeaGent,
            BusinessId = 1
        };

        public static List<Establishment> EstablishmentsIkea { get; } = new List<Establishment>()
        {
            EstablishmentIkeaGent,
            EstablishmentIkeaAntwerpen
        };

        public static Business BusinessIkea { get; } = new Business()
        {
            Id = 1,
            Name = "Ikea",
            Description = "Dit is een korte beschrijving van de Ikea waar je ook lekker kunt gaan eten enzo",
            Category = "Interieur",
            Picture = BusinessPicture,
            LinkWebsite = "https://www.ikea.com/be/nl/",
            NumberOfSubscribers = 8,
            Establishments = EstablishmentsIkea
        };

        

        public static Establishment EstablishmentInno { get; } = new Establishment()
        {
            Id = 3,
            Name = "Inno Waasland",
            Address = "Kapelstraat 100, 9100 Sint-Niklaas",
            PhoneNumber = "03 766 52 20",
            Email = "InnoWaasland@Inno.com",
            OpeningHours = OpeningHoursIkea,
            Promotions = PromotionsInno,
            Events = EventsInno,
            BusinessId = 2

        };

        public static Event EventInno { get; } = new Event()
        {
            Id = 3,
            Name = "Evenement in Inno",
            Description = "Deze week grote opening tot nieuwe vestiging in Waasland shopping center!",
            StartDate = new DateTime(2018, 11, 11),
            EndDate = new DateTime(2018, 11, 15),
            EstablishmentId = 3
        };
        public static Promotion PromotionInno { get; } = new Promotion()
        {
            Id = 3,
            Name = "Actie in Inno",
            Description = "Deze week grote kortingen tot 70% op alle kleding!",
            StartDate = new DateTime(2018, 11, 11),
            EndDate = new DateTime(2018, 12, 11),
            IsDiscountCoupon = false,
            EstablishmentId = 3
        };
        public static List<Promotion> PromotionsInno { get; } = new List<Promotion>()
        {
            PromotionInno
        };



        public static List<Event> EventsInno { get; } = new List<Event>()
        {
            EventInno
        };


     
        

        public static List<Establishment> EstablishmentsInno { get; } = new List<Establishment>()
        {
            EstablishmentInno
        };



        public static Business BusinessInno { get; } = new Business()
        {
            Id = 2,
            Name = "Inno",
            Description = "Een winkel waar je vriendin je mee naartoe sleept om 'even' 'goedope' kleren te bekijken",
            Category = "Kleding",
            Picture = BusinessPicture,
            LinkWebsite = "https://www.inno.be/nl-be/",
            NumberOfSubscribers = 69,
            Establishments = EstablishmentsInno
        };

        public static Business BusinessAction { get; } = new Business()
        {
            Id = 3,
            Name = "Action",
            Description = "De meest goedkope elektronica winkel die er is. Dankje voor de 5 euro muis die nog steeds meegaat.",
            Category = "Elektronica",
            Picture = BusinessPicture,
            LinkWebsite = "https://www.action.com/nl-be/",
            NumberOfSubscribers = 420,
            Establishments = new List<Establishment>()
        };

        public static Business BusinessGameMania { get; } = new Business()
        {
            Id = 4,
            Name = "GameMania",
            Description = "Voor sentimentele waarden en games in te ruilen kan je hier terecht. Wordt gewoon PC masterrace, waarvoor je alles kan torrenten.",
            Category = "Games",
            Picture = BusinessPicture,
            LinkWebsite = "https://www.gamemania.nl/Winkels",
            NumberOfSubscribers = 53,
            Establishments = new List<Establishment>()
        };

        public static Business BusinessHema { get; } = new Business()
        {
            Id = 5,
            Name = "HEMA",
            Description = "HEMA maakt gebruik van cookies en daarmee vergelijkbare technieken om jou een optimale bezoekerservaring te bieden, om jou relevante advertenties aan te bieden en om jouw surfgedrag te meten.",
            Category = "Kleding",
            Picture = BusinessPicture,
            LinkWebsite = "https://www.hema.be/",
            NumberOfSubscribers = 1,
            Establishments = new List<Establishment>()
        };

        public static List<Business> Businesses { get; } = new List<Business>()
        {
            BusinessIkea,
            BusinessInno,
            BusinessAction,
            BusinessGameMania,
            BusinessHema,
          
            new Business() {
                Id = 6,
                Name ="Media Markt",
                Description = "Wie dit leest is gek.",
                Category = "Elektronica",
                Picture = BusinessPicture,
                LinkWebsite = "https://www.mediamarkt.be/",
                NumberOfSubscribers = 6969,
                Establishments = new List<Establishment>()
                },
            new Business() {
                Id = 7,
                Name ="Xenos",
                Description = "Nog nooit van deze winkel gehoord. Bezoek de site en zoek het zelf uit x",
                Category = "Interieur",
                Picture = BusinessPicture,
                LinkWebsite = "https://www.xenos.nl/",
                NumberOfSubscribers = 156,
                Establishments = new List<Establishment>()
                }
        };

        public static List<Promotion> Promotions { get; } = new List<Promotion>()
        {
            PromotionIkeaGent1,
            PromotionIkeaAntwerpen1,
            PromotionInno,
            new Promotion()
            {
                Id = 4,
                Name = "Actie in Inno",
                Description = "Deze week grote kortingen tot 50% op kleding!",
                StartDate  = new DateTime(2018,11,11),
                EndDate = new DateTime(2018,12,11),
                IsDiscountCoupon = true
            },

            new Promotion()
            {
                Id = 5,
                Name = "Actie in Action",
                Description = "Deze week grote kortingen tot 70% op alles!",
                StartDate  = new DateTime(2018,11,11),
                EndDate = new DateTime(2018,12,11),
                IsDiscountCoupon = false
            },

            new Promotion()
            {
                Id = 6,
                Name = "Actie in GameMania",
                Description = "Deze week grote kortingen tot 70% op alles!",
                StartDate  = new DateTime(2018,11,11),
                EndDate = new DateTime(2018,12,11),
                IsDiscountCoupon = false
            },

            new Promotion()
            {
                Id = 7,
                Name = "Actie in HEMA",
                Description = "Deze week grote kortingen tot 70% op alles!",
                StartDate  = new DateTime(2018,11,11),
                EndDate = new DateTime(2018,12,11),
                IsDiscountCoupon = false
            },
            
            new Promotion()
            {
                Id = 8,
                Name = "Actie in Media Markt",
                Description = "Deze week 2+1 gratis op het gehele gameassortiment!!",
                StartDate  = new DateTime(2018,12,12),
                EndDate = new DateTime(2018,12,16),
                IsDiscountCoupon = false
            },

            new Promotion()
            {
                Id = 9,
                Name = "Actie in Xenos",
                Description = "Deze week grote kortingen tot 50% op alles!",
                StartDate  = new DateTime(2018,11,11),
                EndDate = new DateTime(2018,12,11),
                IsDiscountCoupon = true
            }

        };

        public static List<Event> Events { get; } = new List<Event>()
        {
            EventIkeaGent1,
            EventIkeaAntwerpen1,
            EventInno,
            new Event()
            {
                Id = 4,
                Name = "Opendeurdag in Inno",
                Description = "Deze week grote Opendeurdag kortingen tot 50% op kleding!",
                StartDate  = new DateTime(2018,11,11),
                EndDate = new DateTime(2018,12,11)
            },

            new Event()
            {
                Id = 5,
                Name = "Opendeurdag in Action",
                Description = "Deze week grote Opendeurdag met kortingen tot 70% op alles!",
                StartDate  = new DateTime(2018,11,11),
                EndDate = new DateTime(2018,12,11)
            },

            new Event()
            {
                Id = 6,
                Name = "Opendeurdag in GameMania",
                Description = "Deze week grote Opendeurdag met kortingen tot 70% op alles!",
                StartDate  = new DateTime(2018,11,11),
                EndDate = new DateTime(2018,12,11)
            },

            new Event()
            {
                Id = 7,
                Name = "Opendeurdag in HEMA",
                Description = "Deze week grote Opendeurdag met kortingen tot 70% op alles!",
                StartDate  = new DateTime(2018,11,11),
                EndDate = new DateTime(2018,12,11)
            },

            new Event()
            {
                Id = 8,
                Name = "Opendeurdag in Media Markt",
                Description = "Deze week Opendeurdag 2+1 gratis op het gehele gameassortiment!!",
                StartDate  = new DateTime(2018,12,12),
                EndDate = new DateTime(2018,12,16)
            },

            new Event()
            {
                Id = 9,
                Name = "Opendeurdag in Xenos",
                Description = "Deze week grote Opendeurdag tot 50% op alles!",
                StartDate  = new DateTime(2018,11,11),
                EndDate = new DateTime(2018,12,11)
            }
        };

        public static List<Establishment> Establishments { get; } = new List<Establishment>()
        {
            EstablishmentIkeaAntwerpen,
            EstablishmentIkeaGent,
            EstablishmentInno
        };
    }
}
