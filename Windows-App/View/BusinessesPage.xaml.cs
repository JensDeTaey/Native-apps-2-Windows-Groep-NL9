using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Windows_App.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BusinessesPage : Page
    {
        private BusinessesViewModel businessViewModel;
        public BusinessesPage()
        {
            businessViewModel = new BusinessesViewModel();
            this.DataContext = businessViewModel;
            this.InitializeComponent();
        }

    private void ListViewBusinesses_ItemClick(object sender, ItemClickEventArgs e)
        {
            Business selectedBusiness= e.ClickedItem as Business;
            PageLoadWithMultipleParameters pageLoad = new PageLoadWithMultipleParameters
            {
                BusinessId = selectedBusiness.Id,
                Pivot = PivotOptions.BUSINESS
            };
            Frame.Navigate(typeof(BusinessDetailPage), pageLoad, new DrillInNavigationTransitionInfo());
        }

        private void ListFilterModifier_QuerySubmitted(SearchBox sender, SearchBoxQuerySubmittedEventArgs args)
        {
            businessViewModel.FilterBusinesses(args.QueryText);
        }

        private void ListOrderModifier_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboboxSender = (ComboBox)sender;
            ComboBoxItem comboboxItemSender = (ComboBoxItem)comboboxSender.SelectedItem;
            switch (comboboxItemSender.Content.ToString())
            {
                case "Aantal volgers aflopend":
                    businessViewModel.SortBusinessesBySubscribers(false);
                    break;
                case "Aantal volgers oplopend":
                    businessViewModel.SortBusinessesBySubscribers(true);
                    break;
                default:
                    throw new Exception($"{comboboxItemSender.Content.ToString()} not defined in ListOrderModifier");
            }
           
        }
    }

}
