using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows_App.Model;
using Windows_App.ViewModel;
using static Windows_App.Model.PageLoadWithMultipleParameters;
using static Windows_App.ViewModel.PromotionsViewModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Windows_App.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PromotionsPage : Page
    {
        private PromotionsViewModel promotionsViewModel;

        public PromotionsPage()
        {
            promotionsViewModel = new PromotionsViewModel();
            this.DataContext = promotionsViewModel;
            this.InitializeComponent();
        }

        private void ListViewPromotions_ItemClick(object sender, ItemClickEventArgs e)
        {
          Promotion selectedPromotion = e.ClickedItem as Promotion;
            PageLoadWithMultipleParameters payload = new PageLoadWithMultipleParameters
            {
                BusinessId = selectedPromotion.BusinessId,
                Pivot = PivotOptions.PROMOTION
            };
            Frame.Navigate(typeof(BusinessDetailPage), payload, new DrillInNavigationTransitionInfo());
        }


        private void ListOrderModifier_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboboxSender = (ComboBox)sender;
            ComboBoxItem comboboxItemSender = (ComboBoxItem)comboboxSender.SelectedItem;
            switch (comboboxItemSender.Content.ToString())
            {
                case "Startdatum vroege eerst":
                    promotionsViewModel.SortPromotionsByStartDate(false);
                    break;
                case "Startdatum late eerst":
                    promotionsViewModel.SortPromotionsByStartDate(true);
                    break;
                case "Einddatum vroege eerst":
                    promotionsViewModel.SortPromotionsByEndDate(false);
                    break;
                case "Einddatum late eerst":
                    promotionsViewModel.SortPromotionsByEndDate(true);
                    break;
                default:
                    throw new Exception($"{comboboxItemSender.Content.ToString()} not defined in ListOrderModifier");
            }
           
        }

        private void ListIsDiscountCouponModifier_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboboxSender = (ComboBox)sender;
            ComboBoxItem comboboxItemSender = (ComboBoxItem)comboboxSender.SelectedItem;
            switch (comboboxItemSender.Content.ToString())
            {
                case "Toon alles":
                    promotionsViewModel.FilterOnDiscount(DiscountFilterOption.ALL);
                    break;
                case "Is kortingsbon":
                    promotionsViewModel.FilterOnDiscount(DiscountFilterOption.AVAILABLE);
                    break;
                case "Geen kortingsbon":
                    promotionsViewModel.FilterOnDiscount(DiscountFilterOption.NOTAVAILABLE);
                    break;
                default:
                    throw new Exception($"{comboboxItemSender.Content.ToString()} not defined in ListIsDiscountCouponModifier");
            }

        }

        private void ListFilterModifier_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            promotionsViewModel.FilterPromotions(args.QueryText);
        }


        private async void HyperlinkButton_ClickAsync(object sender, RoutedEventArgs e)
        {
            //Create a new PDF document.
            PdfDocument document = new PdfDocument();
            //Add a page to the document.
            PdfPage page = document.Pages.Add();
            //Create PDF graphics for the page.
            PdfGraphics graphics = page.Graphics;
            //Set the standard font.
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 14);
            //Draw the text.
            Promotion promotion = promotionsViewModel.getPromotion(((Button)sender).Tag);
            graphics.DrawString("Kortingsbon te gebruiken bij volgende bezoek voor promotie: " + "\n" + promotion.Name + "\n" + promotion.Description, font, PdfBrushes.Black, new PointF(0, 0));


            //Save the PDF document to stream.
            MemoryStream stream = new MemoryStream();
            await document.SaveAsync(stream);
            //Close the document.
            
            //Save the stream as PDF document file in local machine. Refer to PDF/UWP section for respected code samples.
            
            document.Close(true);

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

    }
}
