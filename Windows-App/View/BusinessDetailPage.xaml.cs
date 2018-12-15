using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Services.Maps;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows_App.Model;
using Windows_App.ViewModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Windows_App.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BusinessDetailPage : Page
    {

        public BusinessDetailPage()
        {
            this.InitializeComponent();
            //token you need to use maps
            MCMap.MapServiceToken = "NggniNfkWoAJYWaNrwu7~Ba_YkJv9SvsASrBV280AGQ~AqXz_H8d1GdioVSul1nTHcxPtsQlG3YdjJtPP9csVnPPyDNmc7kUv0G8x-QpQueG";

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if( e.Parameter is BusinessDetailViewModel)
            {
                
                DataContext = e.Parameter as BusinessDetailViewModel;
                AddEstablishmentsToMap();
            }
            else
            {
                throw new Exception("Parameter is no BusinessDetailViewModel");
            }

        }

        private void AddEstablishmentsToMap()
        {
            BasicGeoposition bg2 = new BasicGeoposition();
            Geopoint gp2 = new Geopoint(bg2);

            BusinessDetailViewModel business = this.DataContext as BusinessDetailViewModel;
            business.getEstablishments().ForEach(async esta =>
            {
                MapLocationFinderResult res =
                await MapLocationFinder.FindLocationsAsync(esta.Address, gp2);

                MapLocation location = res.Locations.First();

                AddPointToMap(new Geopoint(new BasicGeoposition()
                {
                    Longitude = location.Point.Position.Longitude,
                    Latitude = location.Point.Position.Latitude
                })
                    , esta.Name);
            });

        }

        private void goToRightPivot(string pivot)
        {
            switch (pivot)
            {
                case "promotion": PivotBusiness.SelectedIndex = 2;
                    break;
                case "event": PivotBusiness.SelectedIndex = 3;
                    break;
                default: PivotBusiness.SelectedIndex = 0;
                    break;
            }
            
        }

        private void AddPointToMap(Geopoint geoPoint, string title)
        {
            MapIcon mapIcon = new MapIcon();
            mapIcon.Location = geoPoint;

            mapIcon.NormalizedAnchorPoint = new Point(0.5, 1.0);
            mapIcon.Title = title;
            mapIcon.ZIndex = 0;

            MCMap.MapElements.Add(mapIcon);
            MCMap.Center = geoPoint;
            MCMap.ZoomLevel = 10;
        }


    }
}
