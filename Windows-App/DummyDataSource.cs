using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows_App.Model;

namespace Windows_App
{
    public static class DummyDataSource
    {
        public static List<Business> Businesses { get; set; } = new List<Business>()
        {
            new Business() {Name="Ikea"},
            new Business() {Name="Ikea"},
            new Business() {Name="Ikea"},
            new Business() {Name="Ikea"},
            new Business() {Name="Ikea"}
        };
        public static List<Establishment> Establishments { get; set; } = new List<Establishment>()
        {
            new Establishment() {Name="Ikea Gent"},
            new Establishment() {Name="Ikea Antwerpen"},
            new Establishment() {Name="Ikea ergens anders"},
            new Establishment() {Name="Ikea nog ergens anders"},
            new Establishment() {Name="Ikea jnezfknzejkf"}
        };

    }
}
