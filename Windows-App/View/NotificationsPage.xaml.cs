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
    public sealed partial class NotificationsPage : Page
    {
        public NotificationsViewModel ViewModel { get; set; }
        public NotificationsPage()
        {
            this.InitializeComponent();

            ViewModel =  new NotificationsViewModel();
            this.DataContext = ViewModel;
        }

        private void See_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.ClearNotifications();
        }

        private void ItemClick(object sender, ItemClickEventArgs e)
        {
            if(e.ClickedItem is Notification)
            {
                var not = e.ClickedItem as Notification;
                PageLoadWithMultipleParameters payload = new PageLoadWithMultipleParameters
                {
                    BusinessId = not.NotificationBusinessId,
                    Pivot = not.NotificationType == "PROMOTION" ? PivotOptions.PROMOTION : PivotOptions.EVENT
                };
                Frame.Navigate(typeof(BusinessDetailPage), payload, new DrillInNavigationTransitionInfo());
            }
        }
    }
}
