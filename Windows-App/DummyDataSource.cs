using System;
using System.Collections.Generic;
using Windows_App.Model;

namespace Windows_App
{
    public static class DummyDataSource
    {
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
            Picture = "https://i.imgur.com/G7BsRWu.png",
            IsDiscountCoupon = false,
            EstablishmentId = 2
        };

        public static Event EventIkeaAntwerpen1 { get; } = new Event()
        {
            Id = 2,
            Name = "Evenement in Ikea Antwerpen",
            Description = "Deze week grote opening voor nieuwe vestiging!",
            StartDate = new DateTime(2018, 11, 11),
            EndDate = new DateTime(2018, 11, 15),
            Picture = "https://i.imgur.com/H7w1911.png",
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

        public static Promotion PromotionIkeaGent1 { get; } = new Promotion()
        {
            Id = 1,
            Name = "Actie in Ikea",
            Description = "20% FAMILY korting op alle BJURSTA tafels",
            StartDate = new DateTime(2018, 11, 21),
            EndDate = new DateTime(2018, 12, 27),
            Picture = "https://i.imgur.com/smt3LaH.png",
            IsDiscountCoupon = false,
            EstablishmentId = 1
        };
        public static Event EventIkeaGent1 { get; } = new Event()
        {
            Id = 1,
            Name = "Geef je tekening af aan Småland en krijg een leuke verrassing!",
            Description = "Kom jouw tekening afgeven tussen 8 december en 5 januari aan het kinderparadijs, aan de ingang van de winkel. Onze medewerkers sturen hem dan op naar de kerstman en jij krijgt een leuke verrassing. Vind je alle kerst-kabouters dan krijg je nog iets extra.",
            StartDate = new DateTime(2018, 12, 8),
            EndDate = new DateTime(2019, 01, 05),
            Picture = "https://i.imgur.com/NBqqO9M.png",
            EstablishmentId = 1
        };
        public static Event EventIkeaGent2 { get; } = new Event()
        {
            Id = 2,
            Name = "Kom je verjaardag vieren bij IKEA Gent!",
            Description = "Bij IKEA Gent kan je elke woensdag van 14u – 16u samen met maximaal 10 vriendjes je verjaardag vieren. We gaan knutselen, leuke spelletjes spelen en allerlei lekkers proeven. Bij afloop gaat elk vriendje naar huis met een klein aandenken aan een leuk verjaardagsfeestje.",
            StartDate = new DateTime(2018, 11, 08),
            EndDate = new DateTime(2019, 01, 21),
            Picture = "https://i.imgur.com/x2UaTs8.png",
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
            Picture = "https://i.imgur.com/ODYpLGd.png",
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
            Picture = "https://i.imgur.com/mrHTchx.jpg?1",
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
            Picture = "https://i.imgur.com/eVYhPIx.png",
            LinkWebsite = "https://www.ikea.com/be/nl/",
            NumberOfSubscribers = 8,
            Establishments = EstablishmentsIkea
        };

        public static Promotion PromotionInno { get; } = new Promotion()
        {
            Id = 3,
            Name = "So loyalty days",
            Description = "Geniet van de collectie aan -20%!",
            StartDate = new DateTime(2018, 09, 26),
            EndDate = new DateTime(2018, 10, 01),
            Picture = "https://i.imgur.com/SF81evT.png",
            IsDiscountCoupon = false,
            EstablishmentId = 3
        };
        public static Event EventInno { get; } = new Event()
        {
            Id = 3,
            Name = "Drinken tot we kruipen",
            Description = "Alle jongeren onder de welvarende leeftijd van 18 mogen niet binnen, maar terug Fortnite spelen. Alle andere krijgen gratis booze.",
            StartDate = new DateTime(2018, 12, 11),
            EndDate = new DateTime(2018, 12, 31),
            Picture = "https://i.imgur.com/fjnQTOE.png",
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

        public static Establishment EstablishmentInno { get; } = new Establishment()
        {
            Id = 3,
            Name = "Inno Waasland",
            Address = "Kapelstraat 100, 9100 Sint-Niklaas",
            PhoneNumber = "03 766 52 20",
            Picture = "https://i.imgur.com/O5xSNUP.png",
            Email = "InnoWaasland@Inno.com",
            OpeningHours = OpeningHoursIkea,
            Promotions = PromotionsInno,
            Events = EventsInno,
            BusinessId = 2
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
            Picture = "https://i.imgur.com/iOAabXU.jpg",
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
            Picture = "https://i.imgur.com/E1IX7uc.png",
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
            Picture = "https://i.imgur.com/Vmd4U36.png",
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
            Picture = "https://i.imgur.com/V9zLpm2.jpg",
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
                Picture = "https://i.imgur.com/JrJYcJH.png",
                LinkWebsite = "https://www.mediamarkt.be/",
                NumberOfSubscribers = 6969,
                Establishments = new List<Establishment>()
                },
            new Business() {
                Id = 7,
                Name ="Xenos",
                Description = "Nog nooit van deze winkel gehoord. Bezoek de site en zoek het zelf uit x",
                Category = "Interieur",
                Picture = "https://i.imgur.com/jpZtT1a.jpg",
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

        public static User user1 { get; } = new User
        {
            Lastname = "Peeters",
            Firstname = "Marcel",
            EmailAdress = "marcel.peeters@gmail.com"
        };
    }
}
