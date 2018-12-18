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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Windows_App.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EventsPage : Page
    {
        private EventsViewModel eventsViewModel;
        public EventsPage()
        {
            eventsViewModel = new EventsViewModel();
            DataContext = eventsViewModel;
            this.InitializeComponent();
        }

        private void ListViewEvents_ItemClick(object sender, ItemClickEventArgs e)
        {
            Event selectedEvent = e.ClickedItem as Event;
            PageLoadWithMultipleParameters payload = new PageLoadWithMultipleParameters
            {
                BusinessId = selectedEvent.BusinessId,
                Pivot = PivotOptions.EVENT
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
                    eventsViewModel.SortEventsByStartDate(false);
                    break;
                case "Startdatum late eerst":
                    eventsViewModel.SortEventsByStartDate(true);
                    break;
                case "Einddatum vroege eerst":
                    eventsViewModel.SortEventsByEndDate(false);
                    break;
                case "Einddatum late eerst":
                    eventsViewModel.SortEventsByEndDate(true);
                    break;
                default:
                    throw new Exception($"{comboboxItemSender.Content.ToString()} not defined in ListOrderModifier");
            }
        }

        private void ListFilterModifier_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
           eventsViewModel.FilterEvents(args.QueryText);
        }
    }
}
