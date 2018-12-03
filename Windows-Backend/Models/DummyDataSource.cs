using System;
using System.Collections.Generic;
using Windows_Backend.Models;
using Windows_Backend.Models.Domain;

namespace Windows_Backend.Models
{
    public static class DummyDataSource
    {


        public static List<Establishment> EstablishmentsIkea { get; } = new List<Establishment>()
        {
            new Establishment() {Name="Ikea Gent",Address="Maaltekouter 2, 9051 Gent",PhoneNumber="02 719 19 22"},
            new Establishment() {Name="Ikea Antwerpen",Address="Maaltekouter 2, 2000 Antwerpen",PhoneNumber="02 458 69 69"}
        };

        public static List<Business> Businesses { get; } = new List<Business>()
        {
            new Business() {
                Name ="Ikea",
                Description = "Dit is een korte beschrijving van de Ikea waar je ook lekker kunt gaan eten enzo",
                Category = "Interieur",
                LinkWebsite = "https://www.ikea.com/be/nl/",
                NumberOfSubscribers = 8,
                Establishments = new List<Establishment>(EstablishmentsIkea),
                Promotions = new List<Promotion>()
                },
            new Business() {
                Name ="Inno",
                Description = "Een winkel waar je vriendin je mee naartoe sleept om 'even' 'goedope' kleren te bekijken",
                Category = "Kleding",
                LinkWebsite = "https://www.inno.be/nl-be/",
                NumberOfSubscribers = 69,
                Establishments = new List<Establishment>(),
                Promotions = new List<Promotion>()
                },
            new Business() {
                Name ="Action",
                Description = "De meest goedkope elektronica winkel die er is. Dankje voor de 5 euro muis die nog steeds meegaat.",
                Category = "Elektronica",
                LinkWebsite = "https://www.action.com/nl-be/",
                NumberOfSubscribers = 420,
                Establishments = new List<Establishment>(),
                Promotions = new List<Promotion>()
                },
            new Business() {
                Name ="GameMania",
                Description = "Voor sentimentele waarden en games in te ruilen kan je hier terecht. Wordt gewoon PC masterrace, waarvoor je alles kan torrenten.",
                Category = "Games",
                LinkWebsite = "https://www.gamemania.nl/Winkels",
                NumberOfSubscribers = 53,
                Establishments = new List<Establishment>(),
                Promotions = new List<Promotion>()
                },
            new Business() {
                Name ="HEMA",
                Description = "HEMA maakt gebruik van cookies en daarmee vergelijkbare technieken om jou een optimale bezoekerservaring te bieden, om jou relevante advertenties aan te bieden en om jouw surfgedrag te meten.",
                Category = "Kleding",
                LinkWebsite = "https://www.hema.be/",
                NumberOfSubscribers = 1,
                Establishments = new List<Establishment>(),
                Promotions = new List<Promotion>()
                },
            new Business() {
                Name ="Media Markt",
                Description = "Wie dit leest is gek.",
                Category = "Elektronica",
                LinkWebsite = "https://www.mediamarkt.be/",
                NumberOfSubscribers = 6969,
                Establishments = new List<Establishment>(),
                Promotions = new List<Promotion>()
                },
            new Business() {
                Name ="Xenos",
                Description = "Nog nooit van deze winkel gehoord. Bezoek de site en zoek het zelf uit x",
                Category = "Interieur",
                LinkWebsite = "https://www.xenos.nl/",
                NumberOfSubscribers = 156,
                Establishments = new List<Establishment>(),
                Promotions = new List<Promotion>()
                }
        };

    }
}
