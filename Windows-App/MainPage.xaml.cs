using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using Windows.UI.Xaml.Navigation;
using Windows_App.View;

namespace Windows_App
{

    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        //Collapse of the Navigation
        private void NavCollapseButton_Click(object sender, RoutedEventArgs e)
        {
            PageSplitView.IsPaneOpen = !PageSplitView.IsPaneOpen;
        }

        private void NavPageBusinessesStackPanel_Tapped(object sender, TappedRoutedEventArgs e)
        {
            mainFrame.Navigate(typeof(BusinessesPage));
            UpdateNavigationItems();
        }

        private void NavPagePromotionsStackPanel_Tapped(object sender, TappedRoutedEventArgs e)
        {
            mainFrame.Navigate(typeof(PromotionsPage));
            UpdateNavigationItems();
        }

        private void NavPageEventsStackPanel_Tapped(object sender, TappedRoutedEventArgs e)
        {
            mainFrame.Navigate(typeof(EventsPage));
            UpdateNavigationItems();
        }

        //Enabling en disabling the right navigation item
        private void UpdateNavigationItems()
        {
            Debug.WriteLine("Navs are triggered");
        }
    }
}
