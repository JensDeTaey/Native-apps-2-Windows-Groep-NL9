using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Services.Maps;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows_App.Authentication;
using Windows_App.Data;
using Windows_App.Model;
using Windows_App.ViewModel;
using static Windows_App.Model.PageLoadWithMultipleParameters;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Windows_App.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BusinessDetailPage : Page
    {
        private BusinessDetailViewModel viewModel;
        public BusinessDetailPage()
        {
            this.InitializeComponent();
            //token you need to use maps
            MCMap.MapServiceToken = "NggniNfkWoAJYWaNrwu7~Ba_YkJv9SvsASrBV280AGQ~AqXz_H8d1GdioVSul1nTHcxPtsQlG3YdjJtPP9csVnPPyDNmc7kUv0G8x-QpQueG";
             
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is PageLoadWithMultipleParameters)
            {
                //Cast pageload
                PageLoadWithMultipleParameters pageLoad = e.Parameter as PageLoadWithMultipleParameters;

                int businessId = pageLoad.BusinessId;

                GoToRightPivot(pageLoad.Pivot);
                OnlineDataSource.singleton.FetchBusinessWithId(businessId).ContinueWith(t =>
                {
                    viewModel = new BusinessDetailViewModel(t.Result);
                    DataContext = viewModel;

                    if (NetworkInterface.GetIsNetworkAvailable())
                    {
                        AddEstablishmentsToMap();
                    }
                }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
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
            business.Business.Establishments.ForEach(async esta =>
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

        private void GoToRightPivot(PivotOptions pivot)
        {
            switch (pivot)
            {
                case PivotOptions.PROMOTION:
                    PivotBusiness.SelectedIndex = 2;
                    break;
                case PivotOptions.EVENT:
                    PivotBusiness.SelectedIndex = 3;
                    break;
                default:
                    PivotBusiness.SelectedIndex = 0;
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

        private async void Button_ClickAsync(object sender, RoutedEventArgs e)
        {
            //Creates an empty PDF document instance
            PdfDocument document = new PdfDocument();

            //Adding new page to the PDF document
            PdfPage page = document.Pages.Add();

            //Creates new PDF font
            PdfStandardFont font = new PdfStandardFont(PdfFontFamily.TimesRoman, 12);

            //Drawing text to the PDF document
            page.Graphics.DrawString("Kortingsbon", font, PdfBrushes.Black, 10, 10);

            //Create PDF graphics for the page

            PdfGraphics graphics = page.Graphics;

            //Load the image from the disk.
           

            //PdfBitmap image = new PdfBitmap("qrcode.png");

            //Draw the image

            //graphics.DrawImage(image, 0, 0);

            MemoryStream stream = new MemoryStream();
            
            //Saves the PDF document to stream
            await document.SaveAsync(stream);

            //Close the document

            document.Close(true);

            //Save the stream as PDF document file in local machine

            Save(stream, "KortingsBon.pdf");
        }

        async void Save(Stream stream, string filename)
        {

            stream.Position = 0;

            StorageFile stFile;
            if (!(Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons")))
            {
                FileSavePicker savePicker = new FileSavePicker();
                savePicker.DefaultFileExtension = ".pdf";
                savePicker.SuggestedFileName = "Kortingsbon";
                savePicker.FileTypeChoices.Add("Adobe PDF Document", new List<string>() { ".pdf" });
                stFile = await savePicker.PickSaveFileAsync();
            }
            else
            {
                StorageFolder local = Windows.Storage.ApplicationData.Current.LocalFolder;
                stFile = await local.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
            }
            if (stFile != null)
            {
                Windows.Storage.Streams.IRandomAccessStream fileStream = await stFile.OpenAsync(FileAccessMode.ReadWrite);
                Stream st = fileStream.AsStreamForWrite();
                st.Write((stream as MemoryStream).ToArray(), 0, (int)stream.Length);
                st.Flush();
                st.Dispose();
                fileStream.Dispose();
            }
        }

        private void ButtonSubscribe_Click(object sender, RoutedEventArgs e)
        {

            if(AuthenticationHandler.Instance.AuthenticatedStatus == AuthenticatedStatusEnum.UNREGISTERED)
            {
                Frame.Navigate(typeof(LogInPage));
                return;
            }


           viewModel.SubscribeClicked().ContinueWith(t =>
           {
               if(t.Result)
               {
                   if (viewModel.Business.IsSubscribedTo)
                   {
                       FontFamily font = new FontFamily("Segoe MDL2 Assets");
                       SubscribeButton.FontFamily = font;
                       SubscribeButton.Content = "\uEB52";
                       SubsribeText.Text = "ontvolg bedrijf";

                   }
                   else
                   {
                       FontFamily font = new FontFamily("Segoe MDL2 Assets");
                       SubscribeButton.FontFamily = font;
                       SubscribeButton.Content = "\uEB51";
                       SubsribeText.Text = "Volg bedrijf";
                   }
               }
           }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
            
        }
    }
}
