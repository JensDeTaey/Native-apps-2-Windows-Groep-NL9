using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace Windows_App.Model
{
    public class Business
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public BitmapImage Picture { get; set; }
        public string LinkWebsite { get; set; }
        public int NumberOfSubscribers { get; set; }
        public List<Establishment> Establishments { get; set; }
        

        public Business()
        {
            this.Establishments = new List<Establishment>();
        }
    }
}
