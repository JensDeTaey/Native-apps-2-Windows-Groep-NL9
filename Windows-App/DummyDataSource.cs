﻿using System;
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
            new Establishment() {Name="Ikea Gent",Address="Maaltekouter 2, 9051 Gent",PhoneNumber="02 719 19 22"},
            new Establishment() {Name="Ikea Antwerpen",Address="Maaltekouter 2, 2000 Antwerpen",PhoneNumber="02 458 69 69"}
           
        };

    }
}
