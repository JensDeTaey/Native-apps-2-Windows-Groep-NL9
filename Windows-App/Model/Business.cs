﻿using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace Windows_App.Model
{
    public class Business
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public BitmapImage Picture { get; set; }
        public string LinkWebsite { get; set; }
        public int NumberOfSubscribers { get; set; }

        public List<Establishment> Establishments { get; set; }
        public List<Promotion> Promotions { get; set; }

        public Business()
        {
            this.Establishments = new List<Establishment>();
            this.Promotions = new List<Promotion>();
        }
    }
}
