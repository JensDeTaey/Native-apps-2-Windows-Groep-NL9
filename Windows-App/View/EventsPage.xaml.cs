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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Windows_App.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EventsPage : Page
    {
        public EventsPage()
        {
            this.InitializeComponent();
            DataContext = new EventsViewModel();
        }

        private void ListViewEvents_ItemClick(object sender, ItemClickEventArgs e)
        {
            Event selectedEvent = e.ClickedItem as Event;
            PageLoadWithMultipleParameters payload = new PageLoadWithMultipleParameters();
            payload.Business = selectedEvent.Business;
            payload.pivot = "event";
            Frame.Navigate(typeof(BusinessDetailPage), payload, new DrillInNavigationTransitionInfo());
        }
    }
}
