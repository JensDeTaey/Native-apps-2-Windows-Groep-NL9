using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
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
                if (businessPicture == null)
                {
                    UriBuilder builder = new UriBuilder
                    {
                        Path = AppDomain.CurrentDomain.BaseDirectory + @"Images/ikea.png"
                    };
                    businessPicture = new BitmapImage(builder.Uri);
                }
                return businessPicture;
            }
        }


        public static List<Business> Businesses { get; set; } = new List<Business>()
        {
            new Business() {Name="Ikea", Picture = BusinessPicture},
            new Business() {Name="Ikea", Picture = BusinessPicture},
            new Business() {Name="Ikea", Picture = BusinessPicture},
            new Business() {Name="Ikea", Picture = BusinessPicture},
            new Business() {Name="Ikea", Picture = BusinessPicture}
        };
    }
}
