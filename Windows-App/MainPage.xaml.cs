using System;
using System.Collections.Generic;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows_App.View;

namespace Windows_App
{

    public sealed partial class MainPage : Page
    {
        private List<Control> navigationControls;

        public MainPage()
        {
            this.InitializeComponent();

            navigationControls = new List<Control>()
            {
                 NavPageBusinessesControl,
                 NavPagePromotionsControl,
                 NavPageEventsContentControl
            };
        }

        //Collapse of the Navigation
        private void NavCollapseButton_Click(object sender, RoutedEventArgs e)
        {
            PageSplitView.IsPaneOpen = !PageSplitView.IsPaneOpen;
        }

        private void NavPageBusinessesControl_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(typeof(BusinessesPage));
            NavigationContentControlActivated(sender);
        }

        private void NavPagePromotionsControl_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(typeof(PromotionsPage));
            NavigationContentControlActivated(sender);
        }

        private void NavPageEventsContentControl_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(typeof(EventsPage));
            NavigationContentControlActivated(sender);
        }

        private void NavigationContentControlActivated(object sender)
        {
            //resetting all navigation Controls
            Style navigationButtonStyle = this.Resources["NavigationButtonStyle"] as Style;
            foreach (ContentControl navigationItem in navigationControls)
            {
                navigationItem.Style = navigationButtonStyle;
            }

            Control tappedControl = sender as Control;
            tappedControl.Style = (Style)this.Resources["SelectedNavigationButtonStyle"];
        }

    }
}
