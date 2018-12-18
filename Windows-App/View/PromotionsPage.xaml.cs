using System;
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

    }
}
